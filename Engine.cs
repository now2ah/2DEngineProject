using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DEngineProject._2DEngineProject
{
    public class Engine
    {
        static Engine _instance;

        World _world;

        Input _input;

        bool _isRunning;

        public Input Input { get { return _input; } }
        public World World { get { return _world; } }

        public static Engine GetInstance()
        {
            if (null == _instance)
            {
                _instance = new Engine();
            }

            return _instance;
        }

        private Engine()
        {

        }

        public void Load()
        {
            if (null == _world)
            {
                _world = new World();
                _input = new Input();
                _isRunning = true;
            }
        }

        public void Run()
        {
            _world.StartWorld();
            while (_isRunning)
            {
                _ProcessInput();
                _Update();
                _Render();
            }
        }

        public void ResetGame()
        {
            _world.ResetWorld();
            Load();
            Run();
        }

        public void GameOver()
        {
            _isRunning = false;
        }

        void _ProcessInput()
        {
            _input.GetInput();
        }

        void _Update()
        {
            _world.Update();
        }

        void _Render()
        {
            Console.Clear();
            _world.Render();
        }
    }
}
