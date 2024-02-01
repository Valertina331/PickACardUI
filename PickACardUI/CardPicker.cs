using System;
using System.Linq;

namespace PickACardUI
{
    class CardPicker
    {
        static Random random = new Random();
        static string[] cards = new string[52];
        static int cardsLeft = 52;

        static CardPicker()
        {
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
            int cardCounter = 0;
            for(int cardVal = 1; cardVal <= 13; cardVal++)
            {
                foreach(string cardSuit in suits)
                {
                    string cardName;
                    cardName = cardVal.ToString();
                    cards[cardCounter] = cardName + " of " + cardSuit;
                    cardCounter++;
                }
            }
            for(var i = 0; i < 52; i++)
            {
                Console.WriteLine(cards[i]);
            }
        }

        public static string[] PickSomeCards(int numberOfCards)
        {
            if (numberOfCards > cardsLeft)
            {
                throw new InvalidOperationException("Not enough cards in the deck.");
            }
            
            string[] pickedCards = new string[numberOfCards];
            for(int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = RandomCard();
                cardsLeft--;
            }
            return pickedCards;
        }

        private static string RandomCard()
        {
            int cardNum = random.Next(0, cards.Length);
            string picked = cards[cardNum];
            cards = cards.Where(e => e != picked).ToArray();
            return picked;
        }

        public static int RemainingCards() 
        { 
            return cardsLeft;
        }
    }
}
