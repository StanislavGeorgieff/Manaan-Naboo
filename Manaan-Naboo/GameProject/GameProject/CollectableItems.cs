using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProject
{
    class CollectableItems : GameObject
    {
        public CollectableItems(int x, int y, Texture2D texture, int quantity)
            : base(x, y, texture)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}
