using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class GameObject
    {
        int _posX;
        int _posY;
        char _shape;
        bool _isValid;

        public int PosX { get; set; }
        public int PosY { get; set; }
        public char Shape { get; set; }
        public bool IsValid { get; set; }

        public virtual void Render()
        {

        }

        public virtual void Update()
        {

        }
    }
}
