using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CookComputing.XmlRpc;

namespace TestingSharedClasses
{
	public partial class TestXmlRpc : Form
	{
		public TestXmlRpc()
		{
			InitializeComponent();
		}

		private void button_XmlRpcServer_Click(object sender, EventArgs e)
		{
			XmlRpcInterop.SampleServer();
		}

		private void button_XmlRpcClient_Click(object sender, EventArgs e)
		{
			XmlRpcInterop.SampleClient();
		}

		private void TestXmlRpc_FormClosing(object sender, FormClosingEventArgs e)
		{
			XmlRpcInterop.UnregisterAllRegisteredChannels();
		}
	}
}
