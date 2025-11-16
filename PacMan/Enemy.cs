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
        public Enemy(Texture2D tex, Vector2 pos, Rectangle hitBoxLive, int TotalFrame, Rectangle srcRec, Vector2 FrameSize) : base (TotalFrame, srcRec, FrameSize)
        {
            this.tex = tex;
            this.pos = pos;
            this.hitBoxLive = hitBoxLive;
            scale = 1;
        }
    }
}
