using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void frmServer_Shown(object sender, EventArgs e)
        {
            txbIPAddress.Text = SocketManager.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(txbIPAddress.Text))
            {
                txbIPAddress.Text = SocketManager.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
            
            SocketManager.CreateServer();

            Thread Listen_ = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        int n = SocketManager.queueClientList.Count;
                        Socket item;
                        for (int i = 0; i < n; ++i)
                        {
                            item = SocketManager.queueClientList[i];
                            Thread ListenThread = new Thread(Listen);
                            ListenThread.IsBackground = true;
                            ListenThread.Start(item);
                            SocketManager.queueClientList.Remove(item);
                            --i; --n;
                        }
                    }
                }
                catch
                {
                    //SocketManager.IP = new IPEndPoint(IPAddress.Any, 9999);
                    //server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen_.IsBackground = true;
            Listen_.Start();

            Thread DataUpdate = new Thread(() =>
            {
                List<User> data = new List<User>();
                DataTable dataTable = new DataTable();
            
                dataTable = CreateDataTable(data);
                dgvData.DataSource = dataTable;

                /*DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                picCol = (DataGridViewImageColumn)dgvData.Columns[5];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;*/

                dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvData.ColumnHeadersHeight = 60;

                while (true)
                {
                    SocketManager.updateUser();
                    Thread.Sleep(5000);
                }
            });
            DataUpdate.IsBackground = true;
            DataUpdate.Start();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<User> data = new List<User>();
            DataTable dataTable = new DataTable();

            foreach (Socket item in SocketManager.clientList)
            {
                if (SocketManager.userList.ContainsKey(item))
                {
                    data.Add(DataManager.GetInfo(SocketManager.userList[item]));
                }
            }
            dataTable = CreateDataTable(data);
            dgvData.DataSource = dataTable;
        }

        //=================
        private DataTable CreateDataTable(IList<User> item)
        {
            Type type = typeof(User);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (User entity in item)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        //=============== 

        void Listen(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] receiveData = new byte[1024 * 20000];
                    client.Receive(receiveData);

                    SocketData data = (SocketData)SocketManager.Deserialize(receiveData);
                    ProcessData(client, data);
                }
            }
            catch
            {
                SocketManager.updateUser();
            }
        }

        private void ProcessData(Socket target, SocketData data)
        {
            //MessageBox.Show("Nhận được thông tin từ client");
            switch (data.Command)
            {
                case (int)SocketCommand.CREATE_ROOM:
                    ClientManager.CreateRoom(target, data.ThisUser);
                    break;
                case (int)SocketCommand.JOIN_ROOM:
                    ClientManager.JoinRoom(target, data.Message1, data.ThisUser);
                    break;
                case (int)SocketCommand.EXIT_ROOM:
                    ClientManager.ExitRoom(target, data.Message1);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    ClientManager.NewGame(target, data.Message1);
                    break;
                case (int)SocketCommand.START_GAME:
                    ClientManager.StartGame(target, data.Message1);
                    break;
                case (int)SocketCommand.ATTACK:
                    ClientManager.Attack(target, data.Message1, data.Point);
                    break;
                case (int)SocketCommand.ATTACK_INFO:
                    ClientManager.AttackInfo(target, data);
                    break;
                case (int)SocketCommand.UPDATE_SCORE:
                    ClientManager.UpdateScore(target, data.ThisUser, data.Message1, data.Message2);
                    break;
                case (int)SocketCommand.SEND_MESSAGE:
                    ClientManager.SendMessage(target, data);
                    break;
                case (int)SocketCommand.LOG_IN:
                    ClientManager.Login(target, data.ThisUser, data.Message1, data.Message2);
                    break;
                case (int)SocketCommand.REGISTER:
                    ClientManager.Register(target, data.User);
                    break;
                case (int)SocketCommand.UPDATE_USER:
                    ClientManager.UpdateUser(target, data.User, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO:
                    ClientManager.CheckInfo(target, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_NAME:
                    ClientManager.CheckInfoName(target, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_BIRTHDAY:
                    ClientManager.CheckInfoBirthday(target, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_ONLINE:
                    ClientManager.CheckInfoOnline(target, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_SCORE:
                    ClientManager.CheckInfoScore(target, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_NOTE:
                    ClientManager.CheckInfoNote(target, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_USER_ONLINE:
                    ClientManager.CheckUserOnline(target);
                    break;
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message1, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case (int)SocketCommand.INVITE_GAME:
                    ClientManager.InviteGame(target, data.ThisUser, data.Message1, data.Message2);
                    break;
                case (int)SocketCommand.ACCEPTED_INVITE_GAME:
                    ClientManager.AcceptedInviteGame(target, data.Message1, data.Message2);
                    break;
                default:
                    break;
            }
        }

    }
}
