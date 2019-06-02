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
        private List<Card> fiveCards;

        public CardHolder()
        {
            hWidth = 5;
            hHeight = 3;
            hLocation = new Point(24, 12);
            fiveCards = new List<Card>();

        }
        public List<Card> FiveCards => fiveCards;
        public void AddCards(List<Card> list)
        {
            fiveCards = list;
            
            
            //Console.WriteLine(fiveCards[0].CardTitle);
        }

        //Returns location for cursor
        private Point Location => hLocation;
        //Returns card width
        private int Width => hWidth;
        //Returns card height
         private int Height => hHeight;


        public void Draw()
        { 
            //Fill long string 'cardString' with characters to draw cards
            
            string cardString = "";
            string temp = "";
            string space = "         ";
            //TOP of five cards
            for (int z = 0; z < numberOfCards; z++)
            {
                cardString += "╔";
                for (int i = 0; i < Width; i++)
                {
                    cardString += "═";
                }


                cardString += "╗" + space;
            }
            //temp is space in beginning for first card
            for (int j = 0; j < Location.X; j++)
                temp += " ";

            //Start middle card drawing
            cardString += "\n";

            for (int f = 0; f < Height; f++)
            {
                if (f == 2)
                {
                    //Add middle borders and card name with type inside 
                    //Ten is only card which takes two string spots to print so has exeption
                    //if card is not 10 then string space is one char longer
                    if (fiveCards[0].CardName != "10")
                    {
                        cardString += temp + "║" + fiveCards[0].CardName + "   " + fiveCards[0].CardType + "║";
                    }
                    else cardString += temp + "║" + fiveCards[0].CardName + "  " + fiveCards[0].CardType + "║";

                    for (int i = 1; i < numberOfCards; i++)
                        if (fiveCards[i].CardName != "10")
                        {
                            cardString += space + "║" + fiveCards[i].CardName + "   " + fiveCards[i].CardType + "║";
                        } else cardString += space + "║" + fiveCards[i].CardName + "  " + fiveCards[i].CardType + "║";
                    cardString += "\n";
                }
                
                else if(f == 0)
                {
                    if (fiveCards[0].CardName != "10")
                    {
                        cardString += temp + "║" + fiveCards[0].CardType + "   " + fiveCards[0].CardName + "║";
                    }
                    else cardString += temp + "║" + fiveCards[0].CardType + "  " + fiveCards[0].CardName + "║";

                    for (int i = 1; i < numberOfCards; i++)
                        if (fiveCards[i].CardName != "10")
                        {
                            cardString += space + "║" + fiveCards[i].CardType + "   " + fiveCards[i].CardName + "║";
                        }else cardString += space + "║" + fiveCards[i].CardType + "  " + fiveCards[i].CardName + "║";
                    cardString += "\n";
                }
                else
                {
                    cardString += temp + "║" + "     " + "║";
                    for (int i = 1; i < numberOfCards; i++)
                        cardString += space + "║"+ "     " + "║";
                    cardString += "\n";
                }
            }//Draw bottom of cards with beginning space
            cardString += temp;
            for (int f = 0; f < numberOfCards; f++)
            {
                cardString += "╚";
                for (int i = 0; i < Width; i++)
                    cardString += "═";

                cardString += "╝" + space;//+ "\n";
            }
            // Add all card titles under cards
            cardString += "\n";
            cardString += "                       " + fiveCards[0].CardTitle;
            space = "      ";
            for (int f = 1; f < numberOfCards; f++)
            {
                cardString += space + fiveCards[f].CardTitle;
               
            }
            cardString +=  "    ";
            cardString += "\n";

            //Start drawing cards on wanted position and reset all colors
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorTop = hLocation.Y;
            Console.CursorLeft = hLocation.X;
            PickColor(cardString);
            Console.ResetColor();
            
        }
        public void PickColor(string cardString)
        {
            //Split long text to 5 parts to be able to color it separate
            
            int lengh = cardString.Length / 36;
            int currentlenght = 0;
            for (int r = 0; r < 36; r++)
            {
                if (r == 0 || r == 6 || r == 12 || r == 18 || r == 24)
                {
                    Console.ForegroundColor = fiveCards[0].CardColor();
                    Console.Write(cardString.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else if ((r == 1 || r == 7 || r == 13 || r == 19 || r == 25))
                {
                    Console.ForegroundColor = fiveCards[1].CardColor();
                    Console.Write(cardString.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else if ((r == 2 || r == 8 || r == 14 || r == 20 || r == 26))
                {
                    Console.ForegroundColor = fiveCards[2].CardColor();
                    Console.Write(cardString.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else if ((r == 3 || r == 9 || r == 15 || r == 21 || r == 27))
                {
                    Console.ForegroundColor = fiveCards[3].CardColor();
                    Console.Write(cardString.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else if ((r == 4 || r == 10 || r == 16 || r == 22 || r == 28))
                {
                    Console.ForegroundColor = fiveCards[4].CardColor();
                    Console.Write(cardString.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(cardString.Substring(currentlenght, lengh));
                    currentlenght += lengh;
                }

            }

        }
    }
}
