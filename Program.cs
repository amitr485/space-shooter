using var game = new SpaceShooter.Game1();
game.Run();

namespace SpaceShooter
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}