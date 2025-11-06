using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace PacMan
{
    internal class TextureManager
    {
        public static Texture2D ghost;
        public static Texture2D pac_man_eyes;
        public static Texture2D pac_man_font_small;
        public static Texture2D pac_man_fruits;
        public static Texture2D pac_man_ghost_base;
        public static Texture2D pac_man_scared_ghost_eyes_2;
        public static Texture2D pac_man_tileset01_2;
        public static Texture2D pac_man_tileset02;
        public static Texture2D pacman;
        public static Texture2D pacman_pellets;
        public static Texture2D spriteSheet_pacMan;
        public static Texture2D tileSet;

        public static void Textures(ContentManager content)
        {
            ghost = content.Load<Texture2D>("ghost");
            pac_man_eyes = content.Load<Texture2D>("pac_man_eyes");
            pac_man_font_small = content.Load<Texture2D>("pac_man_font_small");
            pac_man_fruits = content.Load<Texture2D>("pac_man_fruits-1");
            pac_man_ghost_base = content.Load<Texture2D>("pac_man_ghost_base");
            pac_man_scared_ghost_eyes_2 = content.Load<Texture2D>("pac_man_scared_ghost_eyes2");
            pac_man_tileset01_2 = content.Load<Texture2D>("pac_man_tileset01-2");
            pac_man_tileset02 = content.Load<Texture2D>("pac_man_tileset02");
            pacman = content.Load<Texture2D>("pacman");
            pacman_pellets = content.Load<Texture2D>("pacman_pellets");
            spriteSheet_pacMan = content.Load<Texture2D>("SpriteSheet_pacMan");
            tileSet = content.Load<Texture2D>("Tileset");
        }
    }
}
