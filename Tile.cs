using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class Tile
    {
        int posX;
        int posY;
        char _shape;
        bool _isWalkable;
        bool _isValid;

        public int PosX { get; set; }
        public int PosY { get; set; }
        public char Shape { get { return _shape; } set { _shape = value; } }
        public bool IsWalkable { get { return _isWalkable; } set { _isWalkable = value; } }
        public bool IsValid { get; set; }

        public Tile(char shape)
        {
            _shape = shape;
            _isValid = true;
        }

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            if (!IsValid)
                return;

            Console.SetCursorPosition(PosX, PosY);
            Console.Write(Shape);
        }
    }
}
