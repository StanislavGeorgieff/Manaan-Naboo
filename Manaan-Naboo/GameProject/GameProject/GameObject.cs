using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public abstract class GameObject : IGameObject
    {
        public GameObject(int x, int y, Texture2D texture)
        {
            this.X = x;
            this.Y = y;
            this.Texture = texture;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Texture2D Texture { get; set; }
    }
}
