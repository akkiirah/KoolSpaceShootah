using Microsoft.Xna.Framework;

namespace KoolSpaceShootah
{
    class Enemy : AbstractEnemy
    {
        public override void Update(GameTime gameTime)
        { base.Update(gameTime); }

        public override void Draw(GameTime time)
        { base.Draw(time); }

        protected override void Input()
        { }
    }
}
