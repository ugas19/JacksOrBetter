using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace JacksOrBetter
{
    public class CardHolder
    {
        private int hWidth, hHeight;
        const int numberOfCards = 5;
        private Point hLocation;
        private ConsoleColor hBorderColor;
        private List<Card> fiveCards;

        public CardHolder(ConsoleColor borderColor)
        {
            hWidth = 5;
            hHeight = 3;
            hLocation = new Point(24, 12);
            hBorderColor = borderColor;
            fiveCards = new List<Card>();

        }
        public List<Card> FiveCards()
        {
            return (fiveCards);
          
        }
        public void AddCards(List<Card> list)
        {
            fiveCards = list;
            
            
            //Console.WriteLine(fiveCards[0].CardTitle);
        }

        private Point Location => hLocation;
        private int Width => hWidth;
         private int Height => hHeight;

        public ConsoleColor BorderColor
        {
            get => hBorderColor;
            set => hBorderColor = value; 
        }

        public void Draw()
        {
            string s = "";
            string temp = "";
            string space = "         ";
            for (int z = 0; z < numberOfCards; z++)
            {
                s += "╔";
                for (int i = 0; i < Width; i++)
                {
                    s += "═";
                }


                s += "╗" + space;
            }
            for (int j = 0; j < Location.X; j++)
                temp += " ";

            s += "\n";

            for (int f = 0; f < Height; f++)
            {
                if (f == 2)
                {
                    if (fiveCards[0].CardName != "10")
                    {
                        s += temp + "║" + fiveCards[0].CardName + "   " + fiveCards[0].CardType + "║";
                    }
                    else s += temp + "║" + fiveCards[0].CardName + "  " + fiveCards[0].CardType + "║";

                    for (int i = 1; i < numberOfCards; i++)
                        if (fiveCards[i].CardName != "10")
                        {
                            s += space + "║" + fiveCards[i].CardName + "   " + fiveCards[i].CardType + "║";
                        } else s += space + "║" + fiveCards[i].CardName + "  " + fiveCards[i].CardType + "║";
                    s += "\n";
                }
                
                else if(f == 0)
                {
                    if (fiveCards[0].CardName != "10")
                    {
                        s += temp + "║" + fiveCards[0].CardType + "   " + fiveCards[0].CardName + "║";
                    }
                    else s += temp + "║" + fiveCards[0].CardType + "  " + fiveCards[0].CardName + "║";

                    for (int i = 1; i < numberOfCards; i++)
                        if (fiveCards[i].CardName != "10")
                        {
                            s += space + "║" + fiveCards[i].CardType + "   " + fiveCards[i].CardName + "║";
                        }else s += space + "║" + fiveCards[i].CardType + "  " + fiveCards[i].CardName + "║";
                    s += "\n";
                }
                else
                {
                    s += temp + "║" + "     " + "║";
                    for (int i = 1; i < numberOfCards; i++)
                        s += space + "║"+ "     " + "║";
                    s += "\n";
                }
            }
            s += temp;
            for (int f = 0; f < numberOfCards; f++)
            {
                s += "╚";
                for (int i = 0; i < Width; i++)
                    s += "═";

                s += "╝" + space;//+ "\n";
            }
            s += "\n";
            s += "                       " + fiveCards[0].CardTitle;
            space = "      ";
            for (int f = 1; f < numberOfCards; f++)
            {
                s += space + fiveCards[f].CardTitle;
               
            }
            s +=  "    ";
            s += "\n";


            Console.ForegroundColor = BorderColor;
            Console.CursorTop = hLocation.Y;
            Console.CursorLeft = hLocation.X;
            PickColor(s);
            Console.ResetColor();
            
        }
        public void PickColor(string s)
        {
            for(int i = 0; i < 5; i++)
            {
                switch (fiveCards[i].CardType)
                {
                    case 'C':

                        break;
                    case 'S':
                        break;
                    case 'H':
                        break;
                    case 'D':
                        break;
                    default:
                        break;

                }
            }

            int lengh = s.Length / 36;
            int currentlenght = 0;
            for (int r = 0; r < 36; r++)
            {
                if (r == 0 || r == 6 || r == 12 || r == 18 || r == 24)
                {
                    Console.ForegroundColor = fiveCards[0].CardColor();
                    Console.Write(s.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else if ((r == 1 || r == 7 || r == 13 || r == 19 || r == 25))
                {
                    Console.ForegroundColor = fiveCards[1].CardColor();
                    Console.Write(s.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else if ((r == 2 || r == 8 || r == 14 || r == 20 || r == 26))
                {
                    Console.ForegroundColor = fiveCards[2].CardColor();
                    Console.Write(s.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else if ((r == 3 || r == 9 || r == 15 || r == 21 || r == 27))
                {
                    Console.ForegroundColor = fiveCards[3].CardColor();
                    Console.Write(s.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else if ((r == 4 || r == 10 || r == 16 || r == 22 || r == 28))
                {
                    Console.ForegroundColor = fiveCards[4].CardColor();
                    Console.Write(s.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(s.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }

            }

        }
    }
}
