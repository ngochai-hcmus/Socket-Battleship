using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SeaFight
{
    public class UserManager
    {
        public static ListBox lstMessage;
        //public static string UserName = "";
        public static User user = new User();
        public static User OtherUser = new User();
        public static Label lbMyUser;
        public static Label lbOtherUser;
        public static PictureBox ptbMyAvt;
        public static PictureBox ptbOtherAvt;

        public static void SetUp()
        {
            ptbMyAvt = new PictureBox();
            ptbMyAvt.Location = new Point(3, 35);
            ptbMyAvt.Width = 210;
            ptbMyAvt.Height = 160;
            ptbMyAvt.BackgroundImageLayout = ImageLayout.Stretch;
            //ptbMyAvt.BackgroundImage = user.Avatar;

            ptbOtherAvt = new PictureBox();
            ptbOtherAvt.Location = new Point(3, 35);
            ptbOtherAvt.Width = 210;
            ptbOtherAvt.Height = 160;
            ptbOtherAvt.BackgroundImageLayout = ImageLayout.Stretch;

            lstMessage = new ListBox();
            lstMessage.Location = new Point(830, 313);
            lstMessage.Width = 440;
            lstMessage.Height = 390;
            lstMessage.BackColor = Color.White;

            lbMyUser = new Label();
            lbMyUser.Text = user.Name;
            lbMyUser.Location = new Point(10, 10);
            lbMyUser.Font = new Font("Times New Roman", 15, FontStyle.Regular);
            lbMyUser.AutoSize = true;

            lbOtherUser = new Label();
            lbOtherUser.Text = "Player 2";
            lbOtherUser.Location = new Point(10, 10);
            lbOtherUser.Font = new Font("Times New Roman", 15, FontStyle.Regular);
            lbOtherUser.AutoSize = true;
        }

        public static void UpdateUser(User user)
        {
            lbOtherUser.Text = user.Name;
            //ptbOtherAvt.BackgroundImage = user.Avatar;
        }

        public static void AddMessage(string user, string message)
        {
            lstMessage.Items.Add(user + ": " + message);
        }

        public static string Encrypt(string s) //Mã hóa
        {
            int key = 5;
            //mã hóa: thay kí tự bằng kí tự cách nó "key" đơn vị
            //ROT13: https://laptrinhvb.net/bai-viet/devexpress/---Csharp----Huong-dan-ma-hoa-va-giai-ma-su-dung-thuat-toan-ROT13/80396635ed3c3400.html

            string res = "";
            int temp = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                temp = s[i];
                if (s[i] >= '0' && s[i] <= '9')
                {
                    temp += key;
                    if (temp > '9') temp -= ('9' - '0' + 1);
                }
                else if (s[i] >= 'a' && s[i] <= 'z')
                {
                    temp += key;
                    if (temp > 'z') temp -= ('z' - 'a' + 1);
                }
                else if (s[i] >= 'A' && s[i] <= 'Z')
                {
                    temp += key;
                    if (temp > 'Z') temp -= ('Z' - 'A' + 1);
                }
                res += Convert.ToChar(temp);
            }
            return res;
        }

        public static string Decrypt(string s) //Giải mã
        {
            int key = 5;
            //mã hóa: thay kí tự bằng kí tự cách nó "key" đơn vị
            //ROT13: https://laptrinhvb.net/bai-viet/devexpress/---Csharp----Huong-dan-ma-hoa-va-giai-ma-su-dung-thuat-toan-ROT13/80396635ed3c3400.html

            string res = "";
            int temp = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                temp = s[i];
                if (s[i] >= '0' && s[i] <= '9')
                {
                    temp -= key;
                    if (temp < '0') temp += ('9' - '0' + 1);
                }
                else if (s[i] >= 'a' && s[i] <= 'z')
                {
                    temp -= key;
                    if (temp < 'a') temp += ('z' - 'a' + 1);
                }
                else if (s[i] >= 'A' && s[i] <= 'Z')
                {
                    temp -= key;
                    if (temp < 'A') temp += ('Z' - 'A' + 1);
                }
                res += Convert.ToChar(temp);
            }
            return res;
        }

        public static void InviteGame(string Name, string userName)
        {
            DialogResult d = MessageBox.Show
                (userName + "( " + Name +" ) mời bạn chơi game"   , "Lời mời", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                Name = UserManager.user.UserName;
                SocketData data;
                data = new SocketData("", (int)SocketCommand.ACCEPTED_INVITE_GAME, userName, Name, new Point());
                SocketManager.Send(SocketManager.client, data);
            }
        }
    }
}
