using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace PacMan
{
    internal class Enemy : Moveable
    {
        private int movementCode;
        Random random = new Random();
        public Enemy(Texture2D tex, Vector2 pos, Rectangle hitBoxLive, int TotalFrame, Rectangle srcRec, Vector2 FrameSize) : base (TotalFrame, srcRec, FrameSize)
        {
            this.tex = tex;
            this.pos = pos;
            this.hitBoxLive = hitBoxLive;
            scale = 1;
            speed = 100;
            movementCode = random.Next(1, 5);
        }

        public void ChangeMovementCode()
        {
            int newMovementCode;
            do
            {
                newMovementCode = random.Next(1, 5); //From 1 to 4
            }
            while (newMovementCode == movementCode);

            movementCode = newMovementCode;
        }
        public void Movement(GameTime gameTime)
        {
            if(!objectMoving)
            {
                if (movementCode == 1) //Right
                {
                    animationFX = SpriteEffects.None;
                    rotation = 0;
                    frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                    rotation = MathHelper.ToRadians(0);
                    ChangeDirection(new Vector2(1, 0));
                    if(!objectMoving)
                    {
                        ChangeMovementCode();
                    }
                }

                else if (movementCode == 2) //Left
                {
                    animationFX = SpriteEffects.FlipHorizontally;
                    rotation = 0;
                    frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                    rotation = MathHelper.ToRadians(0);
                    ChangeDirection(new Vector2(-1, 0));
                    if (!objectMoving)
                    {
                        ChangeMovementCode();
                    }
                }

                else if (movementCode == 3) //Up
                {
                    animationFX = SpriteEffects.None;
                    rotation = MathHelper.ToRadians(-90);
                    frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                    ChangeDirection(new Vector2(0, -1));
                    if (!objectMoving)
                    {
                        ChangeMovementCode();
                    }
                }

                else if (movementCode == 4) //Down
                {
                    animationFX = SpriteEffects.None;
                    rotation = MathHelper.ToRadians(90);
                    frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                    ChangeDirection(new Vector2(0, 1));
                    if (!objectMoving)
                    {
                        ChangeMovementCode();
                    }
                }
            }
            else
            {
                MoveToTile(gameTime);
            }
        }
    }
}