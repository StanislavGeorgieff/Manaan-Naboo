using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using GameProject.Enumerations;

namespace GameProject
{
    public class Enemy : GameObject, IEnemy
    {
        public Enemy(int x, int y, Texture2D texture, int health, int strength)
            : base(x, y, texture)
        {
            this.Health = health;
            this.Strength = strength;
            this.Dir = Direction.Up;
        }

        public int Health { get; set; }
        public int Strength { get; set; }
        public Direction Dir { get; set; }
    }
}
