using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
    interface IEntity
    {
        // Every Entity has these properties
        float speed { get; set; }
        float normalSpeed { get; }
        float halfSpeed { get; }

        Vector2 position { get; set; }
        Texture2D sprite { get; }

        void Initialize();
        void Move();
        void Input();
        void Update();
        void Draw(GameTime time);
        void LoadContent(Texture2D _tex, GraphicsDevice _graphicsDevice);
    }
}
