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

        Player player;
        Texture2D playerSprite;


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
            
            player = new Player(Window.ClientBounds.Width, Window.ClientBounds.Height);
            player.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// Loads sprites for enteties after they have been loaded and initialized
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerSprite = Content.Load<Texture2D>("player");
            player.LoadContent(playerSprite, GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            player.Update();

            // Debug only for now
            if (player.CloseGame())
            {
                this.Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            player.Draw(time);

            base.Draw(time);
        }
    }
}
