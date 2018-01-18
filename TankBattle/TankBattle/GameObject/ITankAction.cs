using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    public interface ITankAction
    {
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
        void Move(Direct dir);
    }
}
