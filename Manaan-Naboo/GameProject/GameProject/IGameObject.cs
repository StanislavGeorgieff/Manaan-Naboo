using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public interface IGameObject
    {
        int X { get; set; }
        int Y { get; set; }
        Texture2D Texture { get; set; }
    }
}
