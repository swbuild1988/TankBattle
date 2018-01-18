using System;
using System.Drawing;

namespace TankBattle
{
    /// <summary>
    /// 游戏中所有对象的基类
    /// </summary>
    public abstract class BaseObj
    {
        protected Point _position;
        protected Size _size;

        protected Image _ori_image;
        protected Image _image;
        
        protected bool _isExist = true;
        
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

        public BaseObj(Image img, Size size, Point position, bool isExist = true)
        {
            _position = position;
            _size = size;
            _isExist = isExist;
            _ori_image = Utility.ResizeImage(img, _size);
            _image = _ori_image.Clone() as Image;
        }
        
        public virtual void Draw(Graphics g)
        {
            if (_isExist) g.DrawImage(_image, _position);
        }


    }
}
