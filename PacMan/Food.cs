using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace PacMan
{
    internal class Food : CollidableObject
    {
        public Food(Texture2D tex, Vector2 pos, Rectangle hitBoxLive)
        {
            this.tex = tex;
            this.pos = pos;
            this.hitBoxLive = hitBoxLive;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex,pos,Color.White);
        }
    }
}
