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

        protected float deltaTime;
        protected int screenWidth;
        protected int screenHeight;
        protected Random rand;

        public Vector2 Position { get { return position; } }

        public virtual void Initialize()
        {
            rand = new Random();
            speed = normalSpeed;
            halfSpeed = normalSpeed / 2;
        }

        public virtual void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Input();
            Jitter();
            Move();
        }


        protected abstract void Input();

        public virtual void Draw(GameTime time)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position, Color.White);
            spriteBatch.End();
        }

        public virtual void LoadContent(Texture2D _sprite, GraphicsDevice _graphicsDevice, int _width, int _height)
        {
            screenWidth = _width;
            screenHeight = _height;

            this.sprite = _sprite;
            spriteBatch = new SpriteBatch(_graphicsDevice);
        }

        protected virtual void Move()
        {
            if (position.X < 0)
            {
                position.X += 2;
            }
            else if (position.X > screenWidth - sprite.Width)
            {
                position.X -= 2;
            }
            else if (position.Y < 0)
            {
                position.Y += 2;
            }
            else if (position.Y > screenHeight - sprite.Height)
            {
                position.Y -= 2;
            }
        }

        /// <summary>
        /// Randomly shakes entities around
        /// Position has to be an int, otherwise sprite would flicker
        /// </summary>
        protected void Jitter()
        {
            int jitX = rand.Next(-1, 2);
            int jitY = rand.Next(-1, 2);
            position = new Vector2(Convert.ToInt32(position.X + (jitX / 1.9f)), Convert.ToInt32(position.Y + (jitY / 1.9f)));
        }
    }
}
