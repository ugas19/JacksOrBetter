using System;
using System.Collections.Generic;
using System.Text;

namespace JacksOrBetter
{
    class Menu
    {
        Program program;
        
        //Read pressed key and change to other Game class
        public void StartMenu()
        {
            program = new Program();
            Console.WriteLine("\n\n\n\n\n ");
            Console.WriteLine("__                                                      Jacks or Better                                                          __ \n \n \n");
            Console.WriteLine("                                                  PRESS ENTER TO START A GAME");
            ConsoleKeyInfo keyinfo;
            do
            {
                // Read pressed ket
                keyinfo = Console.ReadKey();
                Console.WriteLine(keyinfo.Key + " was pressed");
                // If pressed Key is Enter changes class to main game class
                if(keyinfo.Key == ConsoleKey.Enter) {
                    program.GameState(2);
                }
            }
            while (keyinfo.Key != ConsoleKey.Enter);
        }
    }
}
