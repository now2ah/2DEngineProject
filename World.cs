using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class World
    {
        string[] _map =
        {
            "**********",
            "*        *",
            "*        *",
            "*        *",
            "*        *",
            "*        *",
            "*        *",
            "*        *",
            "*        *",
            "**********" 
        };

        Tile[,] _tileMap;

        GameObject[] gameObjects = new GameObject[100];

        int gameObjectCount = 0;
        

        public string[] Map { get { return _map; } }
        public Tile[,] TileMap { get { return _tileMap; } }
        public GameObject[] GameObjects { get { return gameObjects; } }
        public int GameObjectCount { get { return gameObjectCount; } }

        public void StartWorld()
        {
            _tileMap = _GenerateTileMap(_map);

            gameObjects[gameObjectCount++] = new Player(3, 3, 'P');
            gameObjects[gameObjectCount++] = new Monster(6, 6, 'M');
            gameObjects[gameObjectCount++] = new Goal(8, 8, 'G');
        }

        public void Render()
        {
            //render string map
            //for (int j = 0; j < _map.GetLength(0); j++)
            //{
            //    for (int i = 0; i < _map.GetLength(1); i++)
            //    {
            //        Console.Write(_map[j,i]);
            //        Console.Write("\n");
            //    }
            //}

            //render tile map
            for (int j = 0; j < _tileMap.GetLength(0); j++)
            {
                for (int i = 0; i < _tileMap.GetLength(1); i++)
                {
                    _tileMap[j, i].Render();
                }
            }

            for (int i = 0; i < gameObjectCount; i++)
            {
                gameObjects[i].Render();
            }
        }

        public void Update()
        {
            for(int i=0; i< gameObjectCount; i++)
            {
                gameObjects[i].Update();
            }
        }

        public void ResetWorld()
        {
            for (int i = 0; i < gameObjectCount; i++)
            {
                gameObjects[i].IsValid = false;
            }
        }

        Tile[,] _GenerateTileMap(string[] map)
        {
            Tile[,] tileMap = new Tile[map.Length ,map[0].Length];

            for (int j = 0; j < _map.Length; j++)
            {
                for (int i = 0; i < _map[0].Length; i++)
                {
                    //wall
                    if (_map[j][i] == '*')
                    {
                        tileMap[j, i] = new Wall('*');
                        tileMap[j, i].PosX = i;
                        tileMap[j, i].PosY = j;
                    }
                    //floor
                    else if (_map[j][i] == ' ')
                    {
                        tileMap[j, i] = new Floor(' ');
                        tileMap[j, i].PosX = i;
                        tileMap[j, i].PosY = j;
                    }
                }
            }

            return tileMap;
        }
    }
}
