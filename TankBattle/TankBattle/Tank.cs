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
    class Tank
    {
        private Point _position = new Point(100, 100);
        private Size _size = new Size(30, 30);
        private int _speed = 5;
        private Image _ori_image;
        private Image _image;

        private Bullet bullet = new Bullet();

        enum Direct
        {
            UP = 0,
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3
        }

        private Direct _dir = Direct.UP;
        private bool _isMove = false;

        public Tank()
        {
            _ori_image = Utility.resizeImage(Resources.player, _size);
            _image = _ori_image.Clone() as Image;
        }

        public Point Position
        {
            get
            {
                return _position;
            }
        }

        #region 坦克的移动方法
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

        public void Fire()
        {
            if (!bullet.IsExist) bullet.Shoot((int)_dir, _position);
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
            if (bullet.IsExist) bullet.Draw(g);
        }

        public void Update()
        {
            //Console.WriteLine("tank update, dirX : {0}, dirY : {1}", _direct_x, _direct_y);
            int _direct_x = (int)_dir % 2 == 1 && _isMove ? -1 * (int)_dir + 2 : 0;
            int _direct_y = (int)_dir % 2 == 0 && _isMove ? (int)_dir - 1 : 0;
            _position.X += _speed * _direct_x;
            _position.Y += _speed * _direct_y;
            if (_position.X < 0) _position.X = 0;
            if (_position.X + _size.Width > 380) _position.X = 380 - _size.Width;
            if (_position.Y < 0) _position.Y = 0;
            if (_position.Y + _size.Height > 457) _position.Y = 457 - _size.Height;            

            if (bullet.IsExist)
            {
                bullet.Update();
            }
        }

    }
}
