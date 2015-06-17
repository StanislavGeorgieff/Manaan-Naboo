using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RpgMonoGameProject.Content.GameObjects.Items;
using RpgMonoGameProject.Content.Interfaces;

namespace RpgMonoGameProject.Content.GameObjects
{
    public class Character : GameObject, IMoveble, IAttackable
    {

        public Image Image { get; set; }
        public Rectangle Shape { get; set; }
        public Vector2 CurrentPosition { get; set; }
        public float Speed { get; set; }
        public Vector2 Move(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }


        public override void LoadContent(ContentManager content)
        {
            Image.LoadContent(content);
        }

        public override void UnloadContent()
        {
            Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            
            Image.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        public Weapon Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}
