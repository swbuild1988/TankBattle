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
        private Image _image;

        private int _direct_x = 0;
        private int _direct_y = 0;

        public Tank()
        {
            _image = Utility.resizeImage(Resources.player, _size);
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
            _direct_x = -1;
            _direct_y = 0;
        }

        public void MoveRight()
        {
            _direct_x = 1;
            _direct_y = 0;
        }

        public void MoveUp()
        {
            _direct_y = -1;
            _direct_x = 0;
        }

        public void MoveDown()
        {
            _direct_y = 1;
            _direct_x = 0;
        }

        public void Stop()
        {
            _direct_x = 0;
            _direct_y = 0;
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
