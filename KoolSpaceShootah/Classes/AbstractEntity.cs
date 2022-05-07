using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
    abstract class AbstractEntity : IEntity
    {
        // Enum to differentiate between Player or Enemy/Npc
        enum User
        {
            Player,
            Npc
        }

        // Variables & properties
        private User user;
        protected bool boosting;
        private float normal;
        private float half;
        private Texture2D texture;
        private Vector2 vector;

        public float normalSpeed
        {
            get { return normal; }
        }

        public float halfSpeed
        {
            get { return half; }
        }

        public float speed
        {
            get { return speed; }
            set { speed = normalSpeed; }
        }

        public Texture2D sprite
        {
            get { return texture; }
        }

        public Vector2 position
        {
            get { return position; }
            set { position = value; }
        }

        // Initializes variables & properties
        public void Initialize()
        {
            switch (user)
            {
                case User.Player:
                    break;
                case User.Npc:
                    break;
                default:
                    break;
            }
        }

        // Player will be overwriting these
        public void Input()
        {

        }

        public void Move()
        {

        }
    }
}
