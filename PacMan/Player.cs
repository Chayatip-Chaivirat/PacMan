using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace PacMan
{
    internal class Player : Moveable
    {
        public Player(Texture2D tex, Vector2 pos, Rectangle hitBoxLive, int TotalFrame, Rectangle srcRec, Vector2 FrameSize) : base(TotalFrame, srcRec, FrameSize)
        {
            this.tex = tex;
            this.pos = pos;
            this.hitBoxLive = hitBoxLive;
            //totalFrame = 4;
            //frameSize = new Vector2(40, 40);
            //srcRec = new Rectangle(0, 0, 40, 40);
        }
        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                animationFX = SpriteEffects.None;
                rotation = 0;
                frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                rotation = MathHelper.ToRadians(0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                animationFX = SpriteEffects.FlipHorizontally;
                rotation = 0;
                frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                rotation = MathHelper.ToRadians(0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                animationFX = SpriteEffects.None;
                rotation = MathHelper.ToRadians(-90);
                frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                animationFX = SpriteEffects.None;
                rotation = MathHelper.ToRadians(90);
                frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
    }
}
