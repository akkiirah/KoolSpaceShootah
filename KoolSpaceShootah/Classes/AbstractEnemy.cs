﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
    abstract class AbstractEnemy : AbstractEntity
    {
        public override void Initialize()
        {
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

        protected override void Move()
        {

        }

        public override void LoadContent(Texture2D _sprite, GraphicsDevice _graphicsDevice, int _width, int _height)
        {
            base.LoadContent(_sprite, _graphicsDevice, _width, _height);

            position.X = rand.Next(0, screenWidth - sprite.Width);
        }
    }
}
