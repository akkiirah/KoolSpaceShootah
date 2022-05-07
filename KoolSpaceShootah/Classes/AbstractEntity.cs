using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KoolSpaceShootah
{
    abstract class AbstractEntity : IEntity
    {
        #region Variables
        protected bool boosting;
        private float normal;
        private float half;
        private Texture2D texture;
        private Vector2 vector;

        public IEntity.User user
        {
            get { return user; }
            set { user = value; }
        }

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
        #endregion

        #region Methods

        public void Initialize()
        {
            switch (user)
            {
                case IEntity.User.Player:
                    break;
                case IEntity.User.Npc:
                    break;
                default:
                    break;
            }
        }

        public void Move()
        {

        }
        #endregion
    }
}
