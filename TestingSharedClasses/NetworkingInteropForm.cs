using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net;

namespace TestingSharedClasses
{
	public partial class NetworkingInteropForm : Form
	{
		Socket listeningSocket = null;
		Socket senderSocket = null;

		public NetworkingInteropForm()
		{
			InitializeComponent();

			NetworkInterop.textFeedback += (snder, evtargs) => { AppendRichtextbox(evtargs.FeedbackText); };
			NetworkInterop.progressChanged += (snder, evtargs) => { UpdateProgress(evtargs.CurrentValue, evtargs.MaximumValue); };
			//MessageBox.Show(Environment.CommandLine);
			//Process.Start(Environment.CommandLine.Replace(".vshost", ""));
		}

		private void AppendRichtextbox(string text)
		{
			ThreadingInterop.UpdateGuiFromThread(richTextBox1, delegate
			{
				richTextBox1.Text += (richTextBox1.Text.Length > 0 ? Environment.NewLine : "") + text;
				Application.DoEvents();
			});
		}

		private void UpdateProgress(int currentValue, int maximumValue)
		{
			ThreadingInterop.UpdateGuiFromThread(statusStrip1, delegate
			{
				if (toolStripProgressBar1.Maximum != maximumValue) toolStripProgressBar1.Maximum = maximumValue;
				if (toolStripProgressBar1.Value != currentValue) toolStripProgressBar1.Value = currentValue;
			});
		}

		private void buttonServer_Click(object sender, EventArgs e)
		{
			ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
			{
				NetworkInterop.StartServer(ref listeningSocket, this, 11000);
			});//, false);
		}

		private void buttonClient_Click(object sender, EventArgs e)
		{
			NetworkInterop.TransferFile(@"F:\Series\The Big Bang Theory\Season 3\The.Big.Bang.Theory.S03E01.avi", ref senderSocket,
				NetworkInterop.GetIPAddressFromString("100.0.0.104"),
				11000);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//if (Environment.CommandLine.Contains(".vshost"))
			//  Process.Start(@"C:\Users\francois\Documents\Visual Studio 2010\Projects\TestingSharedClasses\TestingSharedClasses\bin\Release\TestingSharedClasses.exe");
		}
	}
}
