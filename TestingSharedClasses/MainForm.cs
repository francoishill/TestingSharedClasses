using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSharedClasses
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			ApplicationRecoveryAndRestart.RegisterApplicationRecoveryAndRestart(delegate
			{
				ApplicationRecoveryAndRestart.WriteCrashReportFile("TestingSharedClasses", "The application has crashed");
			},
			delegate
			{
				labelRecoveryAndRestartSafe.Visible = true;
			});
		}

		private void buttonNetworkingInterop_Click(object sender, EventArgs e)
		{
			NetworkingInteropForm networkingInteropForm = new NetworkingInteropForm();
			networkingInteropForm.Show();
		}

		private void buttonAutoCompleteInterop_Click(object sender, EventArgs e)
		{
			AutoCompleteInteropForm autoCompleteInteropForm = new AutoCompleteInteropForm();
			autoCompleteInteropForm.Show();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			NetworkingInteropForm networkingInteropForm = new NetworkingInteropForm();
			networkingInteropForm.Show();
			networkingInteropForm.buttonServer.PerformClick();

			//MemoryStream stream = new MemoryStream();
			//BinaryWriter b = new BinaryWriter(stream);
			////b.Write(true);
			//b.Write("F");
			//stream.Flush();
			//b.Write(123.1234);
			//b.Write(456D);
			//stream.Position = 0;
			//BinaryReader br = new BinaryReader(stream);
			//MessageBox.Show(br.ReadBoolean().ToString());
			//MessageBox.Show(br.ReadString());
			//MessageBox.Show(br.ReadDouble().ToString());
			//MessageBox.Show(br.ReadDouble().ToString());
		}
	}
}
