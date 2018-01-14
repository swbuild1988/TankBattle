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

        public Main()
        {
            InitializeComponent();

            InitialGame();
        }

        /// <summary>
        /// 初始化游戏
        /// </summary>
        public void InitialGame()
        {
            TankGame game = new TankGame(fps, panel1, this, new Point(panel1.Width, panel1.Height));

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
    }
}
