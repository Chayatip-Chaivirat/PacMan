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
        public static Tile[,] tileArray;

        public Map(string fileName)
        {

        }

        public List<string> ReadFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
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

            // 2 for loops to fill the array
        }
    }
}
