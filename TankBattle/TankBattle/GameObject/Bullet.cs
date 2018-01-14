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
    /// 子弹类
    /// </summary>
    class Bullet : GameObj
    {
        public Bullet(TankGame game)
            : base(game, Resources.bullet, new Size(4, 4), new Point(100, 100), 15, false)
        {
        }
        

        public void Shoot(Direct dir, Point position)
        {
            this.Position = position;
            this.IsExist = true;
            this.Dir = dir;
        }

        public void Hit(GameObj obj)
        {
            IsExist = false;
            if (obj != null) obj.IsExist = false;
        }

        public override void Draw(Graphics g)
        {
            Move(Dir);
            if (OutRange())
            {
                Hit(null);
            }
            else
            {
                foreach (GameObj item in this.Game.Walls)
                {
                    if (item.IsExist && isCollsion(item)) Hit(item);
                }
            }
            Utility.Log("子弹Draw");
            base.Draw(g);
        }
        
        private bool OutRange()
        {
            return Position.X <= 0 || Position.X + Size.Width >= Range.X ||
                Position.Y <= 0 || Position.Y + Size.Height >= Range.Y;
        }
        
    }
}
