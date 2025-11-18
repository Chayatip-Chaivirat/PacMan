using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace PacMan
{
    internal class CollidableObject
    {
        protected Texture2D tex;
        protected Vector2 pos;
        protected Rectangle hitBoxLive;

        // Detect intersection
        public bool Collisiondetection(CollidableObject otherClass)
        {
            return this.hitBoxLive.Intersects(otherClass.hitBoxLive);
        }
    }
}
