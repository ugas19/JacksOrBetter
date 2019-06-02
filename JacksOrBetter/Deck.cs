using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace JacksOrBetter
{
    class Deck
    {
        public Card[] card;
        private static Random rng = new Random();
        int index = 0;
        public List<Card> deckForGame;
        public  Deck()
        {
            deckForGame = new List<Card>();
            //Make 52 cards for game with given details
            card = new Card[52];
            foreach (string name in new[] { "Clubs", "Spade", "Heart", "Diamo" })
            {
                for (int rank = 2; rank <= 10; rank ++)
                {
                    card[index++] = new Card(rank.ToString()+"    " + name, rank.ToString(), name,rank);
                }
                card[index++] = new Card("Jack " + name, "J", name,11);
                card[index++] = new Card("Queen" + name, "Q", name,12);
                card[index++] = new Card("King " + name, "K", name,13);
                card[index++] = new Card("Ace  " + name, "A", name,14);

            }
            //Add 52 cards to new list
           for(int s = 0; s < 52; s++)
            {
                deckForGame.Add(card[s]);
            }
            
        }
        public void Shuffle()
        {
            //Shuffles 52 cards by random positions
            int n = deckForGame.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deckForGame[k];
                deckForGame[k] = deckForGame[n];
                deckForGame[n] = value;
            }

        }
    }
}
