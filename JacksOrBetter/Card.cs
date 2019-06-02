using System;
using System.Collections.Generic;
using System.Text;

namespace JacksOrBetter
{
    public class Card
    {
        private string title, name;
        private int rank;
        private char type;

        public Card(string cardTitle, string cardName, string cardType,int cardRank)
        {
            title = cardTitle;
            name = cardName;
            type = cardType[0];
            rank = cardRank;
        }
        //Returns string
        public string CardName => name;

        //Returns char
        public char CardType => type;
        //Returns int
        public int CardRank => rank;
        //Returns string
        public string CardTitle => title;
        //Class used outside to pick color by type
        public ConsoleColor CardColor() {
            //Return Color for sertain type
             switch (CardType){
                case'C':
                    return(ConsoleColor.DarkGray);
                    
                case 'S':
                    return (ConsoleColor.Black);
                case 'H':
                    return (ConsoleColor.Red);
                case 'D':
                    return (ConsoleColor.DarkRed);
                default:
                    return (ConsoleColor.Black);
            }
        }
        

    }
}
