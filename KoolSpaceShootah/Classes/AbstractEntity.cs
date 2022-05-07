using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
    abstract class AbstractEntity : IEntity
    {
        // Enum to differentiate between Player or Enemy/Npc
        public enum User
        {
            Player,
            Npc
        }

        // Variables & properties
        public User user;
        private float normal;
        protected Texture2D texture;
        protected Vector2 vector;
        SpriteBatch spriteBatch;

        public float normalSpeed
        {
            get { return normal; }
        }

        public float halfSpeed
        {
            get { return normal / 2; }
        }

        public float speed
        {
            get { return speed; }
            set { speed = normalSpeed; }
        }

        public Texture2D sprite
        {
            get { return texture; }
            set { texture = value; }
        }

        public Vector2 position
        {
            get { return vector; }
            set { vector = value; }
        }

        // Initializes variables & properties
        public void Initialize()
        {
            switch (user)
            {
                case User.Player:
                    normal = 1.5f;
                    break;
                case User.Npc:
                    normal = 1.1f;
                    break;
            }
        }

        // Player will be overwriting these
        public void Input()
        {

        }

        public void Move()
        {

        }

        public void Update()
        {

        }

        public void LoadContent(Texture2D _sprite, GraphicsDevice _graphicsDevice)
        {
            this.sprite = _sprite;

            spriteBatch = new SpriteBatch(_graphicsDevice);
        }

        public void Draw(GameTime time)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position, Color.White);
            spriteBatch.End();
        }
    }
}
