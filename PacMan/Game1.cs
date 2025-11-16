using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace PacMan
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Map map;
        private List<Enemy> enemyList = new List<Enemy>();
        private List<Food> foodList = new List<Food>();

        // Player
        Player player;
        Vector2 playerPos;
        Rectangle playerHitBoxLive;
        int playertotalFrame = 4;
        Vector2 playerframeSize = new Vector2(40, 40);
        Rectangle playersrcRec = new Rectangle(0, 0, 40, 40);

        //Enemy
        Enemy enemy;
        Vector2 enemyPos;

        //Food
        Food food;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.Textures(Content);
            map = new Map(@"gameMap.txt");

            //Player
            playerPos = map.playerStartPos;
            player = new Player(TextureManager.pacman, playerPos, playerHitBoxLive, playertotalFrame, playersrcRec, playerframeSize);

            //Enemy
            foreach(Vector2 enemyStartPos in map.enemyPositions)
            {
                enemyList.Add(new Enemy(TextureManager.spriteSheet_pacMan, enemyStartPos, playerHitBoxLive, 6, playersrcRec, playerframeSize));
            }

            //Food
            foreach(Vector2 foodStartPos in map.foodPositions)
            {
                foodList.Add(new Food(TextureManager.pac_man_fruits, foodStartPos, playerHitBoxLive));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Animation(gameTime);
            player.Update(gameTime);

            foreach (Enemy ene in enemyList)
            {
                ene.Animation(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            map.Draw(_spriteBatch);
            player.Draw(_spriteBatch);

            foreach(Enemy ene in enemyList)
            {
                ene.Draw(_spriteBatch);
            }

            foreach(Food f in foodList)
            {
                f.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
