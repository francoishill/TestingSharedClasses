//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.Net.Sockets;
//using System.Threading;
//using System.IO;
//using System.Diagnostics;

//namespace TestingSharedClasses
//{
//  public partial class Form1 : Form
//  {
//    public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);
//    public class ProgressChangedEventArgs : EventArgs
//    {
//      public double ProgressPercentage;
//      public ProgressChangedEventArgs(double ProgressPercentageIn)
//      {
//        ProgressPercentage = ProgressPercentageIn;
//      }
//    }

//    public delegate void TextFeedbackEventHandler(object sender, TextFeedbackEventArgs e);
//    public class TextFeedbackEventArgs : EventArgs
//    {
//      public string FeedbackText;
//      public TextFeedbackEventArgs(string FeedbackTextIn)
//      {
//        FeedbackText = FeedbackTextIn;
//      }
//    }

//    public static event ProgressChangedEventHandler progressChanged;
//    public static event TextFeedbackEventHandler textFeedback;

//    public Form1()
//    {
//      InitializeComponent();

//      textFeedback += (snder, evtargs) => { AppendRichtextbox(evtargs.FeedbackText); };
//      //MessageBox.Show(Environment.CommandLine);
//      //Process.Start(Environment.CommandLine.Replace(".vshost", ""));
//    }

//    private void AppendRichtextbox(string text)
//    {
//      ThreadingInterop.UpdateGuiFromThread(richTextBox1, delegate
//      {
//        richTextBox1.Text += (richTextBox1.Text.Length > 0 ? Environment.NewLine : "") + text;
//      });
//    }

//    public static string FolderToSaveIn = @"C:\Francois\other\Test\CS_TestListeningServerReceivedFiles";
//    public static int listeningPort = 11000;
//    public static int maxNumberPendingConnections = 100;
//    public static int receiveBufferSize = 1024 * 1024 * 10;
//    public static int maxFileSize = 1024 * 1024 * 1000;//10;
//    public static int maxTransferBuffer = 1024 * 1024 * 10;
//    Socket listeningSocket;// = null;
//    private void buttonServer_Click(object sender, EventArgs e)
//    {
//      //ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
//      //{
//      StartServer(listeningSocket);
//      //}, false);
//    }

//    public static void StartServer(Socket listeningSocketToUse)
//    {
//      ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
//      {
//        listeningSocketToUse = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        listeningSocketToUse.NoDelay = true;
//        listeningSocketToUse.Ttl = 112;
//        listeningSocketToUse.ReceiveBufferSize = receiveBufferSize;

//        string data = null;

//        listeningSocketToUse.Bind(NetworkInterop.GetLocalIPEndPoint(listeningPort));
//        listeningSocketToUse.Listen(maxNumberPendingConnections);

//        if (textFeedback != null)
//          textFeedback(null, new TextFeedbackEventArgs("Server started"));

//        // Start listening for connections.
//        while (true)
//        {
//          //Application.DoEvents();
//          //AppendRichTextBox("Waiting for a connection...");
//          // Program is suspended while waiting for an incoming connection.
//          Socket handler = null;
//          try
//          {
//            handler = listeningSocketToUse.Accept();
//          }
//          catch (SocketException sexc)
//          {
//            if (sexc.Message.ToLower().Contains("WSACancelBlockingCall".ToLower()))
//            {
//              /*
//               This is normal behavior when interrupting a blocking socket
//               (i.e. waiting for clients). WSACancelBlockingCall is called and a SocketException
//               is thrown (see my post above).
//               Just catch this exception and use it to exit the thread
//               ('break' in the infinite while loop).
//               http://www.switchonthecode.com/tutorials/csharp-tutorial-simple-threaded-tcp-server
//               */
//              break;
//            }
//            else
//            {
//              UserMessages.ShowErrorMessage("SocketException occurred: " + sexc.Message);
//            }
//          }

//          if (handler == null) continue;

//          Application.DoEvents();
//          data = null;
//          string startdata = "";

