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
using RunCodeReturnStruct = DynamicCodeInvoking.RunCodeReturnStruct;

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
			DynamicCodeInvoking.RunSelectedFunction(
				dynamicCodeInvokingUserControl1.GetSelectedDictionaryWithParameterNamesAndValues(),
				dynamicCodeInvokingUserControl1.GetSelectedMethodClassType().AssemblyQualifiedName,
				dynamicCodeInvokingUserControl1.GetSelectedMethodName());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DynamicCodeInvoking.RunBlockOfCodeNow(
				dynamicCodeInvokingUserControl1.GetBlockOfCode());
		}
	}
}
