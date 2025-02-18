using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class Wall : Tile
    {
        public Wall(char shape) : base(shape)
        {
            IsWalkable = false;
            IsValid = true;
        }

        public override void Update()
        {
            
        }

        public override void Render()
        {
            base.Render();
        }
    }
}
