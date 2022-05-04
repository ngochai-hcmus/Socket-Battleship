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
    public class SocketData
    {
        private string thisUser;
        public string ThisUser
        {
            get { return thisUser; }
            set { thisUser = value; }
        }

        private int command;
        public int Command
        {
            get { return command; }
            set { command = value; }
        }

        private string message1;
        public string Message1
        {
            get { return message1; }
            set { message1 = value; }
        }

        private string message2;
        public string Message2
        {
            get { return message2; }
            set { message2 = value; }
        }

        private Point point;
        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        private User user;
        public User User
        {
            get { return user; }
            set { user = value; }
        }

        private List<User> listUser;
        public List<User> ListUser
        {
            get { return listUser; }
            set { listUser = value; }
        }

        public SocketData(string thisUser, int command, string message1, string message2, Point point)
        {
            this.ThisUser = thisUser;
            this.Command = command;
            this.Point = point;
            this.Message1 = message1;
            this.Message2 = message2;
        }

        public SocketData(int command, User user)
        {
            this.Command = command;
            this.User = user;
        }
        public SocketData(int command, User user, string message1)
        {
            this.Command = command;
            this.Message1 = message1;
            this.User = user;
        }

        public SocketData(int command, List<User> lstUser)
        {
            this.Command = command;
            this.ListUser = lstUser;
        }
    }

    public enum SocketCommand
    {
        //chức năng công việc được yêu cầu

        //only server send
        UPDATE_STATUS,
        ENTERED_THE_ROOM,
        OTHER_USER,

        //only client send
        LOG_IN,
        REGISTER,
        CREATE_ROOM,
        JOIN_ROOM,
        EXIT_ROOM,
        UPDATE_SCORE,
        ACCEPTED_INVITE_GAME,

        //both server and client send
        NOTIFY,
        NEW_GAME,
        START_GAME,
        ATTACK,
        ATTACK_INFO,
        SEND_MESSAGE,
        UPDATE_USER,
        CHECK_INFO,
        CHECK_INFO_NAME,
        CHECK_INFO_BIRTHDAY,
        CHECK_INFO_ONLINE,
        CHECK_INFO_SCORE,
        CHECK_INFO_NOTE,
        CHECK_USER_ONLINE,
        INVITE_GAME,
    }
}
