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
        private Bullet bullet = new Bullet();

        public Tank() 
            : base(Resources.player, new Size(30, 30), new Point(100, 100), 5)
        {
            this.Range = new Point(380, 457);
        }
        
        public void Fire()
        {
            Utility.Log(string.Format("开火，子弹状态{0}", bullet.IsExist));
            if (!bullet.IsExist)
            {
                Point tmp = new Point();
                int _direct_x = GetDirectX();
                int _direct_y = GetDirectY();
                tmp.X = Position.X + Size.Width / 2 + Size.Width / 2 * _direct_x;
                tmp.Y = Position.Y + Size.Height / 2 + Size.Height / 2 * _direct_y;
                
                bullet.Shoot(Dir, tmp);
            }
        }
                
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            if (bullet.IsExist) bullet.Draw(g);
        }

    }
}
