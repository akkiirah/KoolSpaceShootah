using System;
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

        public override void Update()
        {

        }

        public override void Draw(GameTime time)
        {
            base.Draw(time);
        }

        protected override void Move()
        {

        }
    }
}
