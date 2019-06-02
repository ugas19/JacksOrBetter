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
        public void GetCards(List<Card> cardList)
        {
            cards = cardList;

        }
        public bool CheckPair()
        {
                return cards.GroupBy(h => h.CardRank)
                    .Where(g => g.Count() == 2)
                    .Count() == 1;
        }
        public bool CheckTwoPair()
        {
            return cards.GroupBy(h => h.CardRank)
                .Where(g => g.Count() == 2)
                .Count() == 2;
        }
        public bool CheckThreeOfAKind()
        {
            return cards.GroupBy(h => h.CardRank)
                .Where(g => g.Count() == 3)
                .Any();
        }
        public bool CheckFourOfAKind()
        {
            return cards.GroupBy(h => h.CardRank)
                .Where(g => g.Count() == 4)
                .Any();
        }
        public bool CheckFlush()
        {
            return cards.GroupBy(h => h.CardType).Count() == 1;
        }
        public bool CheckFullHouse()
        {
                return CheckPair() && CheckThreeOfAKind();
            
        }
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
        public bool CheckStraightFlush()
        {
            return CheckStraight() && CheckFlush();

        }
        public bool CheckRoyalFlush()
        {
            return CheckStraight() && CheckFlush() && cards.Where(h => h.CardTitle == "A").Any() && cards.Where(h => h.CardTitle == "K").Any();

        }
    }
}
