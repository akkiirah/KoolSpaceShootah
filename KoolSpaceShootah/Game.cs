using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace KoolSpaceShootah
{
    public class SpaceShootahGame : Game
    {
        GraphicsDeviceManager graphicsManager;
        SpriteBatch spriteBatch;

        GameManager gameManager;


        /// <summary>
        /// Inserted a 120fps cap to make the game run consistently
        /// </summary>
        public SpaceShootahGame()
        {
            graphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 120d);
        }

        protected override void Initialize()
        {
            graphicsManager.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphicsManager.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphicsManager.HardwareModeSwitch = false;
            graphicsManager.ToggleFullScreen();

            gameManager = new GameManager();
            gameManager.Initialize();


            base.Initialize();
        }

        /// <summary>
        /// Loads sprites for entities after they have been loaded and initialized
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameManager.LoadContent(
                Content.Load<Texture2D>("player"),
                Content.Load<Texture2D>("enemy1"),
                GraphicsDevice,
                Window.ClientBounds.Width,
                Window.ClientBounds.Height
                );

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            gameManager.Update(gameTime);

            if (gameManager.CloseGame())
            {
                this.Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            gameManager.Draw(time);

            base.Draw(time);
        }
    }
}
