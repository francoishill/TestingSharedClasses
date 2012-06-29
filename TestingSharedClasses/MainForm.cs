using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using InlineCommandToolkit;
//using Microsoft.Win32.TaskScheduler;
using SharedClasses;
using ICommandWithHandler = InlineCommandToolkit.InlineCommands.ICommandWithHandler;

namespace TestingSharedClasses
{
	public partial class MainForm : Form
	{
		public TextFeedbackEventHandler textFeedbackEvent;

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

			textFeedbackEvent += (snder, evtargs) =>
			{
				ThreadingInterop.UpdateGuiFromThread(this, () =>
				{ textBox1.Text += (textBox1.Text.Length > 0 ? Environment.NewLine : "") + evtargs.FeedbackText; });
			};

			UserMessages.iconForMessages = this.Icon;
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
			//ProwlAPI.SendNotificationUntilResponseFromiDevice(
			//	"6fa888aaf5f801edd5520fb1e7996447beb414dd",
			//	"TestSharedClasses",
			//	TimeSpan.FromSeconds(5),
			//	ProwlAPI.Priority.High);

			//AppManagerInterface appManagerInterface = new AppManagerInterface();
			//appManagerInterface.Show();

			//GenericSettings.EnsureAllSettingsAreInitialized();
			//SharedClassesSettings.EnsureAllSharedClassesSettingsNotNullCreateDefault();
			//inlineCommandsUserControl1.InitializeTreeViewNodes();

			//CommandsWindow cw = new CommandsWindow(this);
			//cw.Show();

			//buttonTestPermanentNetworkConnection.PerformClick();

			//buttonTestPermanentNetworkConnection.PerformClick();

			//NetworkingInteropForm networkingInteropForm = new NetworkingInteropForm();
			//networkingInteropForm.Show();
			//networkingInteropForm.buttonServer.PerformClick();

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

			//AddTaskToWindowsTaskScheduler();
		}

		/*private readonly string taskPath = "TestFrancois123";
		public void AddTaskToWindowsTaskScheduler()
		{
			TaskService ts = new TaskService();

			Task tmpTask = ts.GetTask(taskPath);
			if (tmpTask == null)
			{
				TaskDefinition td = ts.NewTask();
				td.RegistrationInfo.Description = "Testing a custom task";
				td.Triggers.Add(new DailyTrigger() { StartBoundary = DateTime.Now + TimeSpan.FromSeconds(30) });
				td.Actions.Add(new ShowMessageAction("Body from C#", "Title from C#"));
				td.Actions.Add(new ExecAction("cmd.exe", null, null));
				ts.RootFolder.RegisterTaskDefinition(taskPath, td);

				tmpTask = ts.GetTask(taskPath);
				tmpTask.ToString();
			}
		}*/

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


		private void buttonTempNewCommandsManagerClass_Click(object sender, EventArgs e)
		{
			//TempNewCommandsManagerClass.GoogleSearchCommand gc = new TempNewCommandsManagerClass.GoogleSearchCommand();
			//TempNewCommandsManagerClass.PerformCommand(gc, "Hallo there");

			//TempNewCommandsManagerClass.RunCommand rc = new TempNewCommandsManagerClass.RunCommand();
			//TempNewCommandsManagerClass.PerformCommand(rc, textFeedbackEvent, @"c:\");

			//TempNewCommandsManagerClass.ExploreCommand ex = new TempNewCommandsManagerClass.ExploreCommand();
			//TempNewCommandsManagerClass.PerformCommand(ex, @"c:\francois\other");

			//TempNewCommandsManagerClass.AddTodoitemFirepumaCommand ti = new TempNewCommandsManagerClass.AddTodoitemFirepumaCommand();
			//TempNewCommandsManagerClass.PerformCommand(ti, textFeedbackEvent, "5", "23", "Name");

			treeView1.Nodes.Clear();
			textBox2.Enabled = false;
			foreach (ICommandWithHandler comm in CommandsManagerClass.ListOfInitializedCommandInterfaces)
				treeView1.Nodes.Add(new TreeNode()
				{
					Name = comm.CommandName,
					Text = comm.DisplayName,
					Tag = comm
				});
		}
		//List<ICommandWithHandler> ListOfInitializedCommandInterfaces = null;

		private void button_SettingsInterop_Click(object sender, EventArgs e)
		{
			//TestSettings ts = SettingsInterop.GetSettings<TestSettings>(
			//	"Settingstest.xml",
			//	"TestingSharedClasses",
			//	"Network",
			//	"FJH");
			//MessageBox.Show(ts.MySettingString);
			//SettingsInterop.FlushSettings(
			//	new TestSettings() { MySettingString = "MyValue", MySettingInt = 123 },
			//	@"settingstest.xml",
			//	"TestingSharedClasses",
			//	"Network",
			//	"FJH");
		}

