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
    class Bullet
    {
        private Point _position = new Point(100, 100);
        private Size _size = new Size(5, 5);
        private int _speed = 15;
        private Image _ori_image;
        private Image _image;

        enum Direct
        {
            UP = 0,
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3
        }

        private Direct _dir = Direct.DOWN;
        private bool _isMove = false;
        private bool _isExist = false;

        public Bullet()
        {
            _ori_image = Utility.resizeImage(Resources.bullet, _size);
            _image = _ori_image.Clone() as Image;
        }

        public Point Position
        {
            get
            {
                return _position;
            }
        }

        #region 子弹的移动方法
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

        private void Move(Direct dir)
        {
            if (_dir != dir)
            {
                rotate((RotateFlipType)dir);
                _dir = dir;
            }
            _isMove = true;
        }

        public void Stop()
        {
            _isMove = false;
        }

        public void Shoot(int dir, Point position)
        {
            this._dir = (Direct)dir;
            this._position = position;
            _isExist = true;
            Move(_dir);
        }

        public void Hit()
        {
            _isExist = false;
            Stop();
        }

        private void rotate(RotateFlipType type)
        {
            _image = _ori_image.Clone() as Image;
            _image.RotateFlip(type);
        }

        #endregion

        public void Draw(Graphics g)
        {
            g.DrawImage(_image, _position);
        }

        public void Update()
        {
            int _direct_x = (int)_dir % 2 == 1 && _isMove ? -1 * (int)_dir + 2 : 0;
            int _direct_y = (int)_dir % 2 == 0 && _isMove ? (int)_dir - 1 : 0;
            _position.X += _speed * _direct_x;
            _position.Y += _speed * _direct_y;
            if (_position.X < 0 || _position.X + _size.Width > 380 ||
                _position.Y < 0 || _position.Y + _size.Height > 457) Hit();

            Console.WriteLine("bullet update, dirX : {0}, dirY : {1}", _position.X, _position.Y);
        }


        /// <summary>
        /// 是否还存在
        /// </summary>
        public bool IsExist
        {
            get
            {
                return _isExist;
            }
        }
        
    }
}
