using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class Input
    {
        ConsoleKeyInfo _keyInfo;

        public ConsoleKeyInfo KeyInfo => _keyInfo;

        public void GetInput()
        {
            _keyInfo = Console.ReadKey();
        }
    }
}
