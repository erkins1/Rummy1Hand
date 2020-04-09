using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy
{
    //Code adapted from https://samjenkins.com/deck-of-cards-in-c/
    class Deck
    {
        public Deck()
        {
            Reset();
        }

        public List<Card> Cards { get; set; }

        public void Reset()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                                    .Select(c => new Card()
                                    {
                                        Suit = (Suit)s,
                                        CardNumber = (CardNumber)c
                                    })).ToList();
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public Card TakeCard()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }

        public IEnumerable<Card> TakeCards(int numberOfCards)
        {
            var cards = Cards.Take(numberOfCards);

            var takeCards = cards as Card[] ?? cards.ToArray();
            Cards.RemoveAll(takeCards.Contains);

            return takeCards;
        }

        //Remove Card
        public void RemoveCard(Card removedCard)
        {
            Cards.Remove(removedCard);
        }


        //Return the rummy value of the deck
        public int getRummyValue()
        {
            return 0;
        }

        //Add a single card to this deck
        public void addCard(Card newCard)
        {
            Cards.Insert(0, newCard);
        }

        //Add multiple cards to this deck
        public void addCards(IEnumerable<Card> AddedCards)
        {



        }

        //Print out all the cards in this deck
        public string Out()
        {
            string output;

            output = "[ ";

            if (Cards.Any())
            {
                foreach (Card card in Cards)
                {
                    output += card.Out() + " ";
                }
            }
            output += "]";

            return output;
        }

        //Returns the number of cards in the deck
        public int numCards()
        {
            return 0;
        }
    }
}
