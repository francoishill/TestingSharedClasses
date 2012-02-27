using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			alltypeslist = DynamicCodeInvoking.GetAllUniqueSimpleTypeStringsInCurrentAssembly;
			filteredTypesList = new ObservableCollection<string>(alltypeslist);
			listBox1.ItemsSource = filteredTypesList;
			textBox1.Focus();
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

		private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listBox1.SelectedIndex == -1)
			{
				listBox2.ItemsSource = null;
				return;
			}

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
				return;
			MethodToRun mtr = listBoxMethodList.SelectedItem as MethodToRun;
			if (mtr == null)
				return;
			DynamicCodeInvoking.RunSelectedFunction(mtr.Parameters, mtr.UsedClass_AssemblyQualifiedName, mtr.MethodName);
		}

		private void ButtonPerformAll_Click(object sender, RoutedEventArgs e)
		{
			UserMessages.ShowInfoMessage("Function not incorporated yet");
			//if (listBoxMethodList.SelectedIndex == -1)
			//	return;
			//MethodToRun mtr = listBoxMethodList.SelectedItem as MethodToRun;
			//if (mtr == null)
			//	return;
		}

		private void listBoxMethodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MethodToRun mtr = listBoxMethodList.SelectedItem as MethodToRun;
			if (mtr == null)
				return;

			textBox1.Text = "";
			//DynamicCodeInvoking.GetTypeFromSimpleString(mtr.
			string strLookingFor = mtr.UsedClass_AssemblyQualifiedName.Substring(0, mtr.UsedClass_AssemblyQualifiedName.IndexOf(','));
			for (int i = 0; i < listBox1.Items.Count; i++)
				if (listBox1.Items[i].ToString().Equals(strLookingFor))
				{
					listBox1.SelectedItem = listBox1.Items[i];
					listBox1.ScrollIntoView(listBox1.SelectedItem);
				}
		}
	}

	public class MethodToRun
	{
		public Dictionary<string, ParameterNameAndType> Parameters { get; set; }
		public string UsedClass_AssemblyQualifiedName{ get; set; }
		public string MethodName{ get; set; }
		public MethodToRun(Dictionary<string, ParameterNameAndType> Parameters, string UsedClass_AssemblyQualifiedName, string MethodName)
		{
			this.Parameters = Parameters;
			this.UsedClass_AssemblyQualifiedName = UsedClass_AssemblyQualifiedName;
			this.MethodName = MethodName;
		}

		public string HumanName
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
