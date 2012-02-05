using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingSharedClasses
{
	public partial class PermanentNetworkConnection : Form
	{
		public PermanentNetworkConnection()
		{
			InitializeComponent();

			this.Disposed += new EventHandler(PermanentNetworkConnection_Disposed);
		}

		private bool IsBusyClosing = false;
		void PermanentNetworkConnection_Disposed(object sender, EventArgs e)
		{
			IsBusyClosing = true;
			ThreadingInterop.ForceExitAllTreads = true;
			if (serverSocket != null)
			{
				serverSocket.Blocking = false;
				serverSocket.Close();
			}
			if (clientSocket != null)
			{
				clientSocket.Blocking = false;
				clientSocket.Close();
			}
		}

		Socket serverSocket;
		Socket clientSocket;
		NetworkStream clientNetworkStream;
		BinaryWriter clientBinaryWriter;
		private void buttonStartServer_Click(object sender, EventArgs e)
		{
			if (serverSocket == null)
			{
				ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
				{
					serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					NetworkInterop.SetupServerSocketSettings(
						ref serverSocket,
						103,
						1024,
						100);

					while (true)
					{
						if (IsBusyClosing)
							break;

						Socket handler = null;
						try
						{
							handler = serverSocket.Accept();
							AppentServerMessage("Connection accepted");
						}
						catch (SocketException sexc)
						{
							if (NetworkInterop.IsSocketTryingToCloseUponApplicationExit(sexc)) break;
							else UserMessages.ShowErrorMessage("SocketException occurred: " + sexc.Message);
						}

						if (handler == null) continue;

						int availableBytes;
						while (true)
						{
							if (IsBusyClosing)
								break;

							if (!NetworkInterop.GetBytesAvailable(ref handler, out availableBytes))
								continue;

							byte[] receivedBytes = new byte[availableBytes];
							int actualReceivedLength = handler.Receive(receivedBytes);

							AppentServerMessage("Number bytes received: " + actualReceivedLength.ToString());
						}
					}
				},
				false);
				AppentServerMessage("Server started...");
				Application.DoEvents();
			}
		}

		private void buttonStartClient_Click(object sender, EventArgs e)
		{
			if (clientSocket == null)
			{
				if (!NetworkInterop.ConnectToServer(
					out clientSocket,
					ipAddress: System.Net.IPAddress.Parse(comboBoxServerIP.Text),//"10.0.0.200"),
					listeningPort: 103))
				{
					try
					{
						clientSocket.Blocking = true;
						clientSocket.Close();
					}
					catch { }
					UserMessages.ShowWarningMessage("Could not connect to server");
					return;
				}
				clientNetworkStream = new NetworkStream(clientSocket);
				clientBinaryWriter = new BinaryWriter(clientNetworkStream);
			}

			clientBinaryWriter.Write(3);


			//using (NetworkStream networkStream = new NetworkStream(clientSocket))
			//{
			//	using (BinaryWriter bw = new BinaryWriter(networkStream))
			//	{
			//		bw.Write(3);
			//	}
			//}
		}

		private void AppentServerMessage(string serverMessage)
		{
			Action appendAction = new Action(
				delegate
				{
					textBoxServerMessages.Text +=
						(textBoxServerMessages.Text.Length > 0 ? Environment.NewLine : "")
						+ serverMessage;
				});
			if (textBoxServerMessages.InvokeRequired)
				textBoxServerMessages.Invoke(appendAction);
			else
				appendAction();
		}

		private void AppentClientMessage(string clientMessage)
		{
			Action appendAction = new Action(
				delegate
				{
					textBoxClientMessages.Text +=
						(textBoxClientMessages.Text.Length > 0 ? Environment.NewLine : "")
						+ clientMessage;
				});
			if (textBoxClientMessages.InvokeRequired)
				textBoxClientMessages.Invoke(appendAction);
			else
				appendAction();
		}
	}
}
