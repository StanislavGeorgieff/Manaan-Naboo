using Microsoft.Xna.Framework;

namespace RpgMonoGameProject.Content.Interfaces
{
    public interface IMoveble : IRenderable
    {
        Vector2 Move(Vector2 direction);
    }
}
