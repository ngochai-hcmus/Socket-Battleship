using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    public partial class frmClient : Form
    {
        bool Connected = false;

        public frmClient()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void frmClient_Shown(object sender, EventArgs e)
        {
            pnlClient.Hide();
            pnlLogin.Show();
            this.AcceptButton = btnConnect;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SocketManager.IPAddressServer = txbIPAddress.Text;

            if (SocketManager.ConnectServer())
            {
                MessageBox.Show("Kết nối thành công");
            }
            else
            {
                //MessageBox.Show("Không kết nối được server");
                return;
            }

            this.AcceptButton = btnLogin;
            Connected = true;

            Thread ListenThread = new Thread(Listen);
            ListenThread.IsBackground = true;
            ListenThread.Start(SocketManager.client);
        }

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
                    ProcessData(data);
                }
            }
            catch
            {
                SocketManager.Close();
            }
        }


        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.ENTERED_THE_ROOM:
                    Show_FormPlay(data.Message1, data.User);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    GameManager.NewGame();
                    break;
                case (int)SocketCommand.START_GAME:
                    GameManager.StartGame(data.Message1);
                    break;
                case (int)SocketCommand.ATTACK:
                    GameManager.Attack(data.Point);
                    break;
                case (int)SocketCommand.ATTACK_INFO:
                    GameManager.AttackInfo(data);
                    break;
                case (int)SocketCommand.SEND_MESSAGE:
                    UserManager.AddMessage(data.ThisUser, data.Message1);
                    break;
                case (int)SocketCommand.UPDATE_STATUS:
                    GameManager.UpdateStatus(data.Message1);
                    break;
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message1, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case (int)SocketCommand.OTHER_USER:
                    UserManager.UpdateUser(data.User);
                    break;
                case (int)SocketCommand.LOG_IN:
                    AcceptedLogin(data.User);
                    break;
                case (int)SocketCommand.CHECK_INFO:
                    frmCheckUserInfo.ShowInfo(data.User, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_NAME:
                    frmCheckUserInfo.ShowInfoName(data.User, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_NOTE:
                    frmCheckUserInfo.ShowInfoNote(data.User, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_BIRTHDAY:
                    frmCheckUserInfo.ShowInfoBirthday(data.User, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_ONLINE:
                    frmCheckUserInfo.ShowInfoOnline(data.User, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_INFO_SCORE:
                    frmCheckUserInfo.ShowInfoScore(data.User, data.Message1);
                    break;
                case (int)SocketCommand.CHECK_USER_ONLINE:
                    frmListUserOnline.ShowListUserOnline(data.ListUser);
                    break;
                case (int)SocketCommand.INVITE_GAME:
                    UserManager.InviteGame(data.ThisUser, data.Message1);
                    break;
                default:
                    break;
            }
        }

        private void AcceptedLogin(User user)
        {
            this.Text = "Chúc bạn chơi game vui vẻ";
            this.AcceptButton = btnJoinRoom;
            lbUserName.Text = "Chào " + user.Name;
            lbUserName.Left = (pnlClient.Width - lbUserName.Width) / 2;
            lbWish.Left = (pnlClient.Width - lbWish.Width) / 2;
            pnlClient.Show();
            pnlLogin.Hide();

            UserManager.user = user;
        }

        private void Show_FormPlay(string RoomID, User user)
        {
            Thread ShowForm_Thread = new Thread(() =>
            {
                frmPlay frm = new frmPlay(RoomID, user);
                this.Hide();
                frm.FormClosed += Frm_FormClosed;
                frm.ShowDialog();
            });
            ShowForm_Thread.IsBackground = true;
            ShowForm_Thread.Start();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            if (txbRoomID.Text.Length == 0)
            {
                MessageBox.Show("Mời nhập mã phòng bạn muốn");
                return;
            }
            SocketData data;
            data = new SocketData(UserManager.user.UserName, (int)SocketCommand.JOIN_ROOM, txbRoomID.Text, "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            SocketData data;
            data = new SocketData(UserManager.user.UserName, (int)SocketCommand.CREATE_ROOM, "", "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btnShowPassWord_Click(object sender, EventArgs e)
        {
            if (txbPassWord.PasswordChar == '*')
            {
                txbPassWord.PasswordChar = '\0';
                btnShowPassWord.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\CloseEye.png");
            }
            else
            {
                btnShowPassWord.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\OpenEye.png");
                txbPassWord.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                MessageBox.Show("Bạn cần kết nối với server");
                return;
            }

            if (txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Hãy nhập tên tài khoản");
                return;
            }
            if (txbPassWord.Text == string.Empty)
            {
                MessageBox.Show("Hãy nhập mật khẩu của bạn");
                return;
            }

            string user = txbUserName.Text;
            string pass = txbPassWord.Text;
            string isEncrypt = "false";

            if (cbEncrypt.Checked)
            {
                user = UserManager.Encrypt(user);
                pass = UserManager.Encrypt(pass);
                isEncrypt = "true";
            }

            SocketData data;
            data = new SocketData(isEncrypt, (int)SocketCommand.LOG_IN, user, pass, new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                MessageBox.Show("Bạn cần kết nối với server");
                return;
            }
            frmRegister frm = new frmRegister();
            this.Hide();
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            frmChangeInfo frm = new frmChangeInfo();
            this.Hide();
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            frmCheckUserInfo frm = new frmCheckUserInfo();
            this.Hide();
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

        private void btnUserOnline_Click(object sender, EventArgs e)
        {
            frmListUserOnline frm = new frmListUserOnline();
            this.Hide();
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

    }
}
