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
    /// 坦克类
    /// </summary>
    class Tank : GameObj
    {
        private Bullet bullet;

        public Tank(TankGame game) 
            : base(game, Resources.player, new Size(30, 30), new Point(100, 100), 5)
        {
            bullet = new Bullet(this.Game);
        }
        
        public void Fire()
        {
            Utility.Log(string.Format("开火，子弹状态{0}", bullet.IsExist));

            if (!bullet.IsExist && !bullet.IsPause)
            {
                Point tmp = new Point();
                int _direct_x = GetDirectX();
                int _direct_y = GetDirectY();
                tmp.X = Position.X + Size.Width / 2  + Size.Width / 2 * _direct_x;
                tmp.Y = Position.Y + Size.Height / 2  + Size.Height / 2 * _direct_y;
                
                bullet.Shoot(Dir, tmp);
            }
        }
                
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            if (bullet.IsExist) bullet.Draw(g);
        }
        
        public override void Pause()
        {
            base.Pause();
            bullet.Pause();
        }

        public override void CheckPosition()
        {
            foreach (GameObj item in this.Game.Walls)
            {
                if (IsCollsion(item))
                {
                    Point tmp = Position;
                    switch (Dir)
                    {
                        case Direct.UP:
                            tmp.Y = item.Position.Y + item.Size.Height + 1;
                            break;
                        case Direct.RIGHT:
                            tmp.X = item.Position.X - Size.Width - 1;
                            break;
                        case Direct.DOWN:
                            tmp.Y = item.Position.Y - Size.Height - 1;
                            break;
                        case Direct.LEFT:
                            tmp.X = item.Position.X + item.Size.Width + 1;
                            break;
                        default:
                            break;
                    }
                    Position = tmp;
                }
            }
        }
    }
}
