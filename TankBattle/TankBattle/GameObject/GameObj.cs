using System;
using System.Drawing;

namespace TankBattle
{
    /// <summary>
    /// 所有游戏中的对象类
    /// </summary>
    class GameObj
    {
        public enum Direct
        {
            UP = 0,
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3
        }

        #region 私有参数

        private Point _position;
        private Point _range;
        private Size _size;
        private int _speed;
        private Image _ori_image;
        private Image _image;
        private TankGame _game;

        private Direct _dir = Direct.UP;
        private bool _isExist = true;
        private bool _isPause = false;

        #endregion

        public GameObj(TankGame game, Image img, Size size, Point position, int speed = 0, bool isExist = true)
        {
            _game = game;
            _position = position;
            _size = size;
            _speed = speed;
            _isExist = isExist;
            _ori_image = Utility.ResizeImage(img, size);
            _image = _ori_image.Clone() as Image;
            
            this.Range = game.Range;
        }

        #region 公有参数

        public Point Position
        {
            set
            {
                _position = value;
            }
            get
            {
                return _position;
            }
        }

        public Size Size
        {
            get
            {
                return _size;
            }
        }

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

        public bool IsExist
        {
            set
            {
                _isExist = value;
            }
            get
            {
                return _isExist;
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

        public int GetDirectX()
        {
            return (int)_dir % 2 == 1 ? -1 * (int)_dir + 2 : 0;
        }
        
        public int GetDirectY()
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

        public bool IsCollsion(GameObj obj)
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

        private void rotate(RotateFlipType type)
        {
            _image = _ori_image.Clone() as Image;
            _image.RotateFlip(type);
        }

        private int getValueInRange(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        #endregion

        #region 虚方法,可重写

        public virtual void Draw(Graphics g)
        {
            if (_isExist) g.DrawImage(_image, _position);
        }

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
