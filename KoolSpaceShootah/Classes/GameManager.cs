using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace KoolSpaceShootah
{
    class GameManager
    {
        private Player player;
        private Enemy[] enemies;
        private IEntity[] entities;

        private GameState gameState = GameState.Ingame;
        private Level level = Level.One;

        enum GameState
        {
            Menu,
            Options,
            Ingame
        }

        enum Level
        {
            One,
            Two,
            Three,
            Four
        }

        public void Initialize()
        {
            switch (gameState)
            {
                case GameState.Menu:
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
        }

        private void Spawn()
        {
            var lvl1 = 5;

            switch (level)
            {
                case Level.One:
                    entities = new IEntity[lvl1 + 1];
                    enemies = new Enemy[lvl1];

                    player = new Player();
                    entities[0] = player;

                    for (int i = 0; i < lvl1; i++)
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

        public void LoadContent(Texture2D _playerSprite, Texture2D _enemySprite, GraphicsDevice _device, int _width, int _height)
        {
            entities[0].LoadContent(_playerSprite, _device, _width, _height);

            foreach (var enemy in enemies)
            {
                enemy.LoadContent(_enemySprite, _device, _width, _height);
            }
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach (var entity in entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw(GameTime time)
        {
            foreach (var entity in entities)
            {
                entity.Draw(time);
            }
        }

        // Debug only
        public bool CloseGame()
        {
            if (player.keyState.IsKeyDown(Keys.Escape))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
