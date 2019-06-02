using System;
using System.Collections.Generic;
using System.Text;

namespace JacksOrBetter
{
    class Menu
    {
        Program program;
        
        public void StartMenu()
        {
            program = new Program();
            Console.WriteLine("\n\n\n\n\n ");
            Console.WriteLine("__                                                      Jacks or Better                                                          __ \n \n \n");
            Console.WriteLine("                                                  PRESS ENTER TO START A GAME");
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                Console.WriteLine(keyinfo.Key + " was pressed");
                if(keyinfo.Key == ConsoleKey.Enter) {
                    program.GameState(2);
                }
            }
            while (keyinfo.Key != ConsoleKey.Enter);
        }
    }
}
