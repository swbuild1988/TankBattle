using System;
using System.Collections.Generic;
using System.Drawing;

namespace TankBattle
{
    public class ObjConfig
    {
        public int SerialNumber { get; set; }
        public Point Position { get; set; }

        public ObjConfig()
        {
            this.SerialNumber = 1;
            this.Position = new Point(0, 0);
        }
    }

    public class TankConfig : ObjConfig
    {
        public int Blood { get; set; }

        public TankConfig() 
            : base()
        {
            this.Blood = 1;
        }
    }

    public class WallConfig : ObjConfig
    {
    }

    public class LevelConfig
    {
        public List<WallConfig> Walls { get; set; }
        public TankConfig Player { get; set; }

        public LevelConfig()
        {
            Walls = new List<WallConfig>();
            Player = new TankConfig();
        }
    }
}
