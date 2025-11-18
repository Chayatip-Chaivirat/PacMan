using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
using System;
using System.Collections.Generic;
using System.IO;

namespace PacMan
{
    internal class Player : Moveable
    {
        public int lives = 3;
        private float collisionInterval = 1.5f;
        private float currentCD = 1.0f;
        public Player(Texture2D tex, Vector2 pos, Rectangle hitBoxLive, int TotalFrame, Rectangle srcRec, Vector2 FrameSize) : base(TotalFrame, srcRec, FrameSize)
        {
            this.tex = tex;
            this.pos = pos;
            this.hitBoxLive = hitBoxLive;
            scale = 1;
            speed = 200;
            objectMoving = false;
            objectDestination = Vector2.Zero;
        }
        public void Update(GameTime gameTime, List<Enemy> enemyList)
        {
            // ==== Movements ====
            if(!objectMoving)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    animationFX = SpriteEffects.None;
                    rotation = 0;
                    frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                    rotation = MathHelper.ToRadians(0);
                    ChangeDirection(new Vector2(1, 0));
                }

                else if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    animationFX = SpriteEffects.FlipHorizontally;
                    rotation = 0;
                    frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                    rotation = MathHelper.ToRadians(0);
                    ChangeDirection(new Vector2(-1, 0));
                }

                else if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    animationFX = SpriteEffects.None;
                    rotation = MathHelper.ToRadians(-90);
                    frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                    ChangeDirection(new Vector2(0, -1));
                }

                else if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    animationFX = SpriteEffects.None;
                    rotation = MathHelper.ToRadians(90);
                    frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                    ChangeDirection(new Vector2(0, 1));
                }
            }
            else
            {
                MoveToTile(gameTime);
            }

            // ==== Collisions ====
            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (currentCD > 0)
            {
                currentCD -= deltaTime;
            }

            CollisionWithEnemy(enemyList);
        }

        public void CollisionWithEnemy(List<Enemy> enemyList)
        {
            foreach (Enemy ene in enemyList)
            {
                if(Collisiondetection(ene))
                {
                    if(currentCD <= 0f)
                    {
                        lives -= 1;
                        currentCD = collisionInterval; // Reset cooldown when collide
                    }
                }
            }
        }
    }
}
