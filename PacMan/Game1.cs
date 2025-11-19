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
        Rectangle enemyHitBoxLive;

        //Food
        Food food;
        Rectangle foodHitBox;

        //SpriteFont
        SpriteFont font;

        //GameState
        static GameState gameState;
        enum GameState
        {
            Starting,
            Playing,
            GameOver
        }
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
            font = Content.Load<SpriteFont>("Font");

            //Player
            playerPos = map.playerStartPos;
            playerHitBoxLive= new Rectangle((int)playerPos.X, (int)playerPos.Y, 40, 40);
            player = new Player(TextureManager.pacman, playerPos, playerHitBoxLive, playertotalFrame, playersrcRec, playerframeSize);

            //Enemy
            foreach(Vector2 enemyStartPos in map.enemyPositions)
            {
                enemyHitBoxLive = new Rectangle((int)enemyStartPos.X, (int)enemyStartPos.Y, 45, 40);
                enemyList.Add(new Enemy(TextureManager.spriteSheet_pacMan, enemyStartPos, enemyHitBoxLive, 2, playersrcRec, playerframeSize));
            }

            //Food
            foreach(Vector2 foodStartPos in map.foodPositions)
            {
                foodHitBox = new Rectangle((int)foodStartPos.X, (int)foodStartPos.Y, 45, 40);
                foodList.Add(new Food(TextureManager.pac_man_fruits, foodStartPos, foodHitBox));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameState == GameState.Starting)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.Playing;
                }
            }

            if (gameState == GameState.Playing)
            {

                player.Animation(gameTime);
                player.Update(gameTime, enemyList, foodList);

                foreach (Enemy ene in enemyList)
                {
                    ene.Animation(gameTime);
                    ene.Movement(gameTime);
                }

                if (player.lives == 0 || foodList.Count == 0)
                {
                    gameState = GameState.GameOver;
                }
            }

            if (gameState == GameState.GameOver)
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            if (gameState == GameState.Starting)
            {
                _spriteBatch.DrawString(font, "Click Enter to start", new Vector2(), Color.Black);
            }

            if (gameState == GameState.Playing)
            {
                map.Draw(_spriteBatch);
                player.Draw(_spriteBatch);

                foreach (Enemy ene in enemyList)
                {
                    ene.Draw(_spriteBatch);
                }

                foreach (Food f in foodList)
                {
                    f.Draw(_spriteBatch);
                }
            }

            if (gameState == GameState.GameOver)
            {
                _spriteBatch.DrawString(font, "Game Over", new Vector2(), Color.Black);
            }

            //SpriteFont
            Window.Title = "Pac Man Lives: " + player.lives;

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}