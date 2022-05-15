using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
    interface IEntity
    {
        Vector2 Position { get; }

        void Initialize();
        void Update(GameTime gameTime);
        void Draw(GameTime time);
        void LoadContent(Texture2D _tex, GraphicsDevice _graphicsDevice, int _width, int _height);
    }
}
