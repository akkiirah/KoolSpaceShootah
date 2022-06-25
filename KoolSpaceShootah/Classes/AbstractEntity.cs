using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace KoolSpaceShootah
{
    abstract class AbstractEntity : IEntity
    {
        protected float speed;
        protected float normalSpeed;
        protected float halfSpeed;

        protected float timer = 2;
        protected int id;
        protected float damage;
        protected float health;
        protected Vector2 position;
        protected Texture2D sprite;
        private SpriteBatch spriteBatch;

        protected float deltaTime;
        protected int screenWidth;
        protected int screenHeight;
        protected Random rand;

        public Vector2 Position { get { return position; } }
        public float Damage { get { return damage; } }
        public float Health { get { return health; } }

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

        public bool Shoot()
        {
            if (timer <= 0)
            {
                timer = 2;
                return true;
            }
            else
            {
                timer -= deltaTime;
                return false;
            }
        }


        protected virtual void Move()
        {
            var speedMod = normalSpeed * 1.5f * deltaTime;

            if (position.X < 0) 
            { position.X += speedMod; }
            else if (position.X > screenWidth - sprite.Width) 
            { position.X -= speedMod; }
            else if (position.Y < 0) 
            { position.Y += speedMod; }
            else if (position.Y > screenHeight - sprite.Height) 
            { position.Y -= speedMod; }
        }

        /// <summary>
        /// Randomly shakes entities around
        /// Position has to be an int, otherwise sprite would flicker
        /// </summary>
        protected virtual void Jitter()
        {
            int jitX = rand.Next(-1, 2);
            int jitY = rand.Next(-1, 2);
            position = new Vector2(Convert.ToInt32(position.X + (jitX / 1.9f)), Convert.ToInt32(position.Y + (jitY / 1.9f)));
        }
    }
}
