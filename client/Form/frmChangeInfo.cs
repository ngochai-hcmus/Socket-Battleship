using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    public partial class frmChangeInfo : Form
    {
        public frmChangeInfo()
        {
            InitializeComponent();
        }

        private void frmChangeInfo_Shown(object sender, EventArgs e)
        {
            dtpBirthDay.Text = "Friday, September 13, 2002";
            if (!rdbFemale.Checked && !rdbMale.Checked)
                rdbMale.Checked = true;
            lbUserName.Text = UserManager.user.UserName;

            txbName.Text = UserManager.user.Name;
            if (UserManager.user.Gender == "male")
            {
                rdbMale.Checked = true;
                rdbFemale.Checked = false;
            }
            else
            {
                rdbMale.Checked = false;
                rdbFemale.Checked = true;
            }
            dtpBirthDay.Text = UserManager.user.Birthday;
            txbNote.Text = UserManager.user.Note;

            //ptbAvt.BackgroundImage = UserManager.user.Avatar;
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

        private void btnShowNewPass_Click(object sender, EventArgs e)
        {
            if (txbNewPassWord.PasswordChar == '*')
            {
                txbNewPassWord.PasswordChar = '\0';
                btnShowNewPass.BackgroundImage =
                    Image.FromFile(Application.StartupPath + "\\Resources\\CloseEye.png");
            }
            else
            {
                btnShowNewPass.BackgroundImage =
                    Image.FromFile(Application.StartupPath + "\\Resources\\OpenEye.png");
                txbNewPassWord.PasswordChar = '*';
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txbPassWord.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu để thực hiện thao tác này");
                return;
            }
            if(txbName.Text == string.Empty)
            {
                MessageBox.Show("Không được để trống họ tên");
                return;
            }

            User newUser = new User();

            newUser = UserManager.user;
            //newUser.Avatar = ptbAvt.BackgroundImage;
            newUser.PassWord = (txbNewPassWord.Text != string.Empty) ? txbNewPassWord.Text : txbPassWord.Text;
            newUser.Name = txbName.Text;
            newUser.Gender = (rdbMale.Checked) ? "male" : "female";
            newUser.Birthday = dtpBirthDay.Text;
            newUser.Note = txbNote.Text;
            string password = txbPassWord.Text;

            if(cbEncrypt.Checked)
            {
                newUser.isEncrypt = true;
                newUser.UserName = UserManager.Encrypt(newUser.UserName);
                newUser.PassWord = UserManager.Encrypt(newUser.PassWord);
                password = UserManager.Encrypt(password);
            }

            SocketData data;
            data = new SocketData((int)SocketCommand.UPDATE_USER, newUser, password);
            SocketManager.Send(SocketManager.client, data);

            if (cbEncrypt.Checked)
            {
                newUser.isEncrypt = false;
                newUser.UserName = UserManager.Decrypt(newUser.UserName);
                newUser.PassWord = UserManager.Decrypt(newUser.PassWord);
                password = UserManager.Decrypt(password);
            }
        }
    }
}
