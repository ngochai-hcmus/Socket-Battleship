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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Shown(object sender, EventArgs e)
        {
            dtpBirthDay.Text = "Friday, September 13, 2002";
            if (!rdbFemale.Checked && !rdbMale.Checked)
                rdbMale.Checked = true;
        }

        private void btnShowPassWord_Click(object sender, EventArgs e)
        {
            if (txbPassWord.PasswordChar == '*')
            {
                txbPassWord.PasswordChar = '\0';
                btnShowPassWord.BackgroundImage = 
                    Image.FromFile(Application.StartupPath + "\\Resources\\CloseEye.png");
            }
            else
            {
                btnShowPassWord.BackgroundImage = 
                    Image.FromFile(Application.StartupPath + "\\Resources\\OpenEye.png");
                txbPassWord.PasswordChar = '*';
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty)
            {
                MessageBox.Show("Hãy điền họ tên của bạn");
                return;
            }
            if(txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Hãy điền tên tài khoản của bạn");
                return;
            }
            if(txbPassWord.Text == string.Empty)
            {
                MessageBox.Show("Hãy điền tên mật khẩu của bạn");
                return;
            }
            /*if(ptbAvt.BackgroundImage == null)
            {
                MessageBox.Show("Hãy thêm ảnh đại diện của bạn");
                return;
            }*/

            User newUser = new User();
            //newUser.Avatar = ptbAvt.BackgroundImage;
            newUser.Name = txbName.Text;
            newUser.Gender = (rdbMale.Checked) ? "male" : "female";
            newUser.Birthday = dtpBirthDay.Text;
            newUser.UserName = txbUserName.Text;
            newUser.PassWord = txbPassWord.Text;
            newUser.Note = txbNote.Text;

            if(cbEncrypt.Checked)
            {
                newUser.UserName = UserManager.Encrypt(newUser.UserName);
                newUser.PassWord = UserManager.Encrypt(newUser.PassWord);
                newUser.isEncrypt = true;
            }

            SocketData data;
            data = new SocketData((int)SocketCommand.REGISTER, newUser);
            SocketManager.Send(SocketManager.client, data);
        }
    }
}
