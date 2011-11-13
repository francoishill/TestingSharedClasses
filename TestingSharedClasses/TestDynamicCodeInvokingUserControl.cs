using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CookComputing.XmlRpc;

namespace TestingSharedClasses
{
	public partial class TestDynamicCodeInvokingUserControl : Form
	{
		public TestDynamicCodeInvokingUserControl()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Dictionary<string, PropertyNameAndType> dict = dynamicCodeInvokingUserControl1.TestResultDictionary();
			foreach (string key in dict.Keys)
				MessageBox.Show(key + ": " + dict[key].Value.ToString());

			//SharedClassesSettings.EnsureAllSharedClassesSettingsNotNullCreateDefault();
			//Iclientside_DynamicCodeInvokingServerClass proxy = XmlRpcProxyGen.Create<Iclientside_DynamicCodeInvokingServerClass>();
			//proxy.Url = SharedClassesSettings.tracXmlRpcInteropSettings.GetCominedUrlForDynamicInvokationServer();

			//string[] TypeStringArray;
			//object[] ParameterList;
			//DynamicCodeInvoking.GetParameterListAndTypesStringArray(out TypeStringArray, out ParameterList, @"Hallo");
			//DynamicCodeInvoking.RunCodeReturnStruct resultObj = proxy.RunCodeDynamically(
			//	typeof(MessageBox).AssemblyQualifiedName,
			//	TypeStringArray,
			//	"Show",
			//	ParameterList
			//	);
			////MessageBox.Show("Not implemented yet.");
		}
	}
}
