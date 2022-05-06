using System;

namespace KoolSpaceShootah
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            SpaceShootahGame game = new SpaceShootahGame();
            game.Run();
        }
    }
}