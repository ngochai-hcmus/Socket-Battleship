using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    [Serializable]
    public class User
    {
        public string UserName { get; set; }
        public string PassWord = "";
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Note { get; set; }
        //public Image Avatar { get; set; }
        public string winScore { get; set; }
        public string closeScore { get; set; }

        public bool isEncrypt;

        public User()
        {
            UserName = "";
            PassWord = "";
            Name = "";
            Gender = "";
            Birthday = "";
            Note = "";
            //Avatar = null;
            isEncrypt = false;
            winScore = "0";
            closeScore = "0";
        }

        public User(string userName, string passWord, string name, string gender, string birthday, string note)
        {
            UserName = userName;
            PassWord = passWord;
            Name = name;
            Gender = gender;
            Birthday = birthday;
            Note = note;
            //Avatar = null;
            isEncrypt = false;
            winScore = "0";
            closeScore = "0";
        }

        public User(string userName, string passWord, string name,
            string gender, string birthday, string note, bool encrypt)
        {
            UserName = userName;
            PassWord = passWord;
            Name = name;
            Gender = gender;
            Birthday = birthday;
            Note = note;
            //Avatar = null;
            isEncrypt = encrypt;
            winScore = "0";
            closeScore = "0";
        }

        public User(string userName, string passWord, string name,
            string gender, string birthday, string note, Image avatar)
        {
            UserName = userName;
            PassWord = passWord;
            Name = name;
            Gender = gender;
            Birthday = birthday;
            Note = note;
            //Avatar = avatar;
            isEncrypt = false;
            winScore = "0";
            closeScore = "0";
        }

        public User(string userName, string passWord, string name,
            string gender, string birthday, string note, Image avatar, bool encrypt)
        {
            UserName = userName;
            PassWord = passWord;
            Name = name;
            Gender = gender;
            Birthday = birthday;
            Note = note;
            //Avatar = avatar;
            isEncrypt = encrypt;
            winScore = "0";
            closeScore = "0";
        }
    }
}
