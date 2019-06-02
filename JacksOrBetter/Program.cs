using System;
using System.Drawing;


namespace JacksOrBetter
{
    class Program
    {
        public static Game  game;
        public static Menu menu;
        static void Main(string[] args)
        {

            Console.SetWindowSize(Console.WindowWidth * 5 / 3, Console.WindowHeight);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            menu = new Menu();
            game = new Game();
            menu.StartMenu();
            
            

        }
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
