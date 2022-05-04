using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    public partial class frmPlay : Form
    {
        public frmPlay()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            
            SetUp();
        }

        public void SetUp()
        {
            UserManager.SetUp();
            this.Controls.Add(UserManager.lstMessage);
            this.pnlMyUser.Controls.Add(UserManager.lbMyUser);
            this.pnlOtherUser.Controls.Add(UserManager.lbOtherUser);
            this.pnlMyUser.Controls.Add(UserManager.ptbMyAvt);
            this.pnlOtherUser.Controls.Add(UserManager.ptbOtherAvt);

            GameManager.SetUp();
            this.Controls.Add(GameManager.pnlMyFightingPlace);
            this.Controls.Add(GameManager.pnlOtherFightingPlace);
            this.Controls.Add(GameManager.lbStatus);
            this.pnlMyUser.Controls.Add(GameManager.lbMyScore);
            this.pnlOtherUser.Controls.Add(GameManager.lbOtherScore);
        }

        public frmPlay(string ID, User otherUser) : this()
        {
            GameManager.RoomID = ID;
            lbRoomID.Text = ID;

            UserManager.OtherUser = otherUser;
            UserManager.lbOtherUser.Text = otherUser.Name;
            //if (otherUser.Avatar != null)
                //UserManager.ptbOtherAvt.BackgroundImage = otherUser.Avatar;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            SocketData data = new SocketData("", (int)SocketCommand.NEW_GAME, lbRoomID.Text, "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có muốn rời khỏi phòng?", "Thoát", MessageBoxButtons.YesNo);
            if (d == DialogResult.No)
                e.Cancel = true;
            else
            {
                this.Controls.Remove(GameManager.pnlMyFightingPlace);
                this.Controls.Remove(GameManager.pnlOtherFightingPlace);
                this.Controls.Remove(GameManager.lbStatus);
                SocketData data = new SocketData("", (int)SocketCommand.EXIT_ROOM, lbRoomID.Text, "", new Point());
                SocketManager.Send(SocketManager.client, data);
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (!GameManager.Ready()) return;

            SocketData data = new SocketData("", (int)SocketCommand.START_GAME, lbRoomID.Text, "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            if (txbMessage.Text == string.Empty) return;
            if (txbMessage.Text.Length > 500)
            {
                MessageBox.Show("Tin Nhắn quá dài không gửi được");
                return;
            }
            UserManager.AddMessage(UserManager.user.UserName, txbMessage.Text);

            SocketData data;
            data = new SocketData(UserManager.user.UserName, 
                (int)SocketCommand.SEND_MESSAGE, txbMessage.Text, lbRoomID.Text, new Point());
            SocketManager.Send(SocketManager.client, data);

            txbMessage.Clear();
        }
    }
}
