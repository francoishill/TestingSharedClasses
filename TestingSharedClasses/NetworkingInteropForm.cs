using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net;
using System.IO;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace TestingSharedClasses
{
	public partial class NetworkingInteropForm : Form
	{
		Socket listeningSocket;
		Socket senderSocket;
		NetworkInterop.TextFeedbackEventHandler textFeedback;
		NetworkInterop.ProgressChangedEventHandler progressChanged;
		TaskbarManager windows7TaskbarManager;
		bool IsTaskbarManagerInitiatedAndSupported = false;

		public NetworkingInteropForm()
		{
			InitializeComponent();

			if (TaskbarManager.IsPlatformSupported)
			{
				windows7TaskbarManager = TaskbarManager.Instance;
				IsTaskbarManagerInitiatedAndSupported = true;
			}

			textFeedback += (snder, evtargs) => { AppendRichtextbox(evtargs.FeedbackText); };
			progressChanged += (snder, evtargs) => { UpdateProgress(evtargs.CurrentValue, evtargs.MaximumValue, evtargs.BytesPerSecond); };
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

		private void UpdateProgressNow(int currentValue, int maximumValue)
		{
			//toolStripProgressBar1.Maximum = maximumValue;
			//toolStripProgressBar1.Value = currentValue;
		}

		private delegate void ChangedProgressDelegate(int currentValue, int maximumValue);
		private void UpdateProgress(int currentValue, int maximumValue, double bytesPerSecond = -1)
		{
			ThreadingInterop.UpdateGuiFromThread(this, delegate
			{
				if (toolStripProgressBar1.Maximum != maximumValue) toolStripProgressBar1.Maximum = maximumValue;
				if (toolStripProgressBar1.Value != currentValue) toolStripProgressBar1.Value = currentValue;
				if (bytesPerSecond != -1 && labelBytesPerSecond.Text != Math.Round(bytesPerSecond, 0).ToString()) labelBytesPerSecond.Text = Math.Round(bytesPerSecond, 0).ToString();
				if (IsTaskbarManagerInitiatedAndSupported)
				{
					if (currentValue == 0 && maximumValue == 100)
						windows7TaskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
					else
					{
						windows7TaskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
						windows7TaskbarManager.SetProgressValue(currentValue, maximumValue, this.Handle);
					}
				}
				Application.DoEvents();
			});
		}

		private void buttonServer_Click(object sender, EventArgs e)
		{
			buttonStopServer.Visible = true;
			ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
			{
				//TODO: There is some issue with the second time a file is sent (on the server side).
				NetworkInterop.StartServer_FileStream(out listeningSocket, this, 11000, TextFeedbackEvent: textFeedback, ProgressChangedEvent: progressChanged);
			}, false);//, false);

			//ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
			//{
			//	//TODO: There is some issue with the second time a file is sent (on the server side).
			//	NetworkInterop.StartServer(out listeningSocket, this, 11000, TextFeedbackEvent: textFeedback, ProgressChangedEvent: progressChanged);
			//});//, false);
		}

		private void buttonClient_Click(object sender, EventArgs e)
		{
			ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
			{
				string fileToSend = textBoxFileToSend.Text;
				string ipOrHostaddress = textBoxIpOrHostaddress.Text;
				if (!File.Exists(fileToSend))
					UserMessages.ShowWarningMessage("File does not exist: " + fileToSend);
				else
				{
					NetworkInterop.TransferFile_FileStream(
						fileToSend,
						out senderSocket,

						//null,
						NetworkInterop.GetIPAddressFromString(textBoxIpOrHostaddress.Text),//"fjh.dyndns.org"),
						
						11000,
						TextFeedbackEvent: textFeedback,
						ProgressChangedEvent: progressChanged);
					//NetworkInterop.TransferFile(
					//  fileToSend,//@"F:\Series\The Big Bang Theory\Season 3\The.Big.Bang.Theory.S03E01.avi",
					//  out senderSocket,
					//  NetworkInterop.GetIPAddressFromString(ipOrHostaddress),
					//  11000);
				}
			}, false);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//if (Environment.CommandLine.Contains(".vshost"))
			//  Process.Start(@"C:\Users\francois\Documents\Visual Studio 2010\Projects\TestingSharedClasses\TestingSharedClasses\bin\Release\TestingSharedClasses.exe");
		}

		private void buttonStopServer_Click(object sender, EventArgs e)
		{
			buttonStopServer.Visible = false;
			listeningSocket.Close();
		}
	}
}
