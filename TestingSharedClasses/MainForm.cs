using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

		private void buttonSerializationInterop_Click(object sender, EventArgs e)
		{
			//MemoryStream ms = new MemoryStream();
			//BinaryWriter bw = new BinaryWriter(ms);
			//bw.Write("Francois");
			//bw.Write("Hill");
			//ms.Seek(0, SeekOrigin.Begin);
			//BinaryReader br = new BinaryReader(ms);
			//while (br.PeekChar() != -1)
			//{
			//	string tmpstr = br.ReadString();
			//	MessageBox.Show(tmpstr);
			//	//tmpstr = br.ReadString();
			//}
			//MessageBox.Show("Done");

			SerializationInteropForm serializationInteropForm = new SerializationInteropForm();
			serializationInteropForm.AddControlsForCustomObject(new testClass("Francois", "Hill", 24));
			serializationInteropForm.ShowDialog();
		}

		class testClass
		{
			public string NameField;
			public string NameProperty { get; set; }
			public string SurnameField;
			public string SurnameProperty { get; set; }
			public int AgeField;
			public int AgeProperty { get; set; }
			public testClass() { }
			public testClass(string NameIn, string SurnameIn, int AgeIn)
			{
				NameField = NameIn;
				NameProperty = NameIn;
				SurnameField = SurnameIn;
				//SurnameProperty = SurnameIn;
				AgeField = AgeIn;
				AgeProperty = AgeIn;
			}

			//public object this[int index]
			//{
			//	get { return 5; /* return the specified index here */ }
			//	set { /* set the specified index to value here */ }
			//}
		}
	}
}
