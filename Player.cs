using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class Player : GameObject
    {
        public Player()
        {
            PosX = 2;
            PosY = 2;
            Shape = 'c';
            IsValid = true;
        }

        public Player(int posX, int posY, char shape)
        {
            PosX = posX;
            PosY = posY;
            Shape = shape;
            IsValid = true;
        }



        public override void Update()
        {
            if (!IsValid)
                return;

            _ProcessInput();

            if (_IsDead())
            {
                Engine.GetInstance().GameOver();
            }

            if (_IsGoal())
            {
                Engine.GetInstance().ResetGame();
            }
        }

        public override void Render()
        {
            if (!IsValid)
                return;

            Console.SetCursorPosition(PosX, PosY);
            Console.Write(Shape);
        }

        void _ProcessInput()
        {
            ConsoleKey key = Engine.GetInstance().Input.KeyInfo.Key;

            if (key == ConsoleKey.W)
            {
                if (PosY > 1)
                    PosY--;
            }

            if (key == ConsoleKey.A)
            {
                if (PosX > 1)
                    PosX--;
            }

            if (key == ConsoleKey.S)
            {
                if (PosY < 9)
                    PosY++;
            }

            if (key == ConsoleKey.D)
            {
                if (PosX < 9)
                    PosX++;
            }
        }

        bool _IsGoal()
        {
            for (int i=0; i<Engine.GetInstance().World.GameObjectCount; i++)
            {
                if (Engine.GetInstance().World.GameObjects[i] is Goal)
                {
                    if (Engine.GetInstance().World.GameObjects[i].PosX == PosX &&
                        Engine.GetInstance().World.GameObjects[i].PosY == PosY)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool _IsDead()
        {
            for (int i = 0; i < Engine.GetInstance().World.GameObjectCount; i++)
            {
                if (Engine.GetInstance().World.GameObjects[i] is Monster)
                {
                    if (Engine.GetInstance().World.GameObjects[i].PosX == PosX &&
                        Engine.GetInstance().World.GameObjects[i].PosY == PosY)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
