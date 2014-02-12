using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PolvakServer
{
    class TCPServer
    {
        TcpListener tcpListener;
        Thread listenThread;

        // TODO: добавить евент на добавление нового клиента

        public static List<ServerData> Clients = new List<ServerData>();
        public delegate void ClientConnect(bool state);
        public event ClientConnect ClientConnectEx;

        // Инициализатор сервера
        public TCPServer(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, port);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.IsBackground = true;
            this.listenThread.Start();
        }

        // Процес приёмника соединений
        private void ListenForClients()
        {
            tcpListener.Start();
            while (true) // Принимаем запросы на подключение
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                //create a thread to handle communication 
                //with connected client
                HandleClientComm(client);
            }
        }

        // Один процесс на каждого пользователя
        private void HandleClientComm(object client)
        {
            ServerData sd = new ServerData((TcpClient)client);
            sd.ClientConectEx += sd_ClientConectEx;
        }

        void sd_ClientConectEx(bool state)
        {
            if (ClientConnectEx != null) ClientConnectEx(state);
        }
    }

    public class ServerData
    {
        public delegate void ReciveData(byte[] data,int datalengh,ServerData Client);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
        public event ReciveData Recive;

        public delegate void ClientConect(bool state);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
        public event ClientConect ClientConectEx;

        public TcpClient client;
        public NetworkStream clientStream ;
        byte[] message = new byte[4096];
        int bytesRead;
        public IPEndPoint ClientInfo;

        public ServerData(TcpClient client)
        {
            new Thread(delegate()
            {
                this.client = client;
                clientStream = client.GetStream();
                ClientInfo = client.Client.LocalEndPoint as IPEndPoint;
                Work();
            }) { IsBackground = true }.Start();
        }

        public void SendMessage(byte[] data)
        {
            if (client == null) return;
            client.Client.Send(data);
        }

        public void Work()
        {
            TCPServer.Clients.Add(this);
            if (ClientConectEx != null) ClientConectEx(true);
            while (true)
            {
                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                    if (Recive != null) Recive(message,bytesRead,this);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }
            }
            client.Close();
            if (ClientConectEx != null) ClientConectEx(false);
            TCPServer.Clients.Remove(this);
        }
    }
}
