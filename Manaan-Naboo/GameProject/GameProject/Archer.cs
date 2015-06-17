using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class Archer : Character, IShootArrows
    {
        private int arrowsCount;

        public Archer(int x, int y, Texture2D texture, int health, int strength)
            : base(x, y, texture, health, strength)
        {
            this.ArrowsCount = 50;
        }

        public int ArrowsCount
        {
            get { return this.arrowsCount; }
            set
            {
                MathHelper.Clamp(value, 0, 50);
                this.arrowsCount = value;
            }
        }

        public void ShootArrow()
        {
            throw new System.NotImplementedException();
        }
    }

}