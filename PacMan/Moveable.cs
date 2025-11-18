using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
using System;
using System.Collections.Generic;
using System.IO;
namespace PacMan
{
    internal class Moveable : CollidableObject
    {
        protected int frame;
        protected int totalFrame;
        protected Vector2 frameSize;
        protected double frameTimer = 100, frameInterval = 100;
        protected Rectangle srcRec;

        protected SpriteEffects animationFX = SpriteEffects.None;
        protected float rotation = 0;
        protected float scale;
        protected Vector2 origin;

        protected Vector2 objectDirection;
        protected float speed;
        protected bool objectMoving;
        protected Vector2 objectDestination;

        public Moveable(int totalFrame, Rectangle srcRec, Vector2 frameSize)
        {
            this.totalFrame = totalFrame;
            this.srcRec = srcRec;
            this.frameSize = frameSize;
            origin = new Vector2((int)frameSize.X / 2, (int)frameSize.Y / 2);
        }

        public void Animation(GameTime gameTime)
        {
            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameTimer <= 0)
            {
                frameTimer = frameInterval; frame++;
                srcRec.X = (frame % totalFrame) * (int)frameSize.X;  
            }
        }

        public void ChangeDirection(Vector2 direction)
        {
            objectDirection = direction;
            Vector2 newObjectDestination = pos + objectDirection * Map.tileSize;

            if (Map.GetTileAtPosition(newObjectDestination)) // If the tile is walkable
            {
                objectDestination = newObjectDestination;
                hitBoxLive.X = (int)pos.X;
                hitBoxLive.Y = (int)pos.Y;
                objectMoving = true;
            }
        }

        public void MoveToTile(GameTime gameTime)
        {
            float dt = (float) gameTime.ElapsedGameTime.TotalSeconds;
            pos += objectDirection * speed * dt;

            if (Vector2.Distance(pos, objectDestination) < 1f)
            {
                pos = objectDestination;
                objectMoving = false;
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (tex != null)
            {
                Vector2 posOnTile = pos + origin;
                spriteBatch.Draw(tex, posOnTile, srcRec, Color.White, rotation, origin, scale, animationFX, 1);
            }

        }
    }
}