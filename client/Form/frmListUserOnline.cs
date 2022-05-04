using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    public partial class frmListUserOnline : Form
    {
        public static ListBox lstUserOnline;

        public frmListUserOnline()
        {
            InitializeComponent();
        }

        private void frmListUserOnline_Shown(object sender, EventArgs e)
        {
            lstUserOnline = new ListBox();
            lstUserOnline.Location = new Point(12, 36);
            lstUserOnline.Width = 425;
            lstUserOnline.Height = 560;
            lstUserOnline.MouseDoubleClick += LstUserOnline_MouseDoubleClick;
            lstUserOnline.Font = new Font("Times New Roman", 20, FontStyle.Regular);
            this.Controls.Add(lstUserOnline);

            SocketData data = new SocketData("", (int)SocketCommand.CHECK_USER_ONLINE, "", "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        private void LstUserOnline_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string text = lstUserOnline.GetItemText(lstUserOnline.SelectedItem);

            if (text == string.Empty) return;

            frmCheckUserInfo frm = new frmCheckUserInfo();
            frm.CheckUser(text);
            frm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SocketData data = new SocketData("", (int)SocketCommand.CHECK_USER_ONLINE, "", "", new Point());
            SocketManager.Send(SocketManager.client, data);
        }

        public static void ShowListUserOnline(List<User> lstUser)
        {
            lstUserOnline.Items.Clear();
            foreach(User item in lstUser)
            {
                lstUserOnline.Items.Add(item.UserName);
            }
        }
    }
}