		private void button_XmlRpc_Click(object sender, EventArgs e)
		{
			TestXmlRpc testXmlRpc = new TestXmlRpc();
			testXmlRpc.Show();
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			StylingInterop.SetTreeviewVistaStyle(treeView1);
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				e.Handled = true;
				if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is ICommandWithHandler)
				{
					MessageBox.Show("Function commented out because it is old and obsolete");
					//ICommandWithHandler comm = treeView1.SelectedNode.Tag as ICommandWithHandler;
					//CommandsManagerClass.PerformCommandFromString(
					//	comm,
					//	textFeedbackEvent,
					//	null,
					//	textBox2.Text);
				}
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			textBox2.Enabled = e.Node != null;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CommandsWindow inlineCommandsWindowWPF = new CommandsWindow(this);
			inlineCommandsWindowWPF.ShowDialog();
		}

		private void buttonTestPermanentNetworkConnection_Click(object sender, EventArgs e)
		{
			PermanentNetworkConnection formPNC = new PermanentNetworkConnection();
			formPNC.Show();
		}

		private void buttonSendProwl_Click(object sender, EventArgs e)
		{
			//ProwlAPI.SendProwlNow(
			//	apiKey: "6fa888aaf5f801edd5520fb1e7996447beb414dd",
			//	applicationName: "TestingSharedClasses",
			//	Event: "Test event",
			//	description: textBoxProwlMessage.Text,
			//	priority: ProwlAPI.Priority.Emergency,
			//	callbackUrl: "http://firepuma.com"
			//	);
		}

		public string ConvertStringToHex(string asciiString)
		{
			string hex = "";
			foreach (char c in asciiString)
			{
				int tmp = c;
				hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
			}
			return hex;
		}

		public static string ByteArrayToString(byte[] ba)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
				hex.AppendFormat("{0:x2}", b);
			return hex.ToString();
		}

		public static byte[] StringToByteArray(String hex)
		{
			int NumberChars = hex.Length;
			byte[] bytes = new byte[NumberChars / 2];
			for (int i = 0; i < NumberChars; i += 2)
				bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			return bytes;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//WebInterop.SetDefaultJsonInstanceSettings();
			//string hex = WebInterop.GetJsonStringFromObject(ByteArrayToString(File.ReadAllBytes(@"C:\Windows\xDelta3.exe")), false);
			//DynamicCodeInvoking.RunCodeReturnStruct result = DynamicCodeInvoking.ClientSaveJsonStringToFile("My category", "My name", "{ 'json' : '" + hex + "' }");
			DynamicCodeInvoking.RunCodeReturnStruct result = DynamicCodeInvoking.ClientGetJsonStringFromFile("My category", "My name");
			if (!result.Success)
				UserMessages.ShowErrorMessage(result.ErrorMessage);
			else
			{
				UserMessages.ShowInfoMessage("Successfully obtained json: " + result.MethodInvokeResultingObject.ToString());
			}

			//var type = DynamicCodeInvoking.GetTypeFromSimpleString(typeof(Process).FullName, true);
			//string staticMethodName = "Start";
			//DynamicCodeInvoking.RunCodeReturnStruct runmethod = DynamicCodeInvoking.RunSelectedFunction(
			//	new Dictionary<string, ParameterNameAndType>() {
			//		{"fileName", new ParameterNameAndType("fileName", typeof(string), "explorer") },
			//		{"arguments", new ParameterNameAndType("arguments", typeof(string), "/select,\"" + @"c:\francois" + "\"") }
			//	},
			//	type.AssemblyQualifiedName,
			//	staticMethodName,
			//	false,
			//	false);
			//if (runmethod.Success)
			//	UserMessages.ShowInfoMessage("Success, result = " + runmethod.MethodInvokeResultingObject.ToString());
			//else
			//	if (UserMessages.Confirm("Error occurred with remote function call, see error now?"))
			//		UserMessages.ShowErrorMessage(runmethod.ErrorMessage);

			//var type = DynamicCodeInvoking.GetTypeFromSimpleString(typeof(MessageBox).FullName, true);
			//DynamicCodeInvoking.RunCodeReturnStruct runmethod = DynamicCodeInvoking.RunSelectedFunction(
			//	new Dictionary<string, ParameterNameAndType>() {
			//		{"text", new ParameterNameAndType("text", typeof(string), "Hallo sexy") }
			//	},
			//	type.AssemblyQualifiedName,
			//	"Show",
			//	false);
			//if (runmethod.MethodInvokeResultingObject != null && runmethod.MethodInvokeResultingObject is DialogResult && (DialogResult)runmethod.MethodInvokeResultingObject == DialogResult.OK)
			//	UserMessages.ShowInfoMessage("OK was clicked");
			//else
			//	UserMessages.ShowErrorMessage("Failed, result = " + runmethod.MethodInvokeResultingObject + Environment.NewLine + "Error = " + runmethod.ErrorMessage);
		}
	}

	public class TestSettings
	{
		private string _MySettingString;

		public string MySettingString
		{
			get { return _MySettingString; }
			set { MessageBox.Show("Set value: " + value); _MySettingString = value; }
		}

		private int _MySettingInt;

		public int MySettingInt
		{
			get { return _MySettingInt; }
			set { _MySettingInt = value; }
		}


		//public string MySettingString { get { return default; } set { MessageBox.Show("Set value: " + value); } }
		//public int MySettingInt { get; set; }
	}
}
