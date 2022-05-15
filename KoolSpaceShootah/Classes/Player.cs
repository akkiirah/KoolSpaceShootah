using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KoolSpaceShootah
{
     class Player : AbstractEntity
     {
        public KeyboardState keyState;


        public Player()
        {

        }

        /// <summary>
        /// Initializes the player's variables and those from the AbstractEntity class
        /// </summary>
        public override void Initialize()
        {
            normalSpeed = 180f;
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime time)
        {
            base.Draw(time);
        }

        protected override void Input()
        {
            keyState = Keyboard.GetState();
            CheckForDoubleInput();
        }

        protected override void Move()
        {
            if (keyState.IsKeyDown(Keys.Right))
            {
                position.X += speed * deltaTime;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                position.X -= speed * deltaTime;
            }

            if (keyState.IsKeyDown(Keys.Up))
            {
                position.Y -= speed * deltaTime;
            }
            else if (keyState.IsKeyDown(Keys.Down))
            {
                position.Y += speed * deltaTime;
            }
            base.Move();
        }

        public override void LoadContent(Texture2D _sprite, GraphicsDevice _graphicsDevice, int _width, int _height)
        {

            base.LoadContent(_sprite, _graphicsDevice, _width, _height);
            position.X = screenWidth / 2 - sprite.Width / 2;
            position.Y = screenHeight - sprite.Height;
        }

        /// <summary>
        /// Makes the player move half the normal speed when going diagonally 
        /// </summary>
        private void CheckForDoubleInput()
        {
            if (keyState.IsKeyDown(Keys.Right) && keyState.IsKeyDown(Keys.Down) ||
                keyState.IsKeyDown(Keys.Right) && keyState.IsKeyDown(Keys.Up) ||
                keyState.IsKeyDown(Keys.Left) && keyState.IsKeyDown(Keys.Down) ||
                keyState.IsKeyDown(Keys.Left) && keyState.IsKeyDown(Keys.Up))
            {
                speed = halfSpeed;
            }
            else
            {
                speed = normalSpeed;
            }
        }
     }
}
