using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RpgMonoGameProject.Content.Interfaces;

namespace RpgMonoGameProject.Content.GameObjects.Items
{
    public class Item : GameObject, IRenderable
    {

        public Image Image { get; set; }
        public Rectangle Shape { get; set; }

        public override void LoadContent(ContentManager content)
        {
            throw new System.NotImplementedException();
        }

        public override void UnloadContent()
        {
            throw new System.NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }
    }
}
