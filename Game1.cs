using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private List<Enemy> _enemies;
        private List<Projectile> _projectiles;
        private int _score;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            _player = new Player();
            _enemies = new List<Enemy>();
            _projectiles = new List<Projectile>();
            _score = 0;

            // Initialize enemies
            for (int i = 0; i < 5; i++)
            {
                _enemies.Add(new Enemy());
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Load player and enemy textures
            _player.LoadContent(Content);
            foreach (var enemy in _enemies)
            {
                enemy.LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            _player.Update(keyboardState);

            foreach (var projectile in _projectiles)
            {
                projectile.Update();
            }

            // Check for collisions
            CheckCollisions();
            base.Update(gameTime);
        }

        private void CheckCollisions()
        {
            foreach (var projectile in _projectiles)
            {
                foreach (var enemy in _enemies)
                {
                    if (projectile.BoundingBox.Intersects(enemy.BoundingBox))
                    {
                        // Handle collision
                        _score += 10;
                        projectile.IsActive = false;
                        enemy.Reset(); // Reset enemy position
                    }
                }
            }

            // Remove inactive projectiles
            _projectiles.RemoveAll(p => !p.IsActive);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _player.Draw(_spriteBatch);
            foreach (var enemy in _enemies)
            {
                enemy.Draw(_spriteBatch);
            }
            foreach (var projectile in _projectiles)
            {
                projectile.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}