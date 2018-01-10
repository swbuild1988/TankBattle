using System.Drawing;

namespace TankBattle
{
    /// <summary>
    /// 所有游戏中的对象类
    /// </summary>
    class GameObj
    {
        #region 私有参数

        private Point _position;
        private Point _range;
        private Size _size;
        private int _speed;
        private Image _ori_image;
        private Image _image;

        public enum Direct
        {
            UP = 0,
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3
        }

        private Direct _dir = Direct.UP;
        private bool _isMove = false;
        private bool _isExist = true;

        #endregion

        public GameObj(Image img, Size size, Point position, int speed = 0, bool isExist = true)
        {
            _position = position;
            _size = size;
            _speed = speed;
            _isExist = isExist;
            _ori_image = Utility.resizeImage(img, size);
            _image = _ori_image.Clone() as Image;
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

        public void Stop()
        {
            _isMove = false;
        }

        public int GetDirectX()
        {
            return (int)_dir % 2 == 1 ? -1 * (int)_dir + 2 : 0;
        }
        
        public int GetDirectY()
        {
            return (int)_dir % 2 == 0 ? (int)_dir - 1 : 0;
        }

        public  void Move(Direct dir)
        {
            if (_dir != dir)
            {
                rotate((RotateFlipType)dir);
                _dir = dir;
            }
            _isMove = true;
        }

        #endregion

        #region 私有方法

        private void rotate(RotateFlipType type)
        {
            _image = _ori_image.Clone() as Image;
            _image.RotateFlip(type);
        }

        #endregion

        #region 虚方法，待重写

        public virtual void Draw(Graphics g)
        {
            g.DrawImage(_image, _position);
        }

        public virtual void Update()
        {
            int _direct_x = _isMove ? GetDirectX() : 0;
            int _direct_y = _isMove ? GetDirectY() : 0;
            _position.X += _speed * _direct_x;
            _position.Y += _speed * _direct_y;
            if (_position.X < 0) _position.X = 0;
            if (_position.X + _size.Width > _range.X) _position.X = _range.X - _size.Width;
            if (_position.Y < 0) _position.Y = 0;
            if (_position.Y + _size.Height > _range.Y) _position.Y = _range.Y - _size.Height;
        }

        #endregion

    }
}
