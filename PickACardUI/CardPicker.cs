using System;
using System.Linq;

namespace PickACardUI
{
    class CardPicker
    {
        static Random random = new Random();
        static string[] cards = new string[52];

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
            string[] pickedCards = new string[numberOfCards];
            for(int i = 0; i < numberOfCards; i++)
            {
                // pickedCards[i] = RandomValue() + "of" + RandomSuit();
                pickedCards[i] = RandomCard();
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

        private static string RandomValue()
        {
            int value = random.Next(1, 14);
            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";
            return value.ToString();
        }

        private static string RandomSuit()
        {
            int value = random.Next(1, 5);
            if (value == 1) return "Spades";
            if (value == 2) return "Hearts";
            if (value == 3) return "Clubs";
            return "Diamonds";
        }
        /*
        static void Main(string[] args)
        {
            Console.Write("Enter the number of cards to pick: ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int numberOfCards))
            {
                foreach (string card in CardPicker.PickSomeCards(numberOfCards))
                {
                    Console.WriteLine(card);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
        */
    }
}
