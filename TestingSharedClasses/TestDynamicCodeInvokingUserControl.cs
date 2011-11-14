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
			try
			{
				Dictionary<string, ParameterNameAndType> dict = dynamicCodeInvokingUserControl1.GetSelectedDictionaryWithParameterNamesAndValues();
				//foreach (string key in dict.Keys)
				//	MessageBox.Show(key + ": " + dict[key].Value.ToString());

				SharedClassesSettings.EnsureAllSharedClassesSettingsNotNullCreateDefault();
				Iclientside_DynamicCodeInvokingServerClass proxy = XmlRpcProxyGen.Create<Iclientside_DynamicCodeInvokingServerClass>();
				proxy.Url = SharedClassesSettings.tracXmlRpcInteropSettings.GetCominedUrlForDynamicInvokationServer();

				List<object> objectList = new List<object>();
				foreach (string key in dict.Keys)
					objectList.Add(dict[key].Value);
				string[] TypeStringArray;
				object[] ParameterList;
				DynamicCodeInvoking.GetParameterListAndTypesStringArray(out TypeStringArray, out ParameterList, objectList.ToArray());
				//DynamicCodeInvoking.RunCodeFromStaticClass(
				//	dynamicCodeInvokingUserControl1.GetSelectedMethodClassType().AssemblyQualifiedName,
				//	TypeStringArray,
				//	dynamicCodeInvokingUserControl1.GetSelectedMethodName(),
				//	ParameterList);

				DynamicCodeInvoking.RunCodeReturnStruct resultObj = proxy.RunCodeDynamically(
					dynamicCodeInvokingUserControl1.GetSelectedMethodClassType().AssemblyQualifiedName,
					TypeStringArray,
					dynamicCodeInvokingUserControl1.GetSelectedMethodName(),
					ParameterList
					);
				////MessageBox.Show("Not implemented yet.");
			}
			catch (Exception exc)
			{
				UserMessages.ShowErrorMessage("Could not perform dynamic method remotely: " + Environment.NewLine + exc.Message + Environment.NewLine + Environment.NewLine + exc.StackTrace);
			}
		}
	}
}
