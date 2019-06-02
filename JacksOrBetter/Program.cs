using System;
using System.Drawing;


namespace JacksOrBetter
{
    class Program
    {
        public static Game  game;
        public static Menu menu;
        private const int width = 133;
        private const int height = 25;
        //Main Class to start Game
        static void Main(string[] args)
        {
            //Set Window size to fit game
            //Set characters and background color 
            Console.SetWindowSize(width, height);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            menu = new Menu();
            game = new Game();
            menu.StartMenu();
            
            

        }
        //Changes sates by given integer sateID
        public void GameState(int stateID)
        {
            switch (stateID)
            {
                case 1:
                    Console.Clear();
                    menu.StartMenu();
                    break;
                case 2:
                    Console.Clear();                   
                    game.StartGame();
                    break;
                default:
                    break;
            }

        }
    }
    
}
