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
        public string CardName => name;

        public char CardType => type;
        public int CardRank => rank;
        public string CardTitle => title;
        public ConsoleColor CardColor() {
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
