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
    public class Wall : BaseObj
    {
        public Wall(Point position)
            : base(Resources.walls, new Size(30, 30), position)
        {
        }
    }
}
