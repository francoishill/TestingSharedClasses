using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using Microsoft.Win32;
using SharedClasses;

namespace TestingSharedClasses
{
	/// <summary>
	/// Interaction logic for RemoteXmlRpc.xaml
	/// </summary>
	public partial class RemoteXmlRpc : Window
	{
		List<string> alltypeslist = null;
		ObservableCollection<string> filteredTypesList = null;

		public RemoteXmlRpc()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(this);
		}

		private void Button_GetListClick(object sender, RoutedEventArgs e)
		{
			PopulateTypeList();
			textBox1.Focus();
		}

		private void PopulateTypeList()
		{
			if (alltypeslist != null)
				return;
			alltypeslist = DynamicCodeInvoking.GetAllUniqueSimpleTypeStringsInCurrentAssembly;
			filteredTypesList = new ObservableCollection<string>(alltypeslist);
			listBox1.ItemsSource = filteredTypesList;
		}

		private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (filteredTypesList != null)
				filteredTypesList.Clear();
			filteredTypesList = null;
			filteredTypesList = new ObservableCollection<string>(
				alltypeslist.Where(
				s => s.IndexOf(textBox1.Text, StringComparison.InvariantCultureIgnoreCase) != -1));
			listBox1.ItemsSource = null;
			listBox1.ItemsSource = filteredTypesList;
		}

		private Type GetSelectedTypeFromListbox()
		{
			if (listBox1.SelectedIndex == -1)
				return null;
			return DynamicCodeInvoking.GetTypeFromSimpleString(listBox1.SelectedItem.ToString());
		}

		private bool IslistBox1SelectionChangeInvokedBylistBoxMethodList = false;
		private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listBox1.SelectedIndex == -1)
			{
				listBox2.ItemsSource = null;
				return;
			}

			if (!IslistBox1SelectionChangeInvokedBylistBoxMethodList)
				listBoxMethodList.SelectedItem = null;

			Type selectedType = GetSelectedTypeFromListbox();//Assembly.GetExecutingAssembly().GetType(selectedString);
			//var methods = selectedType.GetMethods().Where(m => m.IsStatic);
			listBox2.ItemsSource = selectedType.GetMethods().Where(m => m.IsStatic).OrderBy(meth => meth.Name + string.Format("00000", meth.GetParameters().Length));
			//var tmp = selectedType.GetMethods().Where(m => m.IsStatic);
			//foreach (MethodInfo mi in methods)
			//	System.Windows.Forms.MessageBox.Show(mi.IsStatic.ToString());
			//propertyGrid1.SelectedObject = selectedType.GetMethods(BindingFlags.Static);
		}

		private DynamicCodeInvoking.MethodDetailsClass currentMethodDetailsClass = null;
		private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MethodInfo mi = listBox2.SelectedItem as MethodInfo;
			if (mi == null)
			{
				currentMethodDetailsClass = null;
				propertyGrid1.SelectedObject = null;
				return;
			}
			currentMethodDetailsClass = new DynamicCodeInvoking.MethodDetailsClass(mi);
			propertyGrid1.SelectedObject = new DictionaryPropertyGridAdapter(currentMethodDetailsClass.HashTableOfParameters);//mi.GetParameters();
		}

		private void ButtonPerformRemotely_Click(object sender, RoutedEventArgs e)
		{
			DictionaryPropertyGridAdapter adap = propertyGrid1.SelectedObject as DictionaryPropertyGridAdapter;
			if (adap == null)
				return;
			DynamicCodeInvoking.RunSelectedFunction(
				adap._dictionary,
				GetSelectedTypeFromListbox().AssemblyQualifiedName,
				currentMethodDetailsClass.MethodName);
		}

		private void ButtonAddToLeftList_Click(object sender, RoutedEventArgs e)
		{
			DictionaryPropertyGridAdapter adap = propertyGrid1.SelectedObject as DictionaryPropertyGridAdapter;
			if (adap == null)
				return;
			if (listBoxMethodList.ItemsSource == null)
				listBoxMethodList.ItemsSource = new ObservableCollection<MethodToRun>();
			(listBoxMethodList.ItemsSource as ObservableCollection<MethodToRun>).Add(new MethodToRun(
				adap._dictionary,
				GetSelectedTypeFromListbox().AssemblyQualifiedName,
				currentMethodDetailsClass.MethodName));
		}

		private void ButtonPerformSelected_Click(object sender, RoutedEventArgs e)
		{
			if (listBoxMethodList.SelectedIndex == -1)
			{
				UserMessages.ShowWarningMessage("Please select an item first");
				return;
			}
			MethodToRun mtr = listBoxMethodList.SelectedItem as MethodToRun;
			if (mtr == null)
				return;
			DynamicCodeInvoking.RunSelectedFunction(mtr.Parameters, mtr.UsedClass_AssemblyQualifiedName, mtr.MethodName);
		}

		private void ButtonPerformAll_Click(object sender, RoutedEventArgs e)
		{
			foreach (MethodToRun mtr in listBoxMethodList.Items)
				DynamicCodeInvoking.RunSelectedFunction(mtr.Parameters, mtr.UsedClass_AssemblyQualifiedName, mtr.MethodName);
		}

		private void listBoxMethodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MethodToRun mtr = listBoxMethodList.SelectedItem as MethodToRun;
			if (mtr == null)
				return;

			textBox1.Text = "";
			string strLookingFor = mtr.UsedClass_AssemblyQualifiedName.Substring(0, mtr.UsedClass_AssemblyQualifiedName.IndexOf(','));
			for (int i = 0; i < listBox1.Items.Count; i++)
				if (listBox1.Items[i].ToString().Equals(strLookingFor))
				{
					IslistBox1SelectionChangeInvokedBylistBoxMethodList = true;
					listBox1.SelectedItem = listBox1.Items[i];
					listBox1.ScrollIntoView(listBox1.SelectedItem);
					IslistBox1SelectionChangeInvokedBylistBoxMethodList = false;

					Type typeLookingFor = DynamicCodeInvoking.GetTypeFromSimpleString(strLookingFor);
					if (typeLookingFor != null)
					{
						foreach (MethodInfo mi in typeLookingFor.GetMethods())
							if (mi.Name.Equals(mtr.MethodName, StringComparison.InvariantCultureIgnoreCase))
							{
								ParameterInfo[] parameters = mi.GetParameters();
								if (parameters.Length != mtr.Parameters.Count)
									continue;
								bool MismatchFound = false;
								var keys = mtr.Parameters.Keys.ToArray();
								for (int j = 0; j < parameters.Length; j++)
									if (parameters[j].ParameterType != mtr.Parameters[keys[j]].type)
										MismatchFound = true;
								if (!MismatchFound)
								{
									listBox2.SelectedItem = mi;
									listBox2.UpdateLayout();
									propertyGrid1.Update();
									propertyGrid1.UpdateLayout();
									DictionaryPropertyGridAdapter adap = propertyGrid1.SelectedObject as DictionaryPropertyGridAdapter;
									if (adap == null)
										UserMessages.ShowWarningMessage("Unable to get selected adapter for property grid.");
									else
									{
										adap._dictionary.Clear();
										adap._dictionary = null;
										adap._dictionary = mtr.Parameters;
										propertyGrid1.SelectedObject = null;
										adap.GetProperties(new Attribute[0]);
										propertyGrid1.SelectedObject = adap;
									}
								}
							}
					}
				}
		}

		private void ImportFromFile(string filepath = null)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select a file to load from";
			ofd.Filter = "Xml files (*.xml)|*.xml";
			if (filepath != null || ofd.ShowDialog().Value)
			{
				if (filepath != null)
					ofd.FileName = filepath;
				if (listBoxMethodList.Items.Count == 0 || UserMessages.Confirm("The operation list is currently not empty and will be cleared when importing file, continue?"))
				{
					PopulateTypeList();

					listBoxMethodList.ItemsSource = null;
					var tmpMethodToRunList = new ObservableCollection<MethodToRun>();

					string tmpUsedClass_AssemblyQualifiedName = null;
					string tmpMethodName = null;

					XmlDocument xmlDoc = new XmlDocument();
					xmlDoc.Load(ofd.FileName);
					XmlNodeList methodsToRun = xmlDoc.SelectNodes("ListOfMethodToRun/MethodToRun");
					foreach (XmlNode methodNode in methodsToRun)
					{
						tmpUsedClass_AssemblyQualifiedName = methodNode.Attributes["UsedClass_AssemblyQualifiedName"].Value;
						tmpMethodName = methodNode.Attributes["MethodName"].Value;
						if (string.IsNullOrWhiteSpace(tmpUsedClass_AssemblyQualifiedName))
							UserMessages.ShowWarningMessage("Cannot read MethodToRun attribute 'UsedClass_AssemblyQualifiedName': " + methodNode.OuterXml);
						else if (string.IsNullOrWhiteSpace(tmpMethodName))
							UserMessages.ShowWarningMessage("Cannot read MethodToRun attribute 'MethodName': " + methodNode.OuterXml);
						else
						{
							Dictionary<string, ParameterNameAndType> tmpParams = new Dictionary<string, ParameterNameAndType>();

							bool errorOccurred = false;
							XmlNodeList parameters = methodNode.SelectNodes("Parameters/Parameter");
							foreach (XmlNode paramNode in parameters)
							{
								string tmpParamName = paramNode.Attributes["Name"].Value;
								string tmpParamAssemblyQualifiedName = paramNode.Attributes["AssemblyQualifiedName"].Value;
								object tmpParamValue = paramNode.InnerText;
								if (string.IsNullOrWhiteSpace(tmpParamName))
									UserMessages.ShowWarningMessage("Cannot read Parameter attribute 'Name': " + paramNode.OuterXml);
								else if (string.IsNullOrWhiteSpace(tmpParamAssemblyQualifiedName))
									UserMessages.ShowWarningMessage("Cannot read Parameter attribute 'AssemblyQualifiedName': " + paramNode.OuterXml);
								else if (tmpParamValue == null)//It might? be empty...?
									UserMessages.ShowWarningMessage("Cannot read Parameter value: " + paramNode.OuterXml);
								else//Successful
								{
									var tmpparamtype = DynamicCodeInvoking.GetTypeFromSimpleString(tmpParamAssemblyQualifiedName.Substring(0, tmpParamAssemblyQualifiedName.IndexOf(',')));
									var tmpParam = new ParameterNameAndType(tmpParamName, tmpparamtype);
									tmpParamValue = Convert.ChangeType(tmpParamValue, tmpparamtype);
									tmpParam.OverrideValue(tmpParamValue);
									tmpParams.Add(tmpParamName, tmpParam);
									continue;
								}
								errorOccurred = true;//This will be skipped be the above "continue" if successful
							}

							if (!errorOccurred)
							{
								tmpMethodToRunList.Add(new MethodToRun(
									tmpParams,
									tmpUsedClass_AssemblyQualifiedName,
									tmpMethodName));
							}
						}
					}

					listBoxMethodList.ItemsSource = tmpMethodToRunList;
				}
			}
		}

		private void ExportToFile(string filepath = null)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Select a file to save to";
			sfd.Filter = "Xml files (*.xml)|*.xml";
			if (filepath != null || sfd.ShowDialog().Value)
			{
				if (filepath != null)
					sfd.FileName = filepath;
				using (var xw = new XmlTextWriter(sfd.FileName, System.Text.Encoding.ASCII) { Formatting = Formatting.Indented })
				{
					xw.WriteStartElement("ListOfMethodToRun");
					foreach (MethodToRun mtr in listBoxMethodList.Items)
					{
						xw.WriteStartElement("MethodToRun");
						xw.WriteAttributeString("UsedClass_AssemblyQualifiedName", mtr.UsedClass_AssemblyQualifiedName);
						xw.WriteAttributeString("MethodName", mtr.MethodName);
						xw.WriteStartElement("Parameters");
						var keys = mtr.Parameters.Keys.ToArray();
						foreach (string key in keys)
						{
							xw.WriteStartElement("Parameter");
							xw.WriteAttributeString("Name", mtr.Parameters[key].Name);
							xw.WriteAttributeString("AssemblyQualifiedName", mtr.Parameters[key].type.AssemblyQualifiedName);
							xw.WriteValue(mtr.Parameters[key].Value);
							xw.WriteEndElement();
						}
						xw.WriteEndElement();//Parameters
						xw.WriteEndElement();//MethodToRun
					}
					xw.WriteEndElement();//ListOfMethodToRun
				}
			}
		}

		const string appname = "RemoteXmlRpc";
		const string listsSubfolder = "SavedListsOfMethodsToRun";
		private void MenuitemLoadList_Click(object sender, RoutedEventArgs e)
		{
			string tmpdir = SettingsInterop.LocalAppdataPath(appname) + "\\" + listsSubfolder;
			string[] tmpNamelist = Directory.GetFiles(tmpdir).Select(f => System.IO.Path.GetFileNameWithoutExtension(f)).ToArray();
			if (tmpNamelist == null || tmpNamelist.Length == 0)
			{
				if (UserMessages.Confirm("There are no lists saved yet, import from custom file rather?"))
					ImportFromFile();
			}
			else
			{
				//string NameToUse = InputBoxWPF.Prompt("Please enter the desired name of this list to load", "List name to load");
				//string NameToUse = PickItemForm.PickItem<string>(tmpNamelist, "Please choose the list to load", null);
				string NameToUse = PickItemWPF.PickItem(typeof(string), tmpNamelist, "Please choose the list to load", null) as string;
				if (NameToUse != null)
				{
					if (string.IsNullOrWhiteSpace(NameToUse))
						UserMessages.ShowWarningMessage("Cannot use a blank string for a name");
					else
						ImportFromFile(SettingsInterop.GetFullFilePathInLocalAppdata(NameToUse + ".mtrl", appname, listsSubfolder));
				}
			}
		}

		private void MenuitemSaveList_Click(object sender, RoutedEventArgs e)
		{
			string NameToUse = InputBoxWPF.Prompt("Please enter the desired name of this list to save to", "Name the list");
			if (NameToUse != null)
			{
				if (string.IsNullOrWhiteSpace(NameToUse))
					UserMessages.ShowWarningMessage("Cannot use a blank string for a name");
				else
				{
					string tmpfilepath = SettingsInterop.GetFullFilePathInLocalAppdata(NameToUse + ".mtrl", "RemoteXmlRpc", "SavedListsOfMethodsToRun");
					if (!File.Exists(tmpfilepath) || UserMessages.Confirm("The list name already exists, overwrite it?"))
						ExportToFile(tmpfilepath);
				}
			}
		}

		private void MenuitemImportFromFile_Click(object sender, RoutedEventArgs e)
		{
			ImportFromFile();
		}

		private void MenuitemExportToFile_Click(object sender, RoutedEventArgs e)
		{
			ExportToFile();
		}

		private void MenuitemExit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown(0);
		}
	}

	public class MethodToRun
	{
		public Dictionary<string, ParameterNameAndType> Parameters { get; set; }
		public string UsedClass_AssemblyQualifiedName { get; set; }
		public string MethodName { get; set; }
		public MethodToRun(Dictionary<string, ParameterNameAndType> Parameters, string UsedClass_AssemblyQualifiedName, string MethodName)
		{
			this.Parameters = Parameters;
			this.UsedClass_AssemblyQualifiedName = UsedClass_AssemblyQualifiedName;
			this.MethodName = MethodName;
		}

		public string UsedClass_HumanName
		{
			get
			{
				if (string.IsNullOrEmpty(UsedClass_AssemblyQualifiedName))
					return "";
				else
				{
					string partbeforeFirstComma = UsedClass_AssemblyQualifiedName.Substring(0, UsedClass_AssemblyQualifiedName.IndexOf(','));
					return partbeforeFirstComma.Substring(partbeforeFirstComma.LastIndexOf('.') + 1);
				}
			}
		}
	}

	#region Converters
	public class MethodInfoToParameterListConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			MethodInfo mi = value as MethodInfo;
			if (mi == null)
				return "";
			string tmpStr = "";
			foreach (ParameterInfo pi in mi.GetParameters())
				tmpStr += (tmpStr.Length > 0 ? ", " : "") + pi.Name;//string.Format("{0} ({1})", pi.Name, pi.ParameterType.ToString());
			return tmpStr;//string.Join(",", mi.GetParameters().ToList());
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class TooltipMethodInfoToParameterListConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			MethodInfo mi = value as MethodInfo;
			if (mi == null)
				return "";
			string tmpStr = "";
			foreach (ParameterInfo pi in mi.GetParameters())
				tmpStr += (tmpStr.Length > 0 ? Environment.NewLine : "") + string.Format("{0} is {1}", pi.Name, pi.ParameterType.ToString());
			return tmpStr;//string.Join(",", mi.GetParameters().ToList());
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	#endregion Converters
}
