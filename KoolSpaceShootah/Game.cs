using System;
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
        // Variables
        GraphicsDeviceManager graphicsManager;
        SpriteBatch spriteBatch;

        // Player
        Player player;

        Texture2D playerSprite;

        public SpaceShootahGame()
        {
            graphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Framerate cap
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 120d);
        }

        // Initialization logic
        protected override void Initialize()
        {
            player = new Player(AbstractEntity.User.Player);
            player.Initialize();
            base.Initialize();
        }

        // Loads content
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerSprite = Content.Load<Texture2D>("player");
            player.LoadSprite(playerSprite);
        }

        // Unload content
        protected override void UnloadContent()
        {

        }

        // Updates according to 
        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            spriteBatch.Begin();

            spriteBatch.Draw(player.sprite, player.position, Color.White);

            spriteBatch.End();
            base.Draw(time);
        }
    }
}
