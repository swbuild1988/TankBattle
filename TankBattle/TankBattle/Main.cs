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
        /// <summary>
        /// 帧数
        /// </summary>
        int fps = 30;
        TankGame game;

        public Main()
        {
            InitializeComponent();

            InitialGame();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SetDebugMode(false);
        }

        /// <summary>
        /// 初始化游戏
        /// </summary>
        private void InitialGame()
        {
            game = new TankGame(fps, DrawPanel, this, new Point(DrawPanel.Width, DrawPanel.Height));

            game.RegisterActions("a", () => game.Tank.MoveLeft());
            game.RegisterActions("d", () => game.Tank.MoveRight());
            game.RegisterActions("w", () => game.Tank.MoveUp());
            game.RegisterActions("s", () => game.Tank.MoveDown());
            game.RegisterActions("left", () => game.Tank.MoveLeft());
            game.RegisterActions("right", () => game.Tank.MoveRight());
            game.RegisterActions("up", () => game.Tank.MoveUp());
            game.RegisterActions("down", () => game.Tank.MoveDown());
            game.RegisterActions("space", () => game.Tank.Fire());
            game.RegisterActions("numpad0", () => game.Tank.Fire());
            this.KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.P) game.Pause();
            };
        }

        private void SetDebugMode(bool debug_flag)
        {
            if (debug_flag)
            {
                this.ClientSize = new Size(DrawPanel.Width + DebugPanel.Width + 10, DrawPanel.Height);
            }
            else
            {
                this.ClientSize = DrawPanel.Size;
            }
        }

        private void Bar_FPS_ValueChanged(object sender, EventArgs e)
        {
            game.SetFPS(Bar_FPS.Value);
        }
    }
}
