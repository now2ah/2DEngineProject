using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class Floor : Tile
    {
        public Floor(char shape) : base(shape)
        {
            IsWalkable = true;
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
