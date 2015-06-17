using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RpgMonoGameProject
{
    public abstract class GameObject : IGameObject
    {
        public abstract void LoadContent(ContentManager content);


        public abstract void UnloadContent();


        public abstract void Update(GameTime gameTime);


        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
