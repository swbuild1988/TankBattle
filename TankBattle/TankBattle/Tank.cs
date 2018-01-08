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

        private int _direct_x = 0;
        private int _direct_y = 0;

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
            if (_direct_x != -1) rotate(RotateFlipType.Rotate270FlipNone);
            setDirect(-1, 0);
        }

        public void MoveRight()
        {
            if (_direct_x != 1) rotate(RotateFlipType.Rotate90FlipNone);
            setDirect(1, 0);
        }

        public void MoveUp()
        {
            if (_direct_y != -1) rotate(RotateFlipType.RotateNoneFlipNone);
            setDirect(0, -1);
        }

        public void MoveDown()
        {
            if (_direct_y != 1) rotate(RotateFlipType.Rotate180FlipNone);
            setDirect(0, 1);
        }

        public void Stop()
        {
            setDirect(0, 0);
        }

        private void setDirect(int dir_x, int dir_y)
        {
            _direct_x = dir_x;
            _direct_y = dir_y;
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
            //Console.WriteLine("tank update, dirX : {0}, dirY : {1}", _direct_x, _direct_y);
            _position.X += _speed * _direct_x;
            _position.Y += _speed * _direct_y;
            if (_position.X < 0) _position.X = 0;
            if (_position.X + _size.Width > 380) _position.X = 380 - _size.Width;
            if (_position.Y < 0) _position.Y = 0;
            if (_position.Y + _size.Height > 457) _position.Y = 457 - _size.Height;            
        }

    }
}
