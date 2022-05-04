using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    class DataManager
    {

        public static string connetionString = "Data Source=desktop-38iieua\\mssqlserver01;Initial Catalog=SEAFIGHT;Integrated Security=True";
        
        public static String PassWord(string userName)
        {
            string pass = "";

            SqlConnection con;
            con = new SqlConnection(connetionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("select password from tblUser where username = @username", con);
            cmd.Parameters.AddWithValue("@username", userName);
            SqlDataReader da = cmd.ExecuteReader();

            while (da.Read())
            {
                pass = da.GetValue(0).ToString();
            }

            con.Close();

            return pass;
        }

        public static bool AddNewUser(User user)
        {
            if(user.isEncrypt)
            {
                user.UserName = UserManager.Decrypt(user.UserName);
                user.PassWord = UserManager.Decrypt(user.PassWord);
            }

            SqlConnection con;
            con = new SqlConnection(connetionString);
            con.Open();

            string query = "insert into tblUser values (@user, @pass)";

            SqlCommand myCommand = new SqlCommand(query, con);

            myCommand.Parameters.AddWithValue("@user", user.UserName);
            myCommand.Parameters.AddWithValue("@pass", user.PassWord);

            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch
            {
                con.Close();

                return false;
            }

            //byte[] avatar = null;
            //avatar = SocketManager.Serialize(user.Avatar);

            query = "insert into tblInfoUser values (@user, @name, @gender, @birthday, @note)";//, @image)";

            myCommand = new SqlCommand(query, con);

            myCommand.Parameters.AddWithValue("@user", user.UserName);
            myCommand.Parameters.AddWithValue("@name", user.Name);
            myCommand.Parameters.AddWithValue("@gender", user.Gender);
            myCommand.Parameters.AddWithValue("@birthday", user.Birthday);
            myCommand.Parameters.AddWithValue("@note", user.Note);
            //myCommand.Parameters.AddWithValue("@image", avatar);

            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch
            {
                con.Close();

                return false;
            }

            query = "insert into tblScoreUser values (@user, @winscore, @closescore)";

            myCommand = new SqlCommand(query, con);

            myCommand.Parameters.AddWithValue("@user", user.UserName);
            myCommand.Parameters.AddWithValue("@winscore", "0");
            myCommand.Parameters.AddWithValue("@closescore", "0");

            try
            {
                myCommand.ExecuteNonQuery();
                
                con.Close();

                return true;
            }
            catch
            {
                con.Close();

                return false;
            }
        }

        public static bool CheckUser(string userName)
        {
            SqlConnection con;
            con = new SqlConnection(connetionString);
            con.Open();

            string query = "select count(UserName) from tblUser where UserName = @user";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", userName);
            
            SqlDataReader da = cmd.ExecuteReader();

            int temp = 0;

            while (da.Read())
            {
                temp = int.Parse(da.GetValue(0).ToString());
            }

            con.Close();

            if (temp > 0) return true;
            else return false;
            
        }

        public static User GetInfo(string userName)
        {
            User res = new User();
            res.UserName = userName;

            SqlConnection con;
            con = new SqlConnection(connetionString);
            con.Open();

            string query = "SELECT Name, Gender, Birthday, Note, WinScore, CloseScore" + //avatar
                           " from tblInfoUser, tblScoreUser" +
                           " where tblInfoUser.UserName = tblScoreUser.UserName" +
                           " AND tblInfoUser.UserName = @user";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", userName);

            SqlDataReader da = cmd.ExecuteReader();

            if(da.Read())
            {
                res.Name = (da[0] != null) ? da[0].ToString() : "";
                res.Gender = (da[1] != null) ? da[1].ToString() : "";
                res.Birthday = (da[2] != null) ? da[2].ToString() : "";
                res.Note = (da[3] != null) ? da[3].ToString() : "";
                //res.Avatar = (Image)SocketManager.Deserialize( (byte[])da[4] );
                res.winScore = (da[4] != null) ? da[4].ToString() : "";
                res.closeScore = (da[5] != null) ? da[5].ToString() : "";
            }

            con.Close();

            return res;
        }

        public static bool UpdateUser(User user)
        {
            SqlConnection con;
            con = new SqlConnection(connetionString);
            con.Open();

            string query = "UPDATE tblInfoUser" +
                           " SET UserName = @username, Name = @name, Gender = @gender, Birthday = @birthday, Note = @note"//, Avatar = @avatar"
                           + " Where UserName = '" + user.UserName +"'" +
                           " UPDATE tblUser" +
                           " SET UserName = @username, PassWord = @password"
                           + " Where UserName = '" + user.UserName + "'";

            SqlCommand myCommand = new SqlCommand(query, con);

            myCommand.Parameters.AddWithValue("@username", user.UserName);
            myCommand.Parameters.AddWithValue("@name", user.Name);
            myCommand.Parameters.AddWithValue("@gender", user.Gender);
            myCommand.Parameters.AddWithValue("@birthday", user.Birthday);
            myCommand.Parameters.AddWithValue("@note", user.Note);
            //myCommand.Parameters.AddWithValue("@avatar", SocketManager.Serialize(user.Avatar));
            myCommand.Parameters.AddWithValue("@password", user.PassWord);

            try
            {
                myCommand.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;
            }
        }

        public static void UpdateScore(string userName, string score, string res)
        {
            SqlConnection con;
            con = new SqlConnection(connetionString);
            con.Open();

            string query = "";
            if (res == "win")
            {
                query = "UPDATE tblScoreUser SET WinScore = @score WHERE UserName = @user";
            }
            else
            {
                query = "UPDATE tblScoreUser SET CloseScore = @score WHERE UserName = @user";
            }

            SqlCommand myCommand = new SqlCommand(query, con);

            myCommand.Parameters.AddWithValue("@user", userName);
            myCommand.Parameters.AddWithValue("@score", score);

            myCommand.ExecuteNonQuery();

            con.Close();
        }
    }
}
