using System;
using System.Collections.Generic;
using System.Text;

namespace JacksOrBetter
{
    class Game
    {
        public static CardHolder cards;
        public static Deck deck;
        public static Cash money;
        public static Evaluate evaluate;
        private List<Card> cardHolder;
        private int currentIndex = 0;
        private int moneyLine;
        ConsoleKeyInfo keyinfo;
        static private string holdText = "HOLD";
        static private string emptyText = "    ";
        string[] holdCurrentText = { emptyText, emptyText, emptyText, emptyText, emptyText };
        //private int[] currentHoldState;
        Program program;


        public void StartGame()
        {
            money = new Cash();
            program = new Program();
            cardHolder = new List<Card>();
            deck = new Deck();
            evaluate = new Evaluate();
            cards = new CardHolder(ConsoleColor.Red);
            money.Money = 100;
            
            PrintPayTable();
            Talk();
            while (true)
            {
                SetCursor();
                Console.WriteLine(" Press numbers 1-5 to Hold cards");
                DealCards();
                ChangeMoney(-1);
                PickCard();
                DrawCards();
                SetCursor();
                Console.WriteLine(Check());
                Console.WriteLine("Press Enter to Play Again Or Escape to get to Menu");
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.Escape)
                {
                    program.GameState(1);

                }SetCursor();
                DeleteLine(-2);
                DeleteLine(1);
                
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

            }
        }
        public void ChangeMoney(int amount)
        {
            money.Money = money.Money + amount; 
            Console.SetCursorPosition(0, moneyLine);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, moneyLine);
            Console.WriteLine("                                                                                                                 Money: {0}", money.Money);
        }
        public void Talk()
        {
            moneyLine = Console.CursorTop;
            Console.WriteLine("                                                                                                                 Money: {0}",money.Money);
            Console.WriteLine("                                                      Press any key to start a new hand");
            Console.ReadLine();
            DeleteLine(2);
        }
        public void DealCards()
        {
            currentIndex = 0;
            cardHolder.Clear();
            deck.Shuffle();
            for (int x = 0; x < 5; x++)
            {
                cardHolder.Add(deck.deckForGame[51 - currentIndex]);
                currentIndex++;

            }
            cards.AddCards(cardHolder);
            cards.Draw();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void DrawCards() {
            for (int d = 0; d < 5; d++)
            {
                if (holdCurrentText[d] == emptyText)
                {
                    cardHolder[d] = (deck.deckForGame[51 - currentIndex]);
                    currentIndex++;
                }
            }
            cards.AddCards(cardHolder);
            cards.Draw();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

        }
        public string Check()
        {
            evaluate.GetCards(cardHolder);
            if (evaluate.CheckRoyalFlush()) return Pay("RoyalFlush");
            if (evaluate.CheckStraightFlush()) return Pay("StraightFlush");
            if (evaluate.CheckFourOfAKind()) return Pay("FourOfAKind");
            if (evaluate.CheckFullHouse()) return Pay("FullHouse");
            if (evaluate.CheckFlush()) return Pay("Flush");
            if (evaluate.CheckStraight()) return Pay("Straight");
            if (evaluate.CheckThreeOfAKind()) return Pay("ThreeOfAKind");
            if (evaluate.CheckTwoPair()) return Pay("TwoPair");
            if (evaluate.CheckPair()) return Pay("Pair");
            return "Empty hand, try again.";
        }
        public string Pay(string result)
        {
            switch(result)
            {
                case "Pair":
                    ChangeMoney(1);
                    return result;
                case "TwoPair":
                    ChangeMoney(2);
                    return result;
                case "ThreeOfAKind":
                    ChangeMoney(3);
                    return result;
                case "FourOfAKind":
                    ChangeMoney(25);
                    return result;
                case "Straight":
                    ChangeMoney(4);
                    return result;
                case "Flush":
                    ChangeMoney(6);
                    return result;
                case "FullHouse":
                    ChangeMoney(9);
                    return result;
                case "StraightFlush":
                    ChangeMoney(50);
                    return result;
                case "RoyalFlush":
                    ChangeMoney(800);
                    return result;
                default:
                    return "Empty hand, try again.";
            }

        }
        public void PrintPayTable()
        {
            Console.WriteLine("                                                           Pay Table");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Royal Flush | Straight Flush | Four of a kind | FullHouse | Flush | Straight | Three of a kind |  Two Pair | Jacks or Better|");
            Console.WriteLine("|-----------------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    800      |        50      |        25      |     9     |   6   |    4     |         3       |     2     |        1       |");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
            
        }
        public void SetCursor()
        {
            Console.SetCursorPosition(0, moneyLine + 1);
            DeleteLine(0);

        }
        public void DeleteLine(int lineAbove)
        {
            int s = Console.CursorTop;
            Console.SetCursorPosition(0, s - lineAbove);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, s - lineAbove);
        }
        public void PickCard()
        {
            holdCurrentText = new string[] { emptyText, emptyText, emptyText, emptyText, emptyText };
            Hold(5);
            do
            {
                keyinfo = Console.ReadKey();
                switch (keyinfo.Key)
                {
                    case ConsoleKey.D1:
                        Hold(0);
                        break;
                    case ConsoleKey.D2:
                        Hold(1);
                        break;
                    case ConsoleKey.D3:
                        Hold(2);
                        break;
                    case ConsoleKey.D4:
                        Hold(3);
                        break;
                    case ConsoleKey.D5:
                        Hold(4);
                        break;
                    default:
                        Hold(5);
                        break;
                }
               
            }
            while (keyinfo.Key != ConsoleKey.Enter);
        }
        
        public void Hold(int state)
        {
            
            switch (state)
            {
                case 0:
                    holdCurrentText[state] = (holdCurrentText[state] == emptyText) ? holdText : emptyText;
                    break;
                case 1:
                    holdCurrentText[state] = (holdCurrentText[state] == emptyText) ? holdText : emptyText;
                    break;
                case 2:
                    holdCurrentText[state] = (holdCurrentText[state] == emptyText) ? holdText : emptyText;
                    break;
                case 3:
                    holdCurrentText[state] = (holdCurrentText[state] == emptyText) ? holdText : emptyText;
                    break;
                case 4:
                    holdCurrentText[state] = (holdCurrentText[state] == emptyText) ? holdText : emptyText;
                    break;
                default:
                    break;

            }
            string holdS = "                        " + holdCurrentText[0] + "            " + holdCurrentText[1] + "             " + holdCurrentText[2] + "            " + holdCurrentText[3] + "            " + holdCurrentText[4];
            Console.SetCursorPosition(0, 11);
            Console.WriteLine(holdS);
            Console.SetCursorPosition(0, moneyLine + 1);

        }
    }
}
