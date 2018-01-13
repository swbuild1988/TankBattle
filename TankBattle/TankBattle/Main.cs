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
            TankGame game = new TankGame(fps, panel1, this, new Point(380, 457));

            game.registerActions("a", () => game.Tank.MoveLeft());
            game.registerActions("d", () => game.Tank.MoveRight());
            game.registerActions("w", () => game.Tank.MoveUp());
            game.registerActions("s", () => game.Tank.MoveDown());
            game.registerActions("left", () => game.Tank.MoveLeft());
            game.registerActions("right", () => game.Tank.MoveRight());
            game.registerActions("up", () => game.Tank.MoveUp());
            game.registerActions("down", () => game.Tank.MoveDown());
            game.registerActions("space", () => game.Tank.Fire());
            game.registerActions("numpad0", () => game.Tank.Fire());
            this.KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.P) game.Tank.Pause();
            };
        }
    }
}
