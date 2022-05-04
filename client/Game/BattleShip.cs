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
    public class BattleShip
    {
        public const int BoxSize = 40;

        public Panel pnlBattleShip = new Panel();
        public int Width;
        public int Height;
        public string Type;
        public bool isHorizontal;

        public BattleShip()
        {

            pnlBattleShip.Location = new Point(0, 0);
            pnlBattleShip.BackgroundImageLayout = ImageLayout.Stretch;
            pnlBattleShip.BackColor = Color.Yellow; //xanh dương

            isHorizontal = true;
            Type = "1x4";

            pnlBattleShip.MouseMove += Pnl_MouseMove;
            pnlBattleShip.MouseUp += Pnl_MouseUp;

            SetType(Type);
        }

        public BattleShip(string typeShip) : this()
        {
            SetType(typeShip);
        }

        public virtual void Pnl_MouseMove(object sender, MouseEventArgs e)
        {
            Thread MouseMoveThread = new Thread(() =>
            {
                Panel pnl = sender as Panel;
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pnl.BringToFront();
                    
                    //style 1
                    //int x = e.Y + pnl.Top - pnl.Height;
                    //int y = e.X + pnl.Left - pnl.Width;

                    //style 2
                    //int x = e.Y + pnl.Top;
                    //int y = e.X + pnl.Left;

                    //style 3
                    int x = e.Y + pnl.Top - pnl.Height/2;
                    int y = e.X + pnl.Left  - pnl.Width/2;

                    x = (x / BoxSize) * BoxSize;
                    y = (y / BoxSize) * BoxSize;
                    if (x < 0) x = 0;
                    if (y < 0) y = 0;
                    if (x > 800 - pnl.Height) x = 800 - pnl.Height;
                    if (y > 800 - pnl.Width) y = 800 - pnl.Width;
                    pnl.Top = x;
                    pnl.Left = y;
                }
            });
            MouseMoveThread.IsBackground = true;
            MouseMoveThread.Start();
        }

        public virtual void Pnl_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ChangeDirection();
            }    
        }

        public void ChangeDirection() //xoay thuyền
        {
            if (isHorizontal) isHorizontal = false;
            else isHorizontal = true;
            SetType(Type);
        }

        public void SetType(string typeShip) // 1x1, 1x2, 1x4, 2x5, 2x7 
        {
            Type = typeShip;
            if(isHorizontal)
            {
                Height = typeShip[0] - '0';
                Width = typeShip[2] - '0';
                pnlBattleShip.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\" + typeShip + "(HOR).png");
                pnlBattleShip.Height = BoxSize * Height;
                pnlBattleShip.Width = BoxSize * Width;
            }
            else
            {
                Height = typeShip[2] - '0';
                Width = typeShip[0] - '0';
                pnlBattleShip.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\" + typeShip + "(VER).png");
                pnlBattleShip.Width = BoxSize * Width;
                pnlBattleShip.Height = BoxSize * Height;
            }

            //chỉnh lại tọa độ cho không bị lệch ra ngoài
            if (pnlBattleShip.Top < 0) pnlBattleShip.Top = 0;
            if (pnlBattleShip.Left < 0) pnlBattleShip.Left = 0;
            if (pnlBattleShip.Top > 800 - pnlBattleShip.Height) pnlBattleShip.Top = 800 - pnlBattleShip.Height;
            if (pnlBattleShip.Left > 800 - pnlBattleShip.Width) pnlBattleShip.Left = 800 - pnlBattleShip.Width;
        }

        public static Panel BlackSpot(int x, int y)
        {
            Panel pnl = new Panel();
            pnl.BackColor = Color.Red;
            pnl.Height = pnl.Width = BoxSize;
            pnl.BackgroundImageLayout = ImageLayout.Stretch;
            pnl.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\BlackSpot.png");
            pnl.Location = new Point(x, y);
            return pnl;
        }
    }
}