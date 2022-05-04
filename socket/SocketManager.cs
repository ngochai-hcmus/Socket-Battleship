using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    class SocketManager
    {
        #region Server
        public static Socket server;
        public static List<Socket> clientList;
        public static List<Socket> queueClientList;
        public static Dictionary<Socket, string> userList = new Dictionary<Socket, string>();
        public static Dictionary<string, Socket> socketList = new Dictionary<string, Socket>();

        //Tạo server
        public static void CreateServer()
        {
            isServer = true;

            clientList = new List<Socket>();
            queueClientList = new List<Socket>();

            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            Thread AcceptClient = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);
                        queueClientList.Add(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            AcceptClient.IsBackground = true;
            AcceptClient.Start();
        }

        //kiểm tra socket còn kết nối hay không
        //https://stackoverflow.com/questions/2661764/how-to-check-if-a-socket-is-connected-disconnected-in-c
        private static bool IsSocketConnected(Socket s)
        {
            return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
        }

        public static void updateUser()
        {
            Socket item;
            int n = clientList.Count;
            for (int i = 0; i < n; ++i)
            {
                item = clientList[i];
                if (!IsSocketConnected(item))
                {
                    if (userList.ContainsKey(item))
                    {
                        socketList.Remove(userList[item]);
                        userList.Remove(item);
                    }

                    clientList.Remove(item);
                    --i; --n;
                }
            }
        }
        #endregion


        //===================
        #region Client
        public static Socket client;

        //kết nối server
        public static bool ConnectServer()
        {
            isServer = false;

            IP = new IPEndPoint(IPAddress.Parse(IPAddressServer), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                DialogResult dialogResult = MessageBox.Show("Không kết nối được server!");
                return false;
            }
            return true;
        }
        #endregion


        //===================

        #region Both server and client
        public static string IPAddressServer = "127.0.0.1";
        public int PORT = 9999;
        private static IPEndPoint IP;
        private static bool isServer;

        //Đóng kết nối
        public static void Close()
        {
            if (isServer) server.Close();
            else client.Close();
        }

        //Phân mảnh
        public static byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        //Gom mảnh
        public static object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            stream.Position = 0;
            return formatter.Deserialize(stream);
        }

        //gửi tin
        public static bool Send(Socket target, object data)
        {
            byte[] sendData = Serialize(data);

            return (target.Send(sendData) == 1) ? true : false;
        }

        //nhận tin
        public static object Receive(object obj)
        {
            Socket client = obj as Socket;
            byte[] receiveData = new byte[1024 * 5];
            client.Receive(receiveData);

            return Deserialize(receiveData);
        }

        public static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
        #endregion

    }
}
