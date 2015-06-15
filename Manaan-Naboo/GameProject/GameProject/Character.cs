using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class Character : GameObject, ICharacter
    {
        public Character(int x, int y, Texture2D texture, int health, int strength) 
            : base(x, y, texture)
        {
            this.Health = health;
            this.Strength = strength;
            this.Gold = 250;
            this.Experience = 0;
        }

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public List<GameObject> Inventar { get; set; }
    }
}