//          int maxProgress = 0;
//          Console.WriteLine("Data transfer started...");
//          // An incoming connection needs to be processed.
//          //SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, 0, 1000 * 1024 * 1024);
//          int totalbytelength = 0;
//          byte[] allbytes = new byte[maxFileSize];
//          while (true)
//          {
//            byte[] currentbytes;
//            int currbytelength = handler.Available;
//            totalbytelength += currbytelength;
//            if (maxProgress > 0 && totalbytelength >= 0 && totalbytelength <= maxProgress)
//              if (progressChanged != null)
//                progressChanged(null, new ProgressChangedEventArgs(totalbytelength / maxProgress));
//            //progressBar1.Value = progressBar1.Maximum * totalbytelength / maxProgress;
//            currentbytes = new byte[currbytelength];
//            int bytesRec = handler.Receive(currentbytes);
//            Console.WriteLine("Total bytes transferred: " + totalbytelength);
//            currentbytes.CopyTo(allbytes, totalbytelength - currbytelength);
//            data += Encoding.ASCII.GetString(currentbytes);

//            if (startdata.Length < 10000) startdata += data;
//            if (startdata.StartsWith("totalsize://"))
//            {
//              string totalSizeString = startdata.Substring(0, "totalsize://0000000000000000//:endoftotalsize".Length);
//              long Totalsize;
//              if (long.TryParse(totalSizeString.Substring(12, 16), out Totalsize))
//                if (maxProgress != Totalsize) maxProgress = (int)Totalsize;
//              totalSizeString = null;
//              Totalsize = 0;
//            }

//            if (data.IndexOf("<EOF>") > -1)
//            {
//              break;
//            }
//            if (data.Length > 10) data = data.Substring(data.Length - 10);

//            currbytelength = 0;
//            currentbytes = null;
//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//          }

//          Console.WriteLine("Data transfer complete.");

//          // Show the data on the console.
//          if (startdata.StartsWith("totalsize://"))
//          {
//            string totalSizeString = startdata.Substring(0, "totalsize://0000000000000000//:endoftotalsize".Length);
//            string originalFileName = startdata.Substring(totalSizeString.Length + "file://".Length, startdata.IndexOf("//:endoffile") - totalSizeString.Length - "file://".Length);
//            int filestringlength = "file://".Length + originalFileName.Length + "//:endoffile".Length;

//            byte[] filebytes = new byte[totalbytelength - totalSizeString.Length - filestringlength - 5];
//            for (int i = totalSizeString.Length + filestringlength; i < totalbytelength - 5; i++)
//              filebytes[i - totalSizeString.Length - filestringlength] = allbytes[i];

//            string newFileName = FolderToSaveIn + @"\" + Path.GetFileName(originalFileName);
//            Console.WriteLine("Original filename: " + originalFileName);
//            Console.WriteLine("New filename: " + newFileName);
//            Console.WriteLine("Writing file...");
//            File.WriteAllBytes(newFileName, filebytes);

//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            filestringlength = 0;
//            totalSizeString = null;
//            newFileName = null;
//            filebytes = null;
//            newFileName = null;

//            if (originalFileName.ToUpper().EndsWith(".final".ToUpper()))
//            {
//              string firstFilename = FolderToSaveIn + @"\" + Path.GetFileName(originalFileName).Substring(0, Path.GetFileName(originalFileName).Length - 6);
//              string finalFilename = firstFilename.Substring(0, firstFilename.LastIndexOf("."));
//              firstFilename = firstFilename.Substring(0, firstFilename.LastIndexOf(".")) + ".0";
//              NetworkInterop.MergeFiles(firstFilename);
//              System.Diagnostics.Process.Start("explorer", "/select," + finalFilename);
//            }

//            originalFileName = null;
//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//          }
//          else
//          {
//            Console.WriteLine(data.Replace("<EOF>", ""));
//          }

//          totalbytelength = 0;
//          maxProgress = 0;
//          allbytes = null;
//          data = null;
//          startdata = null;

//          handler.Shutdown(SocketShutdown.Both);
//          handler.Disconnect(false);
//          handler.Close();
//          handler.Dispose();

//          GC.Collect();
//          GC.WaitForPendingFinalizers();
//          Application.DoEvents();
//        }
//      }, false);
//    }

//    Socket senderSocket;
//    private void buttonClient_Click(object sender, EventArgs e)
//    {
//      TransferFile(@"F:\Series\The Big Bang Theory\Season 3\The.Big.Bang.Theory.S03E01.avi", senderSocket);
//    }

//    public static void TransferFile(string filePath, Socket senderSocketToUse)
//    {
//      byte[] byData;
//      if (!File.Exists(filePath))
//        UserMessages.ShowWarningMessage("File does not exist and cannot be transferred: " + filePath);
//      else
//      {
//        int counter = 0;
//        byte[] AllFileDataBytes = File.ReadAllBytes(filePath);

