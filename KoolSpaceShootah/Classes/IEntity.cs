using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
    interface IEntity
    {
        enum User
        {
            Player,
            Npc
        }

        IEntity.User user { get; set; }
        float speed { get; set; }
        float normalSpeed { get; }
        float halfSpeed { get; }

        Vector2 position { get; set; }
        Texture2D sprite { get; }

        void Initialize();
        void Move();
    }
}
