using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class Form1 : Form
    {
        Socket server = null;
        Socket client = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (server != null && server.Connected)
                server.Disconnect(false);

            server = new Socket(AddressFamily.InterNetwork,
                     SocketType.Stream, ProtocolType.Tcp);
            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 12345);

            try
            {
                server.Bind(endPoint);
                server.Listen(100);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Невозможно запустить сервер " + exc.Message);
                return;
            }

            server.BeginAccept(new AsyncCallback(AsyncAcceptCallback), server);
        }

        void AsyncAcceptCallback(IAsyncResult result)
        {
            Socket serverSocket = (Socket)result.AsyncState;

            SocketData data = new SocketData();
            data.ClientConnection = serverSocket.EndAccept(result);

            data.ClientConnection.BeginReceive(data.Buffer, 0,
                     1024, SocketFlags.None,
                     new AsyncCallback(ReadCallback), data);
        }

        void ReadCallback(IAsyncResult result)
        {
            SocketData data = (SocketData)result.AsyncState;
            int bytes = data.ClientConnection.EndReceive(result);

            if (bytes > 0)
            {
                string s = Encoding.UTF8.GetString(data.Buffer, 0, bytes);
                data.ClientConnection.Send(
                      Encoding.UTF8.GetBytes("Получено: " +
                      s.Length + " символов"));
            }
        }

        public IPAddress GetAddress(string address)
        {
            IPAddress ipAddress = null;
            try
            {
                ipAddress = IPAddress.Parse(address);
            }
            catch (Exception)
            {
                IPHostEntry heserver;

                try
                {
                    heserver = Dns.GetHostEntry(address);
                    if (heserver.AddressList.Length == 0)
                    {
                        return null;
                    }
                    ipAddress = heserver.AddressList[0];
                }
                catch
                {
                    return null;
                }
            }
            return ipAddress;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
                client.Disconnect(false);

            IPAddress addr = GetAddress(serverAddressTextBox.Text);
            if (addr == null)
            {
                MessageBox.Show("Я в шоке, не смог разобрать адрес");
                return;
            }
            client = new Socket(AddressFamily.InterNetwork,
                   SocketType.Stream, ProtocolType.Tcp);
            EndPoint point = new IPEndPoint(addr, 12345);
            try
            {
                client.Connect(point);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка соединения: " + exc.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Сначала соединитесь с сервером");
                return;
            }
            client.Send(Encoding.ASCII.GetBytes(
               commandTextBox.Text));

            byte[] buffer = new byte[1024];
            int bytes = client.Receive(buffer);
            if (bytes > 0)
            {
                string s = Encoding.UTF8.GetString(buffer, 0, bytes);
                clientRichTextBox.AppendText(s + "\n");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    class SocketData
    {
        public const int BufferSize = 1024;
        public Socket ClientConnection { get; set; }

        byte[] buffer = new byte[BufferSize];

        public byte[] Buffer {
            get { return buffer; }
            set { buffer = value; }
        }
    }

}
