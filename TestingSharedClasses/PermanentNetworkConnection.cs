﻿using System;
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

		private enum DataSentType { Handshake };

		private byte[] handshakeSentFromServerByteArray = new byte[] { 0, 0, 0, 1, 1, 1, 0, 0, 0 };
		private byte[] handshakeSentFromClientByteArray = new byte[] { 9, 9, 9, 0, 0, 0, 1, 2, 0 };
		//private bool HandshakeFailure_ServerToClient = false;
		bool handshakeBusy = false;
		private bool ServerToClientHandshake(out string errorMessage)
		{
			//TODO: Must not perform handshake if another transfer (like file or whatever) is bust, this would cause the bytes to get mixed up
			if (!handshakeBusy)
			{
				handshakeBusy = true;

				//errorMessage;
				if (!WriteDataToSocket(
					ref currentServerHandler,
					DataSentType.Handshake,
					handshakeSentFromServerByteArray,
					out errorMessage))
				{}//UserMessages.ShowWarningMessage("Could not perform handshake to server: " + errorMessage);
				else
				{
					NetworkStream ns = new NetworkStream(currentServerHandler);

					Int16 numberBytesToRead;
					byte[] receivedBytes_HandshakeBytes;
					byte[] receivedBytes_DataType;

					try
					{
						BinaryReader br = new BinaryReader(ns);
						while (currentServerHandler.Available < sizeof(Int16)) { if (IsBusyClosing) return false; }
						numberBytesToRead = br.ReadInt16();
						while (currentServerHandler.Available < numberBytesToRead) { if (IsBusyClosing) return false; }
						receivedBytes_DataType = br.ReadBytes(numberBytesToRead);//clientSocket.Receive(receivedBytes, numberBytesToRead, SocketFlags.None);
						DataSentType dst;
						if (!Enum.TryParse<DataSentType>(Encoding.ASCII.GetString(receivedBytes_DataType), out dst))
						{
							errorMessage = "Unable to get data type from string = " + Encoding.ASCII.GetString(receivedBytes_DataType);
							return false;
						}

						if (dst == DataSentType.Handshake)
						{
							while (currentServerHandler.Available < sizeof(Int16)) { if (IsBusyClosing) return false; }
							numberBytesToRead = br.ReadInt16();
							while (currentServerHandler.Available < numberBytesToRead) { if (IsBusyClosing) return false; }
							receivedBytes_HandshakeBytes = br.ReadBytes(numberBytesToRead);//clientSocket.Receive(receivedBytes, numberBytesToRead, SocketFlags.None);

							if (AreByteArraysEqual(receivedBytes_HandshakeBytes, handshakeSentFromClientByteArray))
								return true;
						}
					}
					finally
					{
						receivedBytes_DataType = null;
						receivedBytes_HandshakeBytes = null;
						handshakeBusy = false;
					}
				}

				handshakeBusy = false;
			}
			errorMessage = "Handshake already in progress";
			return false;
		}

		Socket serverSocket;
		Socket currentServerHandler = null;
		Timer serverContinualHandshakeTimer;
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

						try
						{
							currentServerHandler = serverSocket.Accept();
							AppendServerMessage("Connection accepted");
						}
						catch (SocketException sexc)
						{
							if (NetworkInterop.IsSocketTryingToCloseUponApplicationExit(sexc)) break;
							else UserMessages.ShowErrorMessage("SocketException occurred: " + sexc.Message);
						}

						if (currentServerHandler == null) continue;

						serverContinualHandshakeTimer = new Timer();
						serverContinualHandshakeTimer.Interval = 2000;
						serverContinualHandshakeTimer.Tick += new EventHandler(serverContinualHandshakeTimer_Tick);
						serverContinualHandshakeTimer.Start();

						int availableBytes;
						while (true)
						{
							if (IsBusyClosing)
								break;
							Application.DoEvents();

							if (!NetworkInterop.GetBytesAvailable(ref currentServerHandler, out availableBytes))
								continue;

							//Server reading:
							//byte[] receivedBytes = new byte[availableBytes];
							//int actualReceivedLength = currentServerHandler.Receive(receivedBytes);

							//AppendServerMessage("Number bytes received: " + actualReceivedLength.ToString());
						}
					}
				},
				false);
				AppendServerMessage("Server started...");
				Application.DoEvents();
			}
		}

		private void serverContinualHandshakeTimer_Tick(object sender, EventArgs e)
		{
			string errorMessage;
			if (!ServerToClientHandshake(out errorMessage))
			{
				AppendServerMessage("Failed to perform server-to-client handshake: " + errorMessage);
			}
			else
			{
				AppendServerMessage("Successfully performed server-to-client handshake");
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

				ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
				{
					while (true)
					{
						if (IsBusyClosing)
							break;

						//FileStream fileStreamIn = null;// new FileStream(defaultFilePathForSavingForClient, FileMode.Create);
						//MemoryStream memoryStreamForInfo = new MemoryStream();

						int availableBytes;
						if (!NetworkInterop.GetBytesAvailable(ref clientSocket, out availableBytes))
							continue;

						if (availableBytes < sizeof(Int16))
							continue;

						NetworkStream ns = new NetworkStream(clientSocket);
						BinaryReader br = new BinaryReader(ns);

						Int16 numberBytesToRead;
						byte[] receivedBytes_HandshakeBytes;
						byte[] receivedBytes_DataType;

						try
						{
							while (clientSocket.Available < sizeof(Int16)) { if (IsBusyClosing) break; }
							numberBytesToRead = br.ReadInt16();
							while (clientSocket.Available < numberBytesToRead) { if (IsBusyClosing) break; }
							receivedBytes_DataType = br.ReadBytes(numberBytesToRead);//clientSocket.Receive(receivedBytes, numberBytesToRead, SocketFlags.None);
							DataSentType dst;
							if (!Enum.TryParse<DataSentType>(Encoding.ASCII.GetString(receivedBytes_DataType), out dst))
								break;

							if (dst == DataSentType.Handshake)
							{
								while (clientSocket.Available < sizeof(Int16)) { if (IsBusyClosing) break; }
								numberBytesToRead = br.ReadInt16();
								while (clientSocket.Available < numberBytesToRead) { if (IsBusyClosing) break; }
								receivedBytes_HandshakeBytes = br.ReadBytes(numberBytesToRead);//clientSocket.Receive(receivedBytes, numberBytesToRead, SocketFlags.None);

								//if (receivedBytes_HandshakeBytes.Length == handshakeSentFromServerByteArray.Length)
								//	foreach (
								string errorMessage;
								if (AreByteArraysEqual(receivedBytes_HandshakeBytes, handshakeSentFromServerByteArray))
									if (!WriteDataToSocket(
										ref clientSocket,
										DataSentType.Handshake,
										handshakeSentFromClientByteArray,
										out errorMessage))
										UserMessages.ShowWarningMessage("Unable to send 'handshake' back to server: " + errorMessage);

							}
						}
						finally
						{
							receivedBytes_DataType = null;
							receivedBytes_HandshakeBytes = null;
						}


						//Int16 numberBytesToRead = br.ReadInt16();

						//while (clientSocket.Available < numberBytesToRead) { if (IsBusyClosing) break; }

						////Client reading:
						//byte[] receivedBytes = new byte[numberBytesToRead];
						//int actualReceivedLength = clientSocket.Receive(receivedBytes, numberBytesToRead, SocketFlags.None);

						AppendClientMessage("Data received..");
						//AppendClientMessage("Number bytes received: " + actualReceivedLength);
					}
				},
				false);
			}

			//clientBinaryWriter.Write(3);
			//clientBinaryWriter.Flush();

			//using (NetworkStream networkStream = new NetworkStream(clientSocket))
			//{
			//	using (BinaryWriter bw = new BinaryWriter(networkStream))
			//	{
			//		bw.Write(3);
			//	}
			//}
		}

		private bool AreByteArraysEqual(byte[] byteArray1, byte[] byteArray2)
		{
			if (byteArray1 == null && byteArray2 == null)
				return true;
			if (byteArray1 == null && byteArray2 != null)
				return false;
			if (byteArray1 != null && byteArray2 == null)
				return false;
			if (byteArray1.Length != byteArray2.Length)
				return false;

			for (int i = 0; i < byteArray1.Length; i++)
				if (byteArray1[i] != byteArray2[i])
					return false;

			return true;
		}

		private bool WriteDataToSocket(ref Socket socket, DataSentType dataType, byte[] dataToSend, out string ErrorMessageIfFailed)
		{
			try
			{
				BinaryWriter bw = new BinaryWriter(new NetworkStream(socket));
				byte[] handshakeTypeByteArray = Encoding.ASCII.GetBytes(dataType.ToString());
				bw.Write((Int16)handshakeTypeByteArray.Length);//The size of the next string (defining the data type)
				bw.Write(handshakeTypeByteArray);//Write string (to say what data comes next)
				bw.Write((Int16)dataToSend.Length);//Write the length of data to read next
				bw.Write(dataToSend);//For this instance, send the handshake signal
				bw.Flush();
				ErrorMessageIfFailed = null;
				return true;
			}
			catch (Exception exc)
			{
				ErrorMessageIfFailed = exc.Message;
				return false;
			}
		}

		private void AppendServerMessage(string serverMessage)
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

		private void AppendClientMessage(string clientMessage)
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

		private void buttonSERVER_SendByte_Click(object sender, EventArgs e)
		{
			if (currentServerHandler == null)
			{
				UserMessages.ShowWarningMessage("Cannot send data with no client connection");
				return;
			}

			//NetworkStream ns = new NetworkStream(currentServerHandler);
			//ns.WriteByte(7);
		}
	}
}
