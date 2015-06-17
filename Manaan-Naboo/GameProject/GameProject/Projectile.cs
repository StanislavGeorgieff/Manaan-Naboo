using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProject
{
    class Projectile : GameObject
    {
        public Projectile(int x, int y, Texture2D texture, Direction dir) : base(x,y,texture)
        {
            this.Dir = dir;
        }

        public Direction Dir { get; set; }
        public const int Speed = 5;
    }
}
