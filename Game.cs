using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy
{
    class Game
    {
        public static Deck DrawDeck { get; set; }
        public static Deck DiscardDeck { get; set; }
        public static Deck PlayerDeck { get; set; }
        public static Deck ComputerDeck { get; set; }

        public static int ComputerLevel { get; set; }
        public static int PlayerLevel { get; set; }

        public static int PlayerTurn { get; set; }
        public static int CurrentHand { get; set; }
        
        //Properties to simplify the out method
        public static int TurnNumber { get; set; }
        public static string DrawFrom { get; set; }
        public static Card DrawnCard { get; set; }
        public static Card DiscardedCard { get; set; }
        public static Deck PlayerFromDiscard { get; set; }
        public static Deck ComputerFromDiscard { get; set; }

        //Starts the game
        public Game()
        {
            DrawDeck = new Deck();
            DrawDeck.Shuffle();

            DiscardDeck = new Deck();
            DiscardDeck.TakeCards(52);
            
            PlayerDeck = new Deck();
            PlayerDeck.TakeCards(52);
            
            ComputerDeck = new Deck();
            ComputerDeck.TakeCards(52);

            PlayerFromDiscard = new Deck();
            PlayerFromDiscard.TakeCards(52);

            ComputerFromDiscard = new Deck();
            ComputerFromDiscard.TakeCards(52);
        }

        public static string Out()
        {
            string output;

            output = "\nTurn: " + TurnNumber.ToString();
            output += "\nHand: " + CurrentHand.ToString();
            output += "\nComputer Level: " + ComputerLevel.ToString();
            if (PlayerLevel != 0)
            {
                output += "\nPlayer Level: " + PlayerLevel.ToString();
            }
            output += "\nPlayer: " + PlayerTurn.ToString();
            output += "\nDrawn From: " + DrawFrom;

            if (DrawnCard != null)
            {
                output += "\nDrew: " + DrawnCard.Out();
                output += "\nDiscarded: " + DiscardedCard.Out();
            }

            output += "\nDraw Deck: " + DrawDeck.Out();
            output += "\nDiscard Deck: " + DiscardDeck.Out();
            output += "\nPlayer Deck: " + PlayerDeck.Out();
            output += "\nComputer Deck: " + ComputerDeck.Out();

            output += "\n";

            return output;
        }

        public static string CommaOut()
        {
            string output;

            output = "\n" + TurnNumber.ToString();
            output += ", " + CurrentHand.ToString();
            output += ", " + ComputerLevel.ToString();
            if (PlayerLevel != 0)
            {
                output += ", " + PlayerLevel.ToString();
            }else
            {
                output += ", ";
            }
            output += ", " + PlayerTurn.ToString();
            output += ", " + DrawFrom;

            if (DrawnCard != null)
            {
                output += ", " + DrawnCard.Out();
                output += ", " + DiscardedCard.Out();
            } else
            {
                output += ", , ";
            }

            output += ", " + DrawDeck.Out();
            output += ", " + DiscardDeck.Out();
            output += ", " + PlayerDeck.Out();
            output += ", " + ComputerDeck.Out();
            output += ", " + PlayerFromDiscard.Out();
            output += ", " + ComputerFromDiscard.Out();

            return output;
        }

    }
}
