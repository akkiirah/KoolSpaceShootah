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

        MenuManager menuManager;
        Player player;
        Enemy[] enemies;
        IEntity[] entities;

        Texture2D playerSprite;
        Texture2D enemySprite;

        GameState gameState = GameState.Menu;
        Level level = Level.One;

        enum GameState
        {
            Menu,
            Options,
            Ingame
        }

        enum Level
        {
            One = 8,
            Two = 31,
            Three = 57,
            Four = 84
        }


        /// <summary>
        /// Inserted a 120fps cap to make the game run consistently
        /// </summary>
        public SpaceShootahGame()
        {
            graphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 120);

            graphicsManager.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphicsManager.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphicsManager.HardwareModeSwitch = false;
            graphicsManager.ToggleFullScreen();
        }

        /// <summary>
        /// Probably not the correct way to use this method but used when switching and initializing
        /// states accordingly.
        /// </summary>
        protected override void Initialize()
        {
            switch (gameState)
            {
                case GameState.Menu:
                    menuManager = new MenuManager();
                    break;

                case GameState.Options:
                    break;

                case GameState.Ingame:
                    Spawn();

                    foreach (var entity in entities)
                    {
                        entity.Initialize();
                    }
                    break;
            }

            base.Initialize();
        }

        /// <summary>
        /// Loads sprites for entities after they have been loaded and initialized.
        /// </summary>
        protected override void LoadContent()
        {
            switch (gameState)
            {
                case GameState.Menu:
                    menuManager.LoadContent(GraphicsDevice);
                    break;

                case GameState.Ingame:
                    playerSprite = Content.Load<Texture2D>("player");
                    enemySprite = Content.Load<Texture2D>("enemy1");

                    entities[0].LoadContent(playerSprite,
                    GraphicsDevice,
                    Window.ClientBounds.Width,
                    Window.ClientBounds.Height);

                    foreach (var enemy in enemies)
                    {
                        enemy.LoadContent(
                        enemySprite,
                        GraphicsDevice,
                        Window.ClientBounds.Width,
                        Window.ClientBounds.Height);
                    }
                    break;
            }

        }

        /// <summary>
        /// Unloads arrays and resets the player and the menu manager to preserve memory... i guess?
        /// </summary>
        protected override void UnloadContent()
        {
            switch (gameState)
            {
                case GameState.Menu:
                    if(entities == null) { return; }  

                    Array.Clear(entities, 0, entities.Length);
                    Array.Clear(enemies, 0, enemies.Length);
                    player = null;
                    break;

                case GameState.Ingame:
                    menuManager = null;
                    break;
            }
        }

        /// <summary>
        /// Updates the logic for every entity and also changes gamestates.
        /// Also calls to unload content from other gamestates to preserve memory.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {

            Debug.WriteLine(1 / gameTime.ElapsedGameTime.TotalSeconds);

            if (menuManager.keyState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            switch (gameState)
            {
                case GameState.Menu:
                    menuManager.Update();

                    if (menuManager.StartGame())
                    {
                        UnloadContent();
                        gameState = GameState.Ingame;
                        Initialize();
                        LoadContent();
                    }
                    break;

                case GameState.Ingame:
                    foreach (var entity in entities)
                    {
                        entity.Update(gameTime);
                    }

                    if(player.BackToMenu())
                    {
                        UnloadContent();
                        gameState = GameState.Menu;
                        Initialize();
                        LoadContent();
                    }

                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game according to what gamestate the game is currently in.
        /// </summary>
        protected override void Draw(GameTime time)
        {
            switch (gameState)
            {
                case GameState.Menu:
                    menuManager.Draw();
                    break;

                case GameState.Ingame:
                    GraphicsDevice.Clear(Color.DarkGray);
                    foreach (var entity in entities)
                    {
                        entity.Draw(time);
                    }
                    break;
            }

            base.Draw(time);
        }

        /// <summary>
        /// Each level enumerator has a value attached to it.
        /// This is used as number for enemies in the corresponding level.
        /// </summary>
        private void Spawn()
        {
            var enemyAmount = (int)level;

            switch (level)
            {

                case Level.One:
                entities = new IEntity[enemyAmount + 1];
                enemies = new Enemy[enemyAmount];

                player = new Player();
                entities[0] = player;

                for (int i = 0; i < enemyAmount; i++)
                {
                    enemies[i] = new Enemy();
                    entities[i + 1] = enemies[i];
                }
                    break;

                case Level.Two:
                    break;

                case Level.Three:
                    break;

                case Level.Four:
                    break;

            }

        }
    }
}
