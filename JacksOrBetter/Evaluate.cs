using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace JacksOrBetter
{
    class Evaluate
    {
        List<Card> cards;
        public Evaluate()
        {
           

        }
        //Gets Five card list from cardHolder 
        public void GetCards(List<Card> cardList)
        {
            cards = cardList;

        }
        //Returns True if finds atleast one pair of jacks or higher
        public bool CheckPair()
        {
            return cards.GroupBy(h => h.CardRank).Where(g => g.Count() == 2).Count() == 1 && cards.Where(h => h.CardRank > 10).Any();
        }
        //Returns True if finds two any pairs
        public bool CheckTwoPair()
        {
            return cards.GroupBy(h => h.CardRank)
                .Where(g => g.Count() == 2)
                .Count() == 2;
        }
        //Returns True if finds three same rank cards
        public bool CheckThreeOfAKind()
        {
            return cards.GroupBy(h => h.CardRank)
                .Where(g => g.Count() == 3)
                .Any();
        }
        //Returns True if finds four same rank cards
        public bool CheckFourOfAKind()
        {
            return cards.GroupBy(h => h.CardRank)
                .Where(g => g.Count() == 4)
                .Any();
        }
        //Returns True if finds all same type
        public bool CheckFlush()
        {
            return cards.GroupBy(h => h.CardType).Count() == 1;
        }
        //Returns True if two methods returns true two
        public bool CheckFullHouse()
        {
                return CheckPair() && CheckThreeOfAKind();
            
        }
        //Returns True if finds rank sequence
        public bool CheckStraight()
        {
            var byOrder = cards.OrderBy(h => h.CardRank).ToArray();
            var straightStart = (int)byOrder.First().CardRank;
            for (int i = 1; i < byOrder.Length; i++)
            {
                if((int)byOrder[i].CardRank != straightStart + i)
                    return false;
            }
        return true;
        }
        //Returns True if two methods returns true two
        public bool CheckStraightFlush()
        {
            return CheckStraight() && CheckFlush();

        }
        //Returns True if two methods returns true two and two of cards are Ace and King
        public bool CheckRoyalFlush()
        {
            return CheckStraight() && CheckFlush() && cards.Where(h => h.CardTitle == "A").Any() && cards.Where(h => h.CardTitle == "K").Any();

        }
    }
}
