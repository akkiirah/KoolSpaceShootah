using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KoolSpaceShootah
{
     class Player : AbstractEntity
     {
        private KeyboardState keyState;


        public Player()
        {

        }

        /// <summary>
        /// Initializes the player's variables and those from the AbstractEntity class
        /// </summary>
        public override void Initialize()
        {
            normalSpeed = 1.5f;
            base.Initialize();
        }

        public override void Update()
        {
            Input();
            Jitter();
            Move();
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
                position = new Vector2(position.X + speed, position.Y);
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                position = new Vector2(position.X - speed, position.Y);
            }

            if (keyState.IsKeyDown(Keys.Up))
            {
                position = new Vector2(position.X, position.Y - speed);
            }
            else if (keyState.IsKeyDown(Keys.Down))
            {
                position = new Vector2(position.X, position.Y + speed);
            }
            base.Move();

            Debug.WriteLine("Width: " + screenWidth.ToString(), ", Height: " + screenHeight.ToString());
        }

        public override void LoadContent(Texture2D _sprite, GraphicsDevice _graphicsDevice, int _width, int _height)
        {

            base.LoadContent(_sprite, _graphicsDevice, _width, _height);
            position.X = screenWidth / 2 - sprite.Width / 2;
            position.Y = screenHeight * 2.5f / 3;
        }

        // Debug only for now
        public bool CloseGame()
        {
            if (keyState.IsKeyDown(Keys.Escape))
            {
                return true;
            }
            else
            {
                return false;
            }
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
