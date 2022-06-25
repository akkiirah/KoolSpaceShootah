using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoolSpaceShootah
{
    class Projectile : AbstractEntity
    {
        private int owner;

        public Projectile(int _owner)
        {
            owner = _owner;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Input();
        }

        protected override void Input()
        {
            position.X -= 1;
        }

        protected override void Jitter()
        {

        }
    }
}
