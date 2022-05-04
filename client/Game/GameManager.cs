using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace SeaFight
{
    public class GameManager
    {
        public static bool isMyFightingPlace;
        public static Panel pnlMyFightingPlace = new Panel();
        public static Panel pnlOtherFightingPlace = new Panel();
        public static List<BattleShip> MyBattleShip = new List<BattleShip>();
        public static List<BattleShip> OtherBattleShip = new List<BattleShip>();
        public static int[,] MyMatrix = new int[20, 20];
        public static int[,] OtherMatrix = new int[20, 20];
        public static string RoomID = "";
        public static int MyScore = 0;
        public static int OtherScore = 0;
        public static Label lbMyScore;
        public static Label lbOtherScore;

        public static List<Panel> MyShotList = new List<Panel>();
        public static int MyShotList_Index = 0;
        public static List<Panel> OtherShotList = new List<Panel>();
        public static int OtherShotList_Index = 0;

        public static bool MyTurn = false;

        public static Label lbStatus = new Label();

        public static Button btnShot = new Button(); 

        public static void SetUp()
        {
            pnlMyFightingPlace = new Panel();
            pnlOtherFightingPlace = new Panel();

            lbStatus = new Label();
            lbStatus.Location = new Point(212, 9);
            lbStatus.Font = new Font("Times New Roman",  14, FontStyle.Regular);
            lbStatus.Text = "Chúc bạn chơi game vui vẻ";
            lbStatus.AutoSize = true;
            lbStatus.ForeColor = Color.Blue;

            btnShot = new Button();
            btnShot.Height = btnShot.Width = BattleShip.BoxSize;
            btnShot.BackgroundImageLayout = ImageLayout.Stretch;
            btnShot.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\Shot.png");
            btnShot.Location = new Point(-100, -100);

            //MyFightingPlace
            pnlMyFightingPlace.Location = new Point(12, 30);
            pnlMyFightingPlace.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMyFightingPlace.BackColor = Color.Blue;
            pnlMyFightingPlace.BackgroundImage = Image.FromFile(
                Application.StartupPath + "\\Resources\\FightingPlace.png");
            pnlMyFightingPlace.Height = 800;
            pnlMyFightingPlace.Width = 800;
            pnlMyFightingPlace.Enabled = true;
            pnlMyFightingPlace.BringToFront();
            isMyFightingPlace = true;

            // 3(1x1) + 3(1x2) + 3(1x4) + 2(2x5) + 1(2x7)
            //BattleShip a = new BattleShip("1x1");
            MyBattleShip.Clear();
            MyBattleShip.Add(new BattleShip("1x1"));
            MyBattleShip.Add(new BattleShip("1x1"));
            MyBattleShip.Add(new BattleShip("1x1"));
            MyBattleShip.Add(new BattleShip("1x2"));
            MyBattleShip.Add(new BattleShip("1x2"));
            MyBattleShip.Add(new BattleShip("1x2"));
            MyBattleShip.Add(new BattleShip("1x4"));
            MyBattleShip.Add(new BattleShip("1x4"));
            MyBattleShip.Add(new BattleShip("1x4"));
            MyBattleShip.Add(new BattleShip("2x5"));
            MyBattleShip.Add(new BattleShip("2x5"));
            MyBattleShip.Add(new BattleShip("2x7"));

            //OtherFightingPlace
            pnlOtherFightingPlace.Location = new Point(12, 30);
            pnlOtherFightingPlace.BackgroundImageLayout = ImageLayout.Stretch;
            pnlOtherFightingPlace.BackColor = Color.Blue;
            pnlOtherFightingPlace.BackgroundImage = Image.FromFile(
                Application.StartupPath + "\\Resources\\FightingPlace.png");
            pnlOtherFightingPlace.Height = 800;
            pnlOtherFightingPlace.Width = 800;
            pnlOtherFightingPlace.Enabled = true;

            // 3(1x1) + 3(1x2) + 3(1x4) + 2(2x5) + 1(2x7)
            OtherBattleShip.Clear();
            OtherBattleShip.Add(new BattleShip("1x1"));
            OtherBattleShip.Add(new BattleShip("1x1"));
            OtherBattleShip.Add(new BattleShip("1x1"));
            OtherBattleShip.Add(new BattleShip("1x2"));
            OtherBattleShip.Add(new BattleShip("1x2"));
            OtherBattleShip.Add(new BattleShip("1x2"));
            OtherBattleShip.Add(new BattleShip("1x4"));
            OtherBattleShip.Add(new BattleShip("1x4"));
            OtherBattleShip.Add(new BattleShip("1x4"));
            OtherBattleShip.Add(new BattleShip("2x5"));
            OtherBattleShip.Add(new BattleShip("2x5"));
            OtherBattleShip.Add(new BattleShip("2x7"));

            for (int i = 0, temp = 0; i < 12; ++i)
            {
                MyBattleShip[i].pnlBattleShip.Location = new Point(0, temp);
                OtherBattleShip[i].pnlBattleShip.Location = new Point(-100, -100);

                pnlMyFightingPlace.Controls.Add(MyBattleShip[i].pnlBattleShip);
                pnlOtherFightingPlace.Controls.Add(OtherBattleShip[i].pnlBattleShip);

                temp = temp + MyBattleShip[i].pnlBattleShip.Height;
            }

            //Shot List 
            MyShotList.Clear();
            OtherShotList.Clear();
            for (int i=0; i<400; ++i)
            {
                OtherShotList.Add(new Panel());
                OtherShotList[i].Height = OtherShotList[i].Width = BattleShip.BoxSize-20;
                OtherShotList[i].BackColor = Color.Red;
                OtherShotList[i].BackgroundImageLayout = ImageLayout.Stretch;
                OtherShotList[i].Location = new Point(-100, -100);
                pnlMyFightingPlace.Controls.Add(OtherShotList[i]);

                MyShotList.Add(new Panel());
                MyShotList[i].Height = MyShotList[i].Width = BattleShip.BoxSize - 20;
                MyShotList[i].BackColor = Color.White;
                MyShotList[i].BackgroundImageLayout = ImageLayout.Stretch;
                MyShotList[i].Location = new Point(-100, -100);
                pnlOtherFightingPlace.Controls.Add(MyShotList[i]);
            }

            MyScore = OtherScore = 0;
            lbMyScore = new Label();
            lbMyScore.Text = "0";
            lbMyScore.Location = new Point(65, 197);
            lbMyScore.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            lbMyScore.AutoSize = true;

            lbOtherScore = new Label();
            lbOtherScore.Text = "0";
            lbOtherScore.Location = new Point(65, 197);
            lbOtherScore.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            lbOtherScore.AutoSize = true;

            //RunAnimation();
            pnlOtherFightingPlace.Controls.Add(btnShot);
            pnlOtherFightingPlace.MouseMove += PnlOtherFightingPlace_MouseMove;
            btnShot.MouseLeave += BtnShot_MouseLeave;
            btnShot.Click += BtnShot_Click;
            
        }

        private static void RunAnimation()
        {
            Thread Animation_Status = new Thread(() =>
            {
                for (int temp = 1; true; lbStatus.Left += temp)
                {
                    if (lbStatus.Left + lbStatus.Width > 612)
                        temp = -1;
                    if (lbStatus.Left < 212)
                        temp = 1;
                    Thread.Sleep(1);
                }
            });
            Animation_Status.IsBackground = true;
            Animation_Status.Start();
        }

        private static void BtnShot_Click(object sender, EventArgs e)
        {
            if (!MyTurn) return;
            Button btn = sender as Button;
            int x, y;
            y = btn.Left / BattleShip.BoxSize;
            x = btn.Top / BattleShip.BoxSize;


            if (OtherMatrix[x, y] != -1)
            {
                UpdateStatus("bạn đã tấn công vị trí này");
                return;
            }

            OtherMatrix[x, y] = 0;

            //pnlOtherFightingPlace.Enabled = false;
            //MyShotList[MyShotList_Index].Location = new Point(y + 10, x + 10);
            //++MyShotList_Index;

            SocketData data;
            data = new SocketData("", (int)SocketCommand.ATTACK, RoomID, "", new Point(x, y));
            SocketManager.Send(SocketManager.client, data);
        }

        private static void BtnShot_MouseLeave(object sender, EventArgs e)
        {
            btnShot.Hide();
        }

        private static void PnlOtherFightingPlace_MouseMove(object sender, MouseEventArgs e)
        {
            Thread Animation_Thread = new Thread(() =>
            {
                btnShot.Show();
                btnShot.Top = (e.Y / BattleShip.BoxSize) * BattleShip.BoxSize;
                btnShot.Left = (e.X / BattleShip.BoxSize) * BattleShip.BoxSize;
                btnShot.BringToFront();
                //UpdateStatus("Lượt của bạn");
            });
            Animation_Thread.IsBackground = true;
            Animation_Thread.Start();
        }

        public static void ChangeFightingPlace()
        {
            if(isMyFightingPlace)
            {
                pnlOtherFightingPlace.BringToFront();
                isMyFightingPlace = false;
            }
            else
            {
                pnlMyFightingPlace.BringToFront();
                isMyFightingPlace = true;
            }
        }

        public static void NewGame()
        {
            for (int i = 0, temp = 0; i < 12; ++i)
            {
                if (!MyBattleShip[i].isHorizontal) MyBattleShip[i].ChangeDirection();
                if (!OtherBattleShip[i].isHorizontal) OtherBattleShip[i].ChangeDirection();

                MyBattleShip[i].pnlBattleShip.Location = new Point(0, temp);
                OtherBattleShip[i].pnlBattleShip.Location = new Point(-100, -100);

                temp = temp + MyBattleShip[i].pnlBattleShip.Height;
            }

            //Shot List 
            if (OtherShotList_Index > MyShotList_Index)
                MyShotList_Index = OtherShotList_Index;
            for (int i = 0; i < MyShotList_Index; ++i)
            {
                OtherShotList[i].Location = new Point(-100, -100);

                MyShotList[i].Location = new Point(-100, -100);
            }
            MyShotList_Index = 0;
            OtherShotList_Index = 0;

            UpdateStatus("Chúc Bạn chơi Game vui vẻ");
            pnlMyFightingPlace.Enabled = true;
            pnlOtherFightingPlace.Enabled = true;
            pnlMyFightingPlace.BringToFront();
            MyScore = OtherScore = 0;
            lbMyScore.Text = "0";
            lbOtherScore.Text = "0";
            MyTurn = false;
        }

        public static void UpdateStatus(string s)
        {
            lbStatus.Text = s;
        }

        public static bool Ready()
        {
            for (int i = 0; i < 20; ++i)
            {
                for (int j = 0; j < 20; ++j)
                {
                    MyMatrix[i, j] = -1;
                    OtherMatrix[i, j] = -1;
                }
            }

            for (int k = 0; k < 12; ++k)
            {
                int top = MyBattleShip[k].pnlBattleShip.Top / BattleShip.BoxSize;
                int height = MyBattleShip[k].pnlBattleShip.Height / BattleShip.BoxSize;
                int left = MyBattleShip[k].pnlBattleShip.Left / BattleShip.BoxSize;
                int width = MyBattleShip[k].pnlBattleShip.Width / BattleShip.BoxSize;

                for (int i = top; i < top + height; ++i)
                {
                    for (int j = left; j < left + width; ++j)
                    {
                        if (MyMatrix[i, j] != -1)
                        {
                            MessageBox.Show("Không được phép xếp chồng các tàu chiến lên nhau");
                            return false;
                        }
                        MyMatrix[i, j] = k;
                    }
                }
            }

            pnlMyFightingPlace.Enabled = false;

            return true;
        }
        
        public static void ChangeTurn()
        {
            if(MyTurn)
            {
                MyTurn = false;
                Thread.Sleep(2000);
                UpdateStatus("Lượt của đối thủ");
                pnlMyFightingPlace.BringToFront();
            }
            else
            {
                Thread.Sleep(2000);
                MyTurn = true;
                UpdateStatus("Lượt của bạn");
                pnlOtherFightingPlace.BringToFront();
            }
        }

        public static void StartGame(string turn)
        {
            if(turn == "1") //Chơi trước.
            {
                UpdateStatus("Lượt của bạn");
                pnlOtherFightingPlace.BringToFront();
                MyTurn = true;
            }
            else
            {
                UpdateStatus("Lượt của đối thủ");
                pnlMyFightingPlace.BringToFront();
                MyTurn = false;
            }
        }

        public static void WinGame()
        {
            pnlMyFightingPlace.Enabled = false;
            pnlOtherFightingPlace.Enabled = false;

            SocketData data = new SocketData(UserManager.user.UserName, (int)SocketCommand.UPDATE_SCORE,
                UserManager.user.winScore, "win", new Point());
            SocketManager.Send(SocketManager.client, data);
            UserManager.user.winScore += 1;
            
            MessageBox.Show("Chúc mừng! Bạn đã dành chiến thắng");
        }

        public static void CloseGame()
        {
            pnlMyFightingPlace.Enabled = false;
            pnlOtherFightingPlace.Enabled = false;

            SocketData data = new SocketData(UserManager.user.UserName, (int)SocketCommand.UPDATE_SCORE,
                UserManager.user.closeScore, "close", new Point());
            SocketManager.Send(SocketManager.client, data);
            UserManager.user.closeScore += 1;

            MessageBox.Show("Tiếc quá! thua mất rồi");
        }

        public static void Attack(Point local)
        {
            int x = local.X * BattleShip.BoxSize;
            int y = local.Y * BattleShip.BoxSize;

            OtherShotList[OtherShotList_Index].Location = new Point(y + 10, x + 10);
            OtherShotList[OtherShotList_Index].BringToFront();
            ++OtherShotList_Index;

            int temp = MyMatrix[local.X, local.Y];

            MyMatrix[local.X, local.Y] = -2;
            SocketData data;
            if (temp == -1) //không trúng
            {
                data = new SocketData(RoomID, (int)SocketCommand.ATTACK_INFO, "-1", "", local);
                SocketManager.Send(SocketManager.client, data);
                ChangeTurn();
                return;
            }

            //Trúng
            bool isDestroyShip = true; //Kiểm tra tàu có bị phá hay không
            int top = MyBattleShip[temp].pnlBattleShip.Top / BattleShip.BoxSize;
            int height = MyBattleShip[temp].pnlBattleShip.Height / BattleShip.BoxSize;
            int left = MyBattleShip[temp].pnlBattleShip.Left / BattleShip.BoxSize;
            int width = MyBattleShip[temp].pnlBattleShip.Width / BattleShip.BoxSize;
            for (int i = top; i < top + height; ++i)
            {
                for (int j = left; j < left + width; ++j)
                {
                    if (temp == MyMatrix[i, j])
                    {
                        isDestroyShip = false;
                        break;
                    }
                }
                if (!isDestroyShip) break;
            }
            if (isDestroyShip)
            {
                local = MyBattleShip[temp].pnlBattleShip.Location;
                local.X = local.X / BattleShip.BoxSize;
                local.Y = local.Y / BattleShip.BoxSize;
                data = new SocketData(RoomID, (int)SocketCommand.ATTACK_INFO, temp.ToString(), "", local);
                if (MyBattleShip[temp].isHorizontal) data.Message2 = "HOR";
                else data.Message2 = "VER";
            }
            else
            {
                data = new SocketData(RoomID, (int)SocketCommand.ATTACK_INFO, "-2", "", local);
            
            }
            SocketManager.Send(SocketManager.client, data);
            OtherScore += 5;
            lbOtherScore.Text = OtherScore.ToString();
            if (OtherScore >= 275)
            {
                CloseGame();
                return;
            }
            ChangeTurn();
        }
        
        public static void AttackInfo(SocketData data)
        {
            Point local = data.Point;
            local.X = local.X * BattleShip.BoxSize;
            local.Y = local.Y * BattleShip.BoxSize;

            if (data.Message1 == "-1") //không trúng
            {
                MyShotList[MyShotList_Index].BackgroundImage = Image.FromFile(
                    Application.StartupPath + "\\Resources\\BlackSpot.png");
                MyShotList[MyShotList_Index].Location = new Point(local.Y + 10, local.X + 10);
                ++MyShotList_Index;
                ChangeTurn();
                return;
            }
            else if (data.Message1 == "-2") //trúng nhưng chưa phá hủy được tàu
            {
                MyShotList[MyShotList_Index].BackgroundImage = Image.FromFile(
                    Application.StartupPath + "\\Resources\\Fire.png");
                MyShotList[MyShotList_Index].Location = new Point(local.Y + 10, local.X + 10);
                ++MyShotList_Index;
            }
            else
            {
                int temp = int.Parse(data.Message1);
                if (data.Message2 == "VER")
                {
                    OtherBattleShip[temp].ChangeDirection();
                }
                OtherBattleShip[temp].pnlBattleShip.Location = local;
                OtherBattleShip[temp].pnlBattleShip.BringToFront();
                OtherBattleShip[temp].pnlBattleShip.Enabled = false;
            }
            MyScore += 5;
            lbMyScore.Text = MyScore.ToString();
            if (MyScore >= 275)
            {
                WinGame();
                return;
            }
            ChangeTurn();
        }
    }
}