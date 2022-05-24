using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KoolSpaceShootah
{
    class MenuManager
    {
        public KeyboardState keyState;
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphicsDevice;

        public bool StartGame()
        {
            if (keyState.IsKeyDown(Keys.F)) 
            { return true; }
            else 
            { return false; }
        }

        public void LoadContent(GraphicsDevice _graphicsDevice)
        {
            graphicsDevice = _graphicsDevice;
            spriteBatch = new SpriteBatch(_graphicsDevice);
        }

        public void Draw()
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.Beige);
            spriteBatch.End();
        }

        private void Input()
        { keyState = Keyboard.GetState(); }

        public void Update()
        { Input(); }
    }
}
