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

        // Player
        Player player;
        Vector2 playerPos;
        Rectangle playerHitBoxLive;
        Rectangle playerSrcRec;
        int playerTotalFrame;
        Vector2 playerFrameSize;

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

            // Player
            playerPos = new Vector2(150,200);
            playerHitBoxLive = new Rectangle(0,0,40,40);
            playerSrcRec = new Rectangle(0,0,40,40);
            playerTotalFrame = 4;
            playerFrameSize = new Vector2(40,40);
            player = new Player(TextureManager.pacman, playerPos, playerHitBoxLive, playerTotalFrame, playerSrcRec, playerFrameSize);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Animation(gameTime);
            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            //map.Draw(_spriteBatch);
            player.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
