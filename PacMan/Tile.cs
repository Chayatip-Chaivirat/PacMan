using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
    internal class Tile
    {
        public bool isWalkable;
        public Texture2D tileTex;
        public Vector2 position;
        private Rectangle srcRec;
        public Tile(Texture2D tileTex, Vector2 position, bool isWalkable/*, Rectangle srcRec*/)
        {
            this.tileTex = tileTex;
            this.position = position;
            this.isWalkable = isWalkable;
            //this.srcRec = srcRec;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileTex, position, srcRec, Color.White);
        }
    }
}
