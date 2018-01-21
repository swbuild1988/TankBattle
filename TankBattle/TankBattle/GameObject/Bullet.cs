using System;
using System.Timers;
using System.Drawing;
using TankBattle.Properties;

namespace TankBattle
{
    /// <summary>
    /// 子弹类
    /// </summary>
    class Bullet : GameTank
    {
        private int _cooldownTime = 300;
        private bool _isCoolDown = true;
        private Timer cooldown_Timer = new Timer();

        public bool IsCoolDown
        {
            get
            {
                return _isCoolDown;
            }
        }

        public Bullet(TankGame game)
            : base(game, Resources.bullet, new Size(4, 4), new Point(100, 100), 15, false)
        {
            cooldown_Timer.AutoReset = false;
            cooldown_Timer.Elapsed += Cooldown_Timer_Elapsed;
        }

        private void Cooldown_Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _isCoolDown = true;
        }

        public void Shoot(Direct dir, Point position)
        {
            if (!_isCoolDown) return;

            this.Position = position;
            this.IsExist = true;
            this.Dir = dir;

            _isCoolDown = false;
            cooldown_Timer.Interval = _cooldownTime;
            cooldown_Timer.Start();
        }

        public void SetCoolDownTime(int time)
        {
            _cooldownTime = time;
        }

        public override void Draw(Graphics g)
        {
            Move(Dir);
            
            base.Draw(g);
        }

        public override void Pause()
        {
            base.Pause();
        }

        public override void CheckPosition()
        {
            if (OutRange())
            {
                Hit(null);
            }
            else
            {
                foreach (BaseObj item in this.Game.Walls)
                {
                    if (IsCollsion(item)) Hit(item);
                }
            }
        }

        private bool OutRange()
        {
            return Position.X <= 0 || Position.X + Size.Width >= Range.X ||
                Position.Y <= 0 || Position.Y + Size.Height >= Range.Y;
        }

        private void Hit(BaseObj obj)
        {
            IsExist = false;
            if (obj != null) obj.IsExist = false;
        }

    }
}
