using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class Monster : GameObject
    {
        public enum eMoveDirection
        {
            UP,
            LEFT,
            DOWN,
            RIGHT
        }

        public Monster()
        {
            PosX = 5;
            PosY = 5;
            Shape = 'M';
            IsValid = true;
        }

        public Monster(int posX, int posY, char shape)
        {
            PosX = posX;
            PosY = posY;
            Shape = shape;
            IsValid = true;
        }

        int _GetRandomDirection()
        {
            Random random = new Random();
            int ret = random.Next(0, 4);
            return ret;
        }

        void _Move(eMoveDirection direction)
        {
            if (direction == eMoveDirection.UP)
            {
                if (PosY > 1)
                    PosY--;
            }

            if (direction == eMoveDirection.LEFT)
            {
                if (PosX > 1)
                    PosX--;
            }

            if (direction == eMoveDirection.DOWN)
            {
                if (PosY < 8)
                    PosY++;
            }

            if (direction == eMoveDirection.RIGHT)
            {
                if (PosX < 8)
                    PosX++;
            }
        }

        public override void Update()
        {
            if (!IsValid)
                return;

            _Move((eMoveDirection)_GetRandomDirection());
        }

        public override void Render()
        {
            if (!IsValid)
                return;

            Console.SetCursorPosition(PosX, PosY);
            Console.Write(Shape);
        }
    }
}
