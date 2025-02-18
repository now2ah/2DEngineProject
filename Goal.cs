using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class Goal : GameObject
    {
        public Goal()
        {
            PosX = 8;
            PosY = 8;
            Shape = 'G';
            IsValid = true;
        }

        public Goal(int posX, int posY, char shape)
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
