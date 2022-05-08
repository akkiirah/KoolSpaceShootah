using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
    abstract class AbstractEntity : IEntity
    {
        protected float speed;
        protected float normalSpeed;
        protected float halfSpeed;

        protected Vector2 position;
        protected Texture2D sprite; 
        private SpriteBatch spriteBatch;

        protected Random rand;
        protected float jitterStrength;

        public Vector2 Position { get { return position; } }

        public virtual void Initialize()
        {
            rand = new Random();
            speed = normalSpeed;
            jitterStrength = 4;
            halfSpeed = normalSpeed / 2;
        }

        public abstract void Update();

        protected abstract void Input();

        public virtual void Draw(GameTime time)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position, Color.White);
            spriteBatch.End();
        }

        public void LoadContent(Texture2D _sprite, GraphicsDevice _graphicsDevice)
        {
            this.sprite = _sprite;
            spriteBatch = new SpriteBatch(_graphicsDevice);
        }

        protected abstract void Move();

        /// <summary>
        /// Randomly shakes entities around
        /// </summary>
        protected void Jitter()
        {
            float jitX = rand.Next(-1, 2);
            float jitY = rand.Next(-1, 2);
            position = new Vector2(position.X + (jitX / jitterStrength), position.Y + (jitY / jitterStrength));
        }
    }
}
