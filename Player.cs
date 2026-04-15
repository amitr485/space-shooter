using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class Player
    {
        public Vector2 Position;
        public int Width = 40;
        public int Height = 40;
        private float speed = 5f;

        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        public Player()
        {
            Position = new Vector2(380, 550);
        }

        public void Update(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
                Position.X -= speed;
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
                Position.X += speed;

            Position.X = MathHelper.Clamp(Position.X, 0, 800 - Width);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, Bounds, Color.Yellow);
        }
    }
}