using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class Mage : Character , IMagic
    {
        private int mana;

        public Mage(int x, int y, Texture2D texture, int health, int strength) 
            : base(x, y, texture, health, strength)
        {
            this.Mana = 100;
        }

        public int Mana
        {
            get { return this.mana; }
            set
            {
                MathHelper.Clamp(value, 0, 100);
                this.mana = value;
            }
        }

        public void CastSpell()
        {
            throw new System.NotImplementedException();
        }
    }

}