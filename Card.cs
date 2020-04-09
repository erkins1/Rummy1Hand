using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy
{
    //Code adapted from https://samjenkins.com/deck-of-cards-in-c/
    public class Card
    {
        public Suit Suit { get; set; }
        public CardNumber CardNumber { get; set; }

        //public string CardName { get; set; }

        //Return a simple name for the card
        public override string ToString()
        {
            int n = (int)CardNumber;
            string value;

            switch (n)
            {
                case 11:
                    value = "J";
                    break;
                case 12:
                    value = "Q";
                    break;
                case 13:
                    value = "K";
                    break;
                case 1:
                    value = "A";
                    break;
                default:
                    value = n.ToString();
                    break;
            }

            string symbol = "";
            int s = (int)Suit;
            //clubs (♣), diamonds (♦), hearts (♥), and spades (♠)
            switch (s)
            {
                case 1:
                    symbol = "♣";
                    break;
                case 2:
                    symbol = "♦";
                    break;
                case 3:
                    symbol = "♥";
                    break;
                case 4:
                    symbol = "♠";
                    break;
            }

            //CardName = value + " " + symbol;
            return value + " " + symbol;
        }

        //Return a string for simple analysis
        public string Out()
        {
            int n = (int)CardNumber;
            int s = (int)Suit;

            string output;
            output = n.ToString();
            output += "-";
            output += s.ToString();

            return output;
        }

        //Return the rummy value of the card
        public int RummyValue()
        {
            int cardNum = (int)CardNumber;
            int value = 0;

            if (cardNum <= 2)
            {
                value = 20;
            } else if (cardNum <= 7)
            {
                value = 5;
            } else if (cardNum <= 13)
            {
                value = 10;
            }

            return value;
        }


        //Return the path for the image used
        public string CardImg()
        {
            string s = nameof(Suit);
            s = s.Substring(0, 1);
            int n = (int) CardNumber;
            string value;

            switch (n)
            {
                case 11:
                    value = "J";
                    break;
                case 12:
                    value = "Q";
                    break;
                case 13:
                    value = "K";
                    break;
                case 1:
                    value = "A";
                    break;
                default:
                    value = n.ToString();
                    break;
            }

            string path = "/Images/" + value + s + ".jpg";
            return path;
        }

    }

    public enum Suit
    {
        Club = 1,
        Diamond = 2,
        Heart = 3,
        Spades = 4,
    }

    public enum CardNumber
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
}
