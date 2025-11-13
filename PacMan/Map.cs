using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace PacMan
{
    internal class Map
    {
        private List<string> result;
        public Tile tile;
        public static Tile[,] tileArray;
        private Vector2 wallTilePos;
        private Vector2 floorTilePos;
        private int tileSize = 40;
        public Vector2 playerStartPos { get; set; }
        public Map(string fileName)
        {
            CreateMap(fileName);
        }

        public List<string> ReadFromFile(string fileName)
        {
            using StreamReader sr = new StreamReader(fileName);
            List<string> result = new List<string>();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                result.Add(line);
            }
            sr.Close();
            return result;
        }

        public void CreateMap(string fileName)
        {
            List<string> map = ReadFromFile(fileName);
            tileArray = new Tile[map[0].Length, map.Count];

            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    if (map[i][j] == '+') // Wall
                    {
                        wallTilePos = new Vector2(j * tileSize, i * tileSize);
                        tileArray[j, i] = new Tile(TextureManager.wall, wallTilePos, false);
                    }
                    else if (map[i][j] == '-') // Stone floor
                    {
                        floorTilePos = new Vector2(j * tileSize, i * tileSize);
                        tileArray[j, i] = new Tile(TextureManager.stoneFloor, floorTilePos, true);
                    }
                    else if (map[i][j] == 'P') // Player
                    {
                        playerStartPos = new Vector2(j * tileSize, i * tileSize);
                        tileArray[j, i] = new Tile(TextureManager.stoneFloor, playerStartPos, true);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in tileArray)
            {
                if(tile != null)
                {
                    spriteBatch.Draw(tile.tileTex, tile.position, Color.White);
                }
            }
        }
    }
}
