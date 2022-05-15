using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
    internal class Enemy  : AbstractEnemy
    {
        public override void Update(GameTime gameTime)
        {
            Input();
            Jitter();
        }

        public override void Draw(GameTime time)
        {
            base.Draw(time);
        }

        protected override void Input()
        {

        }
    }
}
