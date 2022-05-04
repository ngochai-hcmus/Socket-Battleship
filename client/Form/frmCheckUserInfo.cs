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
    public partial class frmCheckUserInfo : Form
    {
        public static TextBox txbName;
        public static Label lbGender;
        public static Label lbStatus;
        public static DateTimePicker dtpBirthday;
        //public static PictureBox ptbAvatar;
        public static TextBox txbNote;
        public static Label lbWinScore;
        public static Label lbCloseScore;

        public frmCheckUserInfo()
        {
            InitializeComponent();
        }

        private void frmCheckUserInfo_Shown(object sender, EventArgs e)
        {
            txbName = new TextBox();
            txbName.Location = new Point(110, 146);
            txbName.Width = 185;
            txbName.Height = 20;
            txbName.Font = new Font("Times New Roman", 12, FontStyle.Regular);

            lbStatus = new Label();
            lbStatus.Location = new Point(110, 77);
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Times New Roman", 10, FontStyle.Regular);

            lbWinScore = new Label();
            lbWinScore.Location = new Point(110, 102);
            lbWinScore.AutoSize = true;
            lbWinScore.Font = new Font("Times New Roman", 10, FontStyle.Regular);

            lbCloseScore = new Label();
            lbCloseScore.Location = new Point(110, 125);
            lbCloseScore.AutoSize = true;
            lbCloseScore.Font = new Font("Times New Roman", 10, FontStyle.Regular);

            lbGender = new Label();
            lbGender.Location = new Point(110, 177);
            lbGender.AutoSize = true;
            lbGender.Font = new Font("Times New Roman", 10, FontStyle.Regular);

            dtpBirthday = new DateTimePicker();
            dtpBirthday.Location = new Point(110, 229);
            dtpBirthday.Width = 200;
            dtpBirthday.Height = 20;
            dtpBirthday.Font = new Font("Times New Roman", 10, FontStyle.Regular);

            txbNote = new TextBox();
            txbNote.Location = new Point(110, 267);
            txbNote.Width = 338;
            txbNote.Height = 70;
            txbNote.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            txbNote.Multiline = true;

            /*ptbAvatar = new PictureBox();
            ptbAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            ptbAvatar.Location = new Point(307, 38);
            ptbAvatar.Width = 150;
            ptbAvatar.Height = 160;
            ptbAvatar.BackColor = Color.White;*/

            this.Controls.Add(txbName);
            this.Controls.Add(lbStatus);
            this.Controls.Add(lbGender);
            this.Controls.Add(dtpBirthday);
            this.Controls.Add(txbNote);
            //this.Controls.Add(ptbAvatar);
            this.Controls.Add(lbCloseScore);
            this.Controls.Add(lbWinScore);
        }

        private void btnCheckInfo_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Bạn hãy nhập tên user mà bạn muốn tìm");
                return;
            }

            SocketData data;
            data = new SocketData("", (int)SocketCommand.CHECK_INFO, txbUserName.Text, "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btnCheckName_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Bạn hãy nhập tên user mà bạn muốn tìm");
                return;
            }

            SocketData data;
            data = new SocketData("", (int)SocketCommand.CHECK_INFO_NAME, txbUserName.Text, "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btnCheckBirthday_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Bạn hãy nhập tên user mà bạn muốn tìm");
                return;
            }

            SocketData data;
            data = new SocketData("", (int)SocketCommand.CHECK_INFO_BIRTHDAY, txbUserName.Text, "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btncheckOnline_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Bạn hãy nhập tên user mà bạn muốn tìm");
                return;
            }

            SocketData data;
            data = new SocketData("", (int)SocketCommand.CHECK_INFO_ONLINE, txbUserName.Text, "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btnCheckNote_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Bạn hãy nhập tên user mà bạn muốn tìm");
                return;
            }

            SocketData data;
            data = new SocketData("", (int)SocketCommand.CHECK_INFO_NOTE, txbUserName.Text, "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void btnCheckScore_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Bạn hãy nhập tên user mà bạn muốn tìm");
                return;
            }

            SocketData data;
            data = new SocketData("", (int)SocketCommand.CHECK_INFO_SCORE, txbUserName.Text, "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        public void CheckUser(string userName)
        {
            txbUserName.Text = userName;
            btnCheckInfo_Click(new object(), new EventArgs());
        }

        public static void ShowInfo(User user, string status)
        {
            Thread.Sleep(500);
            txbName.Text = user.Name;
            lbGender.Text = user.Gender;
            lbStatus.Text = status;
            txbNote.Text = user.Note;
            dtpBirthday.Text = user.Birthday;
            //ptbAvatar.BackgroundImage = user.Avatar;
            lbCloseScore.Text = user.closeScore;
            lbWinScore.Text = user.winScore;
        }

        public static void ShowInfoName(User user, string status)
        {
            txbName.Text = user.Name;
            lbGender.Text = "";
            lbStatus.Text = "";
            txbNote.Text = "";
            dtpBirthday.Text = "";
            //ptbAvatar.BackgroundImage = null;
            lbCloseScore.Text = "";
            lbWinScore.Text = "";
        }

        public static void ShowInfoBirthday(User user, string status)
        {
            txbName.Text = "";
            lbGender.Text = "";
            lbStatus.Text = "";
            txbNote.Text = "";
            dtpBirthday.Text = user.Birthday;
            //ptbAvatar.BackgroundImage = null;
            lbCloseScore.Text = "";
            lbWinScore.Text = "";
        }

        public static void ShowInfoNote(User user, string status)
        {
            txbName.Text = "";
            lbGender.Text = "";
            lbStatus.Text = "";
            txbNote.Text = user.Note;
            dtpBirthday.Text = "";
            //ptbAvatar.BackgroundImage = null;
            lbCloseScore.Text = "";
            lbWinScore.Text = "";
        }

        public static void ShowInfoOnline(User user, string status)
        {
            txbName.Text = "";
            lbGender.Text = "";
            lbStatus.Text = status;
            txbNote.Text = "";
            dtpBirthday.Text = "";
            //ptbAvatar.BackgroundImage = null;
            lbCloseScore.Text = "";
            lbWinScore.Text = "";
        }

        public static void ShowInfoScore(User user, string status)
        {
            txbName.Text = "";
            lbGender.Text = "";
            lbStatus.Text = "";
            txbNote.Text = "";
            dtpBirthday.Text = "";
            //ptbAvatar.BackgroundImage = null;
            lbCloseScore.Text = user.closeScore;
            lbWinScore.Text = user.winScore;
        }

        private void btnInviteGame_Click(object sender, EventArgs e)
        {
            if(txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Nhập tên tài khoản mà bạn muốn gửi lời mời");
                return;
            }
            if (txbUserName.Text == UserManager.user.UserName)
            {
                MessageBox.Show("Bạn đang mời chính mình??");
                return;
            }

            SocketData data;
            data = new SocketData(UserManager.user.Name,
                (int)SocketCommand.INVITE_GAME, UserManager.user.UserName, txbUserName.Text, new Point());
            SocketManager.Send(SocketManager.client, data);
        }
    }
}
