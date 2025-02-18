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

            if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
            {
                if (_IsValidMove(eMoveDirection.UP))
                    _Move(eMoveDirection.UP);
            }

            if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
            {
                if (_IsValidMove(eMoveDirection.LEFT))
                    _Move(eMoveDirection.LEFT);
            }

            if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
            {
                if (_IsValidMove(eMoveDirection.DOWN))
                    _Move(eMoveDirection.DOWN);
            }

            if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
            {
                if (_IsValidMove(eMoveDirection.RIGHT))
                    _Move(eMoveDirection.RIGHT);
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

        bool _IsValidMove(eMoveDirection direction)
        {
            if (direction == eMoveDirection.UP)
            {
                int newY = PosY - 1;

                if (newY < 0)
                    return false;

                if (!Engine.GetInstance().World.TileMap[PosX, newY].IsWalkable)
                    return false;
            }
            else if (direction == eMoveDirection.LEFT)
            {
                int newX = PosX - 1;

                if (newX < 0)
                    return false;

                if (!Engine.GetInstance().World.TileMap[newX, PosY].IsWalkable)
                    return false;
            }
            else if (direction == eMoveDirection.DOWN)
            {
                int newY = PosY + 1;

                if (newY >= Engine.GetInstance().World.TileMap.GetLength(0))
                    return false;

                if (!Engine.GetInstance().World.TileMap[PosX, newY].IsWalkable)
                    return false;
            }
            else if (direction == eMoveDirection.RIGHT)
            {
                int newX = PosX + 1;

                if (newX >= Engine.GetInstance().World.TileMap.GetLength(1))
                    return false;

                if (!Engine.GetInstance().World.TileMap[newX, PosY].IsWalkable)
                    return false;
            }
            return true;
        }

        void _Move(eMoveDirection direction)
        {
            if (direction == eMoveDirection.UP)
            {
                PosY--;
            }
            else if (direction == eMoveDirection.LEFT)
            {
                PosX--;
            }
            else if (direction == eMoveDirection.DOWN)
            {
                PosY++;
            }
            else if (direction == eMoveDirection.RIGHT)
            {
                PosX++;
            }
        }
    }
}
