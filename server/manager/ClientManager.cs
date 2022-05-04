using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SeaFight
{
    public class ClientManager
    {
        public static Dictionary<string, Room> RoomList = new Dictionary<string, Room>();

        public static void CreateRoom(Socket client, string user)
        {
            Room newRoom = new Room();
            newRoom.RoomMaster = client;

            string RoomID = "";
            Random rand = new Random();
            do
            {
                RoomID = rand.Next(10000, 100000).ToString();
            }
            while (RoomList.ContainsKey(RoomID));
            RoomList.Add(RoomID, newRoom);

            RoomList[RoomID].MasterUser = user;

            SocketData data = new SocketData("Player 2", (int)SocketCommand.ENTERED_THE_ROOM, RoomID, "", new Point());
            data.User = new User();
            SocketManager.Send(client, data);
        }

        public static void JoinRoom(Socket client, string RoomID, string user)
        {
            SocketData data;
            if(!RoomList.ContainsKey(RoomID))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY, "Phòng không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            if(RoomList[RoomID].Player != null)
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY, "Phòng đã đủ người", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            RoomList[RoomID].PlayerUser = user;

            RoomList[RoomID].Player = client;
            data = new SocketData(RoomList[RoomID].MasterUser, (int)SocketCommand.ENTERED_THE_ROOM, RoomID, "", new Point());
            data.User = DataManager.GetInfo(RoomList[RoomID].MasterUser);
            SocketManager.Send(client, data);

            data = new SocketData(user, (int)SocketCommand.OTHER_USER, "", "", new Point());
            data.User = DataManager.GetInfo(user);
            SocketManager.Send(RoomList[RoomID].RoomMaster, data);
        }

        public static void ExitRoom(Socket client, string RoomID)
        {
            if(client == RoomList[RoomID].Player)
            {
                RoomList[RoomID].Player = null;
                SocketData data = new SocketData("", (int)SocketCommand.NOTIFY, "Đối thủ đã rời phòng", "", new Point());
                SocketManager.Send(RoomList[RoomID].RoomMaster, data);

                data.Command = (int)SocketCommand.NEW_GAME;
                SocketManager.Send(RoomList[RoomID].RoomMaster, data);
                RoomList[RoomID].PlayerReady = false;
                RoomList[RoomID].MasterReady = false;
                return;
            }

            if(RoomList[RoomID].Player == null)
            {
                RoomList.Remove(RoomID);
            }
            else
            {
                RoomList[RoomID].RoomMaster = RoomList[RoomID].Player;
                RoomList[RoomID].Player = null;

                SocketData data = new SocketData("", (int)SocketCommand.NOTIFY, "Đối thủ đã rời phòng", "", new Point());
                SocketManager.Send(RoomList[RoomID].RoomMaster, data);

                data.Command = (int)SocketCommand.NEW_GAME;
                SocketManager.Send(RoomList[RoomID].RoomMaster, data);
                RoomList[RoomID].PlayerReady = false;
                RoomList[RoomID].MasterReady = false;
                return;
            }
        }

        public static void NewGame(Socket client, string RoomID)
        {
            SocketData data;
            if(client != RoomList[RoomID].RoomMaster)
            {
                string notify = "Chủ phòng mới nó thể bắt đầu trò chơi mới";
                data = new SocketData("", (int)SocketCommand.NOTIFY, notify, "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            if(RoomList[RoomID].Player == null)
            {
                string notify = "Xin chờ người chơi vào phòng";
                data = new SocketData("", (int)SocketCommand.NOTIFY, notify, "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            data = new SocketData("", (int)SocketCommand.NEW_GAME, "", "", new Point());
            SocketManager.Send(RoomList[RoomID].Player, data);
            SocketManager.Send(RoomList[RoomID].RoomMaster, data);
            RoomList[RoomID].PlayerReady = false;
            RoomList[RoomID].MasterReady = false;
            return;
        }

        public static void StartGame(Socket client, string RoomID)
        {
            SocketData data;
            if (RoomList[RoomID].Player == null)
            {
                string notify = "Xin chờ người chơi vào phòng";
                data = new SocketData("", (int)SocketCommand.NOTIFY, notify, "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            if (client == RoomList[RoomID].Player) RoomList[RoomID].PlayerReady = true;
            if (client == RoomList[RoomID].RoomMaster) RoomList[RoomID].MasterReady = true;

            if (RoomList[RoomID].MasterReady && RoomList[RoomID].PlayerReady)
            {
                data = new SocketData("", (int)SocketCommand.START_GAME, "1", "", new Point());
                SocketManager.Send(RoomList[RoomID].RoomMaster, data);

                data.Message1 = "0";
                SocketManager.Send(RoomList[RoomID].Player, data);
            }
            else if (RoomList[RoomID].MasterReady || RoomList[RoomID].PlayerReady)
            {
                data = new SocketData("", (int)SocketCommand.UPDATE_STATUS, "Xin vui lòng đợi", "", new Point());
                SocketManager.Send(client, data);

                data.Message1 = "Đối thủ đã sẵn sàng";
                if (client != RoomList[RoomID].RoomMaster)
                    SocketManager.Send(RoomList[RoomID].RoomMaster, data);
                else
                    SocketManager.Send(RoomList[RoomID].Player, data);
            }
        }

        internal static void UpdateScore(Socket target, string userName, string score, string result)
        {
            score = (int.Parse(score) + 1).ToString();

            DataManager.UpdateScore(userName, score, result);
        }

        public static void Attack(Socket client, string RoomId, Point local)
        {
            SocketData data;
            data = new SocketData("", (int)SocketCommand.ATTACK, "", "", local);

            if (client == RoomList[RoomId].RoomMaster)
                SocketManager.Send(RoomList[RoomId].Player, data);
            else
                SocketManager.Send(RoomList[RoomId].RoomMaster, data);
        }

        public static void AttackInfo(Socket client, SocketData data)
        {
            string RoomID = data.ThisUser;

            if (client != RoomList[RoomID].RoomMaster)
                SocketManager.Send(RoomList[RoomID].RoomMaster, data);
            else
                SocketManager.Send(RoomList[RoomID].Player, data);
        }

        public static void SendMessage(Socket client, SocketData data)
        {
            string RoomID = data.Message2;

            if (RoomList[RoomID].Player == null)
            {
                data.ThisUser = "Admin";
                data.Message1 = "Chỉ có mình bạn trong phòng chờ";
                SocketManager.Send(client, data);
                return;
            }

            if (client != RoomList[RoomID].RoomMaster)
                SocketManager.Send(RoomList[RoomID].RoomMaster, data);
            else
                SocketManager.Send(RoomList[RoomID].Player, data);
        }

        public static void Login(Socket client, string isEncrypt, string user, string password)
        {
            if(isEncrypt == "true")
            {
                user = UserManager.Decrypt(user);
                password = UserManager.Decrypt(password);
            }

            SocketData data;
            if (!DataManager.CheckUser(user))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY, 
                    "Tên tài khoản không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            if(SocketManager.socketList.ContainsKey(user))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Taì khoản đang đăng nhập", "", new Point());
                SocketManager.Send(client, data);
                return;
            }
            
            string tempPass = DataManager.PassWord(user);
            if (password == tempPass)
            {
                User temp = DataManager.GetInfo(user);
                data = new SocketData((int)SocketCommand.LOG_IN, temp);
                SocketManager.Send(client, data);
                SocketManager.userList[client] = user;
                SocketManager.socketList[user] = client;
            }
            else
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Sai mật khẩu", "", new Point());
                SocketManager.Send(client, data);
            }
        }

        public static void AcceptedInviteGame(Socket client, string userName1, string userName2)
        {
            SocketManager.updateUser();
            if (!SocketManager.socketList.ContainsKey(userName1)) return;
            if (!SocketManager.socketList.ContainsKey(userName2)) return;

            Room newRoom = new Room();
            newRoom.RoomMaster = SocketManager.socketList[userName1];
            newRoom.Player = client;
            newRoom.MasterUser = userName1;
            newRoom.PlayerUser = userName2;

            string RoomID = "";
            Random rand = new Random();
            do
            {
                RoomID = rand.Next(10000, 100000).ToString();
            }
            while (RoomList.ContainsKey(RoomID));
            RoomList.Add(RoomID, newRoom);

            SocketData data1, data2;
            data1 = new SocketData(RoomList[RoomID].MasterUser, (int)SocketCommand.ENTERED_THE_ROOM, RoomID, "", new Point());
            data1.User = DataManager.GetInfo(RoomList[RoomID].MasterUser);
            SocketManager.Send(RoomList[RoomID].Player, data1);

            data2 = new SocketData(RoomList[RoomID].PlayerUser, (int)SocketCommand.ENTERED_THE_ROOM, RoomID, "", new Point());
            data2.User = DataManager.GetInfo(RoomList[RoomID].PlayerUser);
            SocketManager.Send(RoomList[RoomID].RoomMaster, data2);
        }

        public static void InviteGame(Socket client, string inviterName, string inviterUserName, string userName)
        {
            SocketData data;
            if (!DataManager.CheckUser(userName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tên tài khoản không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            SocketManager.updateUser();
            if (!SocketManager.socketList.ContainsKey(userName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tài khoản không online", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            Socket target = SocketManager.socketList[userName];
            data = new SocketData(inviterName,
                (int)SocketCommand.INVITE_GAME, inviterUserName, userName, new Point());
            SocketManager.Send(target, data);
        }

        public static void Register(Socket client, User user)
        {
            if (user.isEncrypt)
            {
                user.UserName = UserManager.Decrypt(user.UserName);
                user.PassWord = UserManager.Decrypt(user.PassWord);
                user.isEncrypt = false;
            }

            SocketData data;
            if (DataManager.CheckUser(user.UserName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tên tài khoản đã tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            if (DataManager.AddNewUser(user))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Đăng ký thành công", "", new Point());
                SocketManager.Send(client, data);
                return;
            }
            else
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Đăng ký thất bại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }
        }
        
        public static void UpdateUser(Socket client, User user, string password)
        {
            if (user.isEncrypt)
            {
                user.UserName = UserManager.Decrypt(user.UserName);
                user.PassWord = UserManager.Decrypt(user.PassWord);
                password = UserManager.Decrypt(password);
                user.isEncrypt = false;
            }

            SocketData data;
            if (!DataManager.CheckUser(user.UserName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tên tài khoản không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            string tempPass = DataManager.PassWord(user.UserName);
            if (password != tempPass)
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Sai mật khẩu", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            if(DataManager.UpdateUser(user))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Cập nhật thành công", "", new Point());
                SocketManager.Send(client, data);
                return;
            }
            else
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Cập nhật thất bại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }    
        }

        public static void CheckInfo(Socket client, string userName)
        {
            SocketData data;
            if (!DataManager.CheckUser(userName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tên tài khoản không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            User res = new User();
            res = DataManager.GetInfo(userName);
            string status = (SocketManager.socketList.ContainsKey(userName)) ? "Online" : "Offline";
            data = new SocketData((int)SocketCommand.CHECK_INFO, res, status);
            SocketManager.Send(client, data);
            return;
        }

        public static void CheckInfoName(Socket client, string userName)
        {
            SocketData data;
            if (!DataManager.CheckUser(userName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tên tài khoản không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            User res = new User();
            res = DataManager.GetInfo(userName);
            string status = (SocketManager.socketList.ContainsKey(userName)) ? "Online" : "Offline";
            data = new SocketData((int)SocketCommand.CHECK_INFO_NAME, res, status);
            SocketManager.Send(client, data);
            return;
        }

        public static void CheckInfoOnline(Socket client, string userName)
        {
            SocketData data;
            if (!DataManager.CheckUser(userName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tên tài khoản không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            User res = new User();
            res = DataManager.GetInfo(userName);
            string status = (SocketManager.socketList.ContainsKey(userName)) ? "Online" : "Offline";
            data = new SocketData((int)SocketCommand.CHECK_INFO_ONLINE, res, status);
            SocketManager.Send(client, data);
            return;
        }

        public static void CheckInfoScore(Socket client, string userName)
        {
            SocketData data;
            if (!DataManager.CheckUser(userName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tên tài khoản không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            User res = new User();
            res = DataManager.GetInfo(userName);
            string status = (SocketManager.socketList.ContainsKey(userName)) ? "Online" : "Offline";
            data = new SocketData((int)SocketCommand.CHECK_INFO_SCORE, res, status);
            SocketManager.Send(client, data);
            return;
        }

        public static void CheckInfoNote(Socket client, string userName)
        {
            SocketData data;
            if (!DataManager.CheckUser(userName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tên tài khoản không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            User res = new User();
            res = DataManager.GetInfo(userName);
            string status = (SocketManager.socketList.ContainsKey(userName)) ? "Online" : "Offline";
            data = new SocketData((int)SocketCommand.CHECK_INFO_NOTE, res, status);
            SocketManager.Send(client, data);
            return;
        }

        public static void CheckInfoBirthday(Socket client, string userName)
        {
            SocketData data;
            if (!DataManager.CheckUser(userName))
            {
                data = new SocketData("", (int)SocketCommand.NOTIFY,
                    "Tên tài khoản không tồn tại", "", new Point());
                SocketManager.Send(client, data);
                return;
            }

            User res = new User();
            res = DataManager.GetInfo(userName);
            string status = (SocketManager.socketList.ContainsKey(userName)) ? "Online" : "Offline";
            data = new SocketData((int)SocketCommand.CHECK_INFO_BIRTHDAY, res, status);
            SocketManager.Send(client, data);
            return;
        }

        public static void CheckUserOnline(Socket client)
        {
            List<User> lstUser = new List<User>();
            User temp = new User();
            foreach (Socket item in SocketManager.clientList)
            {
                if (SocketManager.userList.ContainsKey(item))
                {
                    temp = new User();
                    temp.UserName = SocketManager.userList[item];
                    lstUser.Add(temp);
                }
            }

            SocketData data = new SocketData((int)SocketCommand.CHECK_USER_ONLINE, lstUser);
            SocketManager.Send(client, data);
        }
    }

    public class Room
    {
        public Socket RoomMaster = null;
        public Socket Player = null;
        public bool PlayerReady = false;
        public bool MasterReady = false;
        public string MasterUser = "";
        public string PlayerUser = "";
    }
}
