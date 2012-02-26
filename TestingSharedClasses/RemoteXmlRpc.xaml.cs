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
		ObservableCollection<string> typelist = null;

		public RemoteXmlRpc()
		{
			InitializeComponent();
		}

		private void Button_GetListClick(object sender, RoutedEventArgs e)
		{
			typelist = new ObservableCollection<string>(
				DynamicCodeInvoking.GetAllUniqueSimpleTypeStringsInCurrentAssembly);
			listBox1.ItemsSource = typelist;
		}

		private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listBox1.SelectedIndex == -1)
				return;
			string selectedString = listBox1.SelectedItem.ToString();
			Type selectedType = DynamicCodeInvoking.GetTypeFromSimpleString(selectedString);//Assembly.GetExecutingAssembly().GetType(selectedString);
			propertyGrid1.SelectedObject = selectedType;
		}
	}
}
