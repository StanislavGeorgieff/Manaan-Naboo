using Microsoft.Xna.Framework;
using RpgMonoGameProject.Content.GameObjects;

namespace RpgMonoGameProject.Content.Interfaces
{
    public interface IRenderable
    {
        Image Image { get; set; }

        Rectangle Shape { get; set; }
    }
}
