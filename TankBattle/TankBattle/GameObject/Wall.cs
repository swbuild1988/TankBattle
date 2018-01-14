using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankBattle.Properties;

namespace TankBattle
{
    /// <summary>
    /// 墙类
    /// </summary>
    class Wall : GameObj
    {
        public Wall(TankGame game, Point position)
            : base(game, Resources.walls, new Size(30, 30), position)
        {
        }
    }
}
