using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankBattle.Properties;

namespace TankBattle
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            InitialGame();
        }

        Timer refreshTimer = new Timer();
        /// <summary>
        /// 帧数
        /// </summary>
        int fps = 60;

        Tank tank = new Tank();

        /// <summary>
        /// 初始化游戏
        /// </summary>
        public void InitialGame()
        {
            panel1.Paint += Panel1_Paint;

            this.refreshTimer.Tick += RefreshTimer_Tick;
            this.refreshTimer.Interval = 1000 / fps;
            this.refreshTimer.Enabled = true;

            this.KeyDown += Main_KeyDown;
            this.KeyUp += Main_KeyUp;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            tank.Draw(g);
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            string k = e.KeyCode.ToString().ToLower();
            switch (k)
            {
                case "space":
                case "numpad0":
                    break;
                default:
                    tank.Stop();
                    break;
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            string k = e.KeyCode.ToString().ToLower();
            switch (k)
            {
                case "a":
                case "left":
                    tank.MoveLeft();
                    break;

                case "d":
                case "right":
                    tank.MoveRight();
                    break;

                case "w":
                case "up":
                    tank.MoveUp();
                    break;

                case "s":
                case "down":
                    tank.MoveDown();
                    break;

                case "space":
                case "numpad0":
                    tank.Fire();
                    break;
            }

            Utility.Log(string.Format("按下的键{0},位置为{1}.{2}", k, tank.Position.X, tank.Position.Y));
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            tank.Update();
            panel1.Invalidate();
        }
        
    }
}
