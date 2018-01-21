using System;
using System.Drawing;

namespace TankBattle
{
    /// <summary>
    /// 所有游戏中的能动的对象类
    /// </summary>
    public abstract class GameTank : BaseObj, ITankAction
    {
        #region 私有参数
        
        protected Point _range;
        protected int _speed;
        protected TankGame _game;

        protected Direct _dir = Direct.UP;
        protected bool _isPause = false;

        #endregion

        public GameTank(TankGame game, Image img, Size size, Point position, int speed = 0, bool isExist = true)
            : base(img, size, position, isExist)
        {
            _game = game;
            _speed = speed;

            this.Range = game.Range;
        }

        #region 公有参数


        public Direct Dir
        {
            set
            {
                _dir = value;
            }
            get
            {
                return _dir;
            }
        }

        public bool IsPause
        {
            get
            {
                return _isPause;
            }
        }

        public Point Range
        {
            set
            {
                _range = value;
            }
            get
            {
                return _range;
            }
        }

        public TankGame Game
        {
            get
            {
                return _game;
            }
        }

        #endregion

        #region 公有方法

        public void MoveLeft()
        {
            Move(Direct.LEFT);
        }

        public void MoveRight()
        {
            Move(Direct.RIGHT);
        }

        public void MoveUp()
        {
            Move(Direct.UP);
        }

        public void MoveDown()
        {
            Move(Direct.DOWN);
        }

        protected int GetDirectX()
        {
            return (int)_dir % 2 == 1 ? -1 * (int)_dir + 2 : 0;
        }

        protected int GetDirectY()
        {
            return (int)_dir % 2 == 0 ? (int)_dir - 1 : 0;
        }

        public void Move(Direct dir)
        {
            if (_isPause) return;

            if (_dir != dir)
            {
                rotate((RotateFlipType)dir);
                _dir = dir;
            }
            
            _position.X += _speed * GetDirectX();
            _position.Y += _speed * GetDirectY();
            _position.X = getValueInRange(_position.X, 0, _range.X - _size.Width);
            _position.Y = getValueInRange(_position.Y, 0, _range.Y - _size.Height);

            CheckPosition();
        }

        public bool IsCollsion(BaseObj obj)
        {
            // 如果对象都不存在了，就不会碰撞了
            if (!obj.IsExist) return false;

            if (this.Position.X >= obj.Position.X && this.Position.X >= obj.Position.X + obj.Size.Width)
            {
                return false;
            }
            else if (this.Position.X <= obj.Position.X && this.Position.X + this.Size.Width <= obj.Position.X)
            {
                return false;
            }
            else if (this.Position.Y >= obj.Position.Y && this.Position.Y >= obj.Position.Y + obj.Size.Height)
            {
                return false;
            }
            else if (this.Position.Y <= obj.Position.Y && this.Position.Y + this.Size.Height <= obj.Position.Y)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region 私有方法

        protected void rotate(RotateFlipType type)
        {
            _image = _ori_image.Clone() as Image;
            _image.RotateFlip(type);
        }

        protected int getValueInRange(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        #endregion

        #region 虚方法,可重写

        public virtual void Pause()
        {
            _isPause = !_isPause;
        }

        public virtual void CheckPosition()
        {

        }

        #endregion

    }
}
