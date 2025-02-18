using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class World
    {
        string[,] _map =
        {
            { "**********" },
            { "*        *" },
            { "*        *" },
            { "*        *" },
            { "*        *" },
            { "*        *" },
            { "*        *" },
            { "*        *" },
            { "*        *" },
            { "**********" } 
        };

        GameObject[] gameObjects = new GameObject[100];

        int gameObjectCount = 0;
        

        public string[,] Map { get { return _map; } }
        public GameObject[] GameObjects { get { return gameObjects; } }
        public int GameObjectCount { get { return gameObjectCount; } }

        public void StartWorld()
        {
            gameObjects[gameObjectCount++] = new Player(3, 3, 'P');
            gameObjects[gameObjectCount++] = new Monster(6, 6, 'M');
            gameObjects[gameObjectCount++] = new Goal(8, 8, 'G');
        }

        public void Render()
        {
            for (int j = 0; j < _map.GetLength(0); j++)
            {
                for (int i = 0; i < _map.GetLength(1); i++)
                {
                    Console.Write(_map[j,i]);
                    Console.Write("\n");
                }
            }

            for (int i=0; i< gameObjectCount; i++)
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
    }
}
