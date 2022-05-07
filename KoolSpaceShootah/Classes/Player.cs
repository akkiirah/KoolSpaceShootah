using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
     class Player : AbstractEntity
     {
        public Player(User _user)
        {
            this.user = _user;
        }
     }
}
