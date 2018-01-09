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
        public Bullet()
            : base(Resources.bullet, new Size(4, 4), new Point(100, 100), 15, false)
        {
            this.Range = new Point(380, 457);
        }
        

        public void Shoot(Direct dir, Point position)
        {
            this.Position = position;
            this.IsExist = true;
            Move(dir);
        }

        public void Hit()
        {
            IsExist = false;
            Stop();
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }

        public override void Update()
        {
            base.Update();
            if (OutRange()) Hit();
        }

        public bool OutRange()
        {
            return Position.X <= 0 || Position.X + Size.Width >= Range.X ||
                Position.Y <= 0 || Position.Y + Size.Height >= Range.Y;
        }
        
    }
}