//        while (counter * maxTransferBuffer < AllFileDataBytes.Length)
//        {
//          if (ConnectToServer(senderSocketToUse))
//          {
//            string fileAddonExtension = ((counter + 1) * maxTransferBuffer) >= AllFileDataBytes.Length
//                ? "." + counter + ".final"
//                : "." + counter;
//            byte[] FileStartBytes = System.Text.Encoding.ASCII.GetBytes("file://" + filePath + fileAddonExtension + "//:endoffile");

//            long PieceSize = AllFileDataBytes.Length - (counter * maxTransferBuffer) < maxTransferBuffer
//                ? AllFileDataBytes.Length - (counter * maxTransferBuffer)
//                : maxTransferBuffer;

//            byte[] FileDataPieceBytes = new byte[PieceSize];
//            for (int i = counter * maxTransferBuffer; i < (counter + 1) * maxTransferBuffer && i < AllFileDataBytes.Length; i++)
//              FileDataPieceBytes[i - counter * maxTransferBuffer] = AllFileDataBytes[i];

//            byte[] EOFbytes = System.Text.Encoding.ASCII.GetBytes("<EOF>");

//            int TotalByteCount = Encoding.ASCII.GetBytes("totalsize://0000000000000000//:endoftotalsize").Length
//              + FileStartBytes.Length + FileDataPieceBytes.Length + EOFbytes.Length;

//            byte[] TotalByteCountBytes = Encoding.ASCII.GetBytes("totalsize://" + Get16lengthStringOfNumber(TotalByteCount) + "//:endoftotalsize");

//            byData = new byte[TotalByteCount];
//            TotalByteCountBytes.CopyTo(byData, 0);
//            FileStartBytes.CopyTo(byData, TotalByteCountBytes.Length);
//            FileDataPieceBytes.CopyTo(byData, TotalByteCountBytes.Length + FileStartBytes.Length);
//            EOFbytes.CopyTo(byData, TotalByteCountBytes.Length + FileStartBytes.Length + FileDataPieceBytes.Length);

//            senderSocketToUse.Send(byData);
//            PieceSize = 0;
//            TotalByteCount = 0;
//            fileAddonExtension = null;
//            FileStartBytes = null;
//            FileDataPieceBytes = null;
//            EOFbytes = null;
//            TotalByteCountBytes = null;

//            senderSocketToUse.Close();
//            senderSocketToUse.Dispose();
//            senderSocketToUse = null;

//            counter++;
//          }
//        }

//        counter = 0;
//        AllFileDataBytes = null;
//      }
//    }

//    private void TransferText(string text)
//    {
//      byte[] byData;
//      byData = System.Text.Encoding.ASCII.GetBytes(text + "<EOF>");

//      senderSocket.Close();
//      senderSocket.Dispose();
//      senderSocket = null;

//      byData = null;
//      GC.Collect();
//      GC.WaitForPendingFinalizers();
//    }

//    public static string Get16lengthStringOfNumber(long longIn)
//    {
//      string tmpstr = longIn.ToString();
//      while (tmpstr.Length < 16) tmpstr = "0" + tmpstr;
//      return tmpstr;
//    }

//    public static bool ConnectToServer(Socket socketToInitialize)
//    {
//      try
//      {
//        socketToInitialize = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        socketToInitialize.ReceiveTimeout = 1000;
//        socketToInitialize.SendTimeout = 1000;
//        socketToInitialize.NoDelay = true;
//        socketToInitialize.Ttl = 112;
//        socketToInitialize.SendBufferSize = 1024 * 1024 * 10;
//        socketToInitialize.BeginConnect_Ext(NetworkInterop.GetLocalIPEndPoint(11000));
//        return true;
//      }
//      catch (SocketException se)
//      {
//        MessageBox.Show("SocketException BeginConnect_Ext()" + se.Message + Environment.NewLine + se.TargetSite);
//        return false;
//      }
//    }

//    private void Form1_Load(object sender, EventArgs e)
//    {
//      if (Environment.CommandLine.Contains(".vshost"))
//        Process.Start(@"C:\Users\francois\Documents\Visual Studio 2010\Projects\TestingSharedClasses\TestingSharedClasses\bin\Release\TestingSharedClasses.exe");
//    }

//    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
//    {
//      if (listeningSocket != null)// && listeningSocket.Connected)
//      {
//        listeningSocket.Blocking = false;
//        listeningSocket.Close();
//      }
//    }
//  }
//}
