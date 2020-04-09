using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;



namespace Rummy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /**************************************************************
         * New Game set-up code
         * ***********************************************************/

        //Controller to start a new game
        public void newGame()
        {
            //Run cleanup(?) and setup functions
            setup();
            dealCards(13);
            updateDecks();

            //Enable buttons
            drawDeckBtn.Enabled = true;
            drawDiscardBtn.Enabled = true;
            sortSuitBtn.Enabled = true;
            sortValueBtn.Enabled = true;

            Game.ComputerLevel = Decimal.ToInt32(comLvl.Value);
            Game.PlayerLevel = Decimal.ToInt32(playLvl.Value);
            Game.CurrentHand = 1;
            Game.TurnNumber = 0;
            turnLbl.Text = "Current Turn: Player";
            turnLogger();

            //Start the first turn if Two AI players is checked
            if(AI2Check.Checked == true)
            {
                Random rnd = new Random();
                int draw = 1;
                int discard = rnd.Next(1, 14);

                drawAI(draw);
                discardAI(discard);
            }
        }
        
        //Create a new game object
        public void setup()
        {
            Game game = new Game();

            //fullDeckList.DataSource = Game.DrawDeck.Cards;    //This is done with the updateDecks function
            //fullDeckList.DisplayMember = "CardNumber";

            //Set the turn to player 1
            Game.PlayerTurn = 1;
        }

        //Deals cards to computer and user
        public void dealCards(int numCards)
        {
            //Game.PlayerDeck.addCards(Game.DrawDeck.TakeCards(13));

            for (int i = numCards; i > 0; i--)
            {
                Game.PlayerDeck.addCard(Game.DrawDeck.TakeCard());
                Game.ComputerDeck.addCard(Game.DrawDeck.TakeCard());
            }
       
        }


        /**************************************************************
         * Play by play code
         * ***********************************************************/

        //Code that should run after every turn
        public void endTurn()
        {
            //Update the visable decks
            updateDecks();

            Game.TurnNumber++;

            //Records what happened on the turn
            turnLogger();

            //Checks to see if someone won
            if (!validateHands())
            {
                //End the game if there are no more cards in the deck
                if (Game.DrawDeck.Cards.Count() == 0)
                {
                    winnerLbl.Text = "Stalemate";
                    simpleLogger(0);
                    return;
                }

                //Change the current players turn
                switch (Game.PlayerTurn)
                {
                    case 1:
                        Game.PlayerTurn = 2;
                        turnLbl.Text = "Current Turn: Computer";
                        break;
                    case 2:
                        Game.PlayerTurn = 1;
                        turnLbl.Text = "Current Turn: Player";
                        break;
                }

                //If its the computers turn, call the AI function
                if (Game.PlayerTurn == 2)
                {
                    aiController();
                }
                else if (AI2Check.Checked == true && Game.PlayerTurn == 1)
                {
                    playerController(); //If the player is also an AI, this runs
                }
            }
        }

        //Updates the deck lists for each player
        public void updateDecks()
        {
            //Need to set everything to null so that it actually updates
            fullDeckList.DataSource = null;
            comDeckList.DataSource = null;
            handDeckList.DataSource = null;
            discardDeckList.DataSource = null;

            fullDeckList.DataSource = Game.DrawDeck.Cards;
            //fullDeckList.DisplayMember = "ToString";          //This also works the same as leaving it blank

            comDeckList.DataSource = Game.ComputerDeck.Cards;

            //Only the player and discard hands need to stay after testing
            handDeckList.DataSource = Game.PlayerDeck.Cards;
            
            discardDeckList.DataSource = Game.DiscardDeck.Cards;

            //update the card count in the deck
            deckLbl.Text = "Cards Remaining: " + Game.DrawDeck.Cards.Count().ToString();

            //Update the rates
            double chance = 1.0 / Game.DrawDeck.Cards.Count();
            oddsLbl.Text = "Chance of drawing a specific card: " + chance.ToString("P", CultureInfo.InvariantCulture);

        }

        //Draw from the main deck
        public void drawFromDeck()
        {
            //This uses the current turn to know which player should receive the cards
                //Alternative option is to pass in the player whose turn it is
            if (Game.PlayerTurn == 1)
            {
                Card drawn = Game.DrawDeck.TakeCard();
                Game.PlayerDeck.addCard(drawn);
                Game.DrawnCard = drawn;
            }
            else
            {
                Card drawn = Game.DrawDeck.TakeCard();
                Game.ComputerDeck.addCard(drawn);
                Game.DrawnCard = drawn;
            }

            Game.DrawFrom = "Deck";
            drawDiscardChange(false);
            updateDecks();

        }

        //Draw from the discard
        public void drawFromDiscard()
        {

            if (Game.PlayerTurn == 1)
            {
                Card drawn = Game.DiscardDeck.TakeCard();
                Game.PlayerDeck.addCard(drawn);
                Game.PlayerFromDiscard.addCard(drawn);
                Game.DrawnCard = drawn;
            }
            else
            {
                Card drawn = Game.DiscardDeck.TakeCard();
                Game.ComputerDeck.addCard(drawn);
                Game.ComputerFromDiscard.addCard(drawn);
                Game.DrawnCard = drawn;
            }

            Game.DrawFrom = "Discard";
            drawDiscardChange(false);
            updateDecks();

        }

        //Discard the selected card the current players deck
        public void discardSelected()
        {
            if (Game.PlayerTurn == 1)
            {
                Card removedCard = handDeckList.SelectedItem as Card;
                Game.PlayerDeck.RemoveCard(removedCard);
                Game.DiscardDeck.addCard(removedCard);
                Game.DiscardedCard = removedCard;
            }
            else
            {
                Card removedCard = comDeckList.SelectedItem as Card;
                Game.ComputerDeck.RemoveCard(removedCard);
                Game.DiscardDeck.addCard(removedCard);
                Game.DiscardedCard = removedCard;
            }


            drawDiscardChange(true);
            endTurn();
        }

        //enables and disables action butons
        public void drawDiscardChange(bool change)
        {
            drawDeckBtn.Enabled = change;
            drawDiscardBtn.Enabled = change;
            discardFromHandBtn.Enabled = !change;
        }


        /**************************************************************
         * Functions for determining the winner
         * ***********************************************************/
        
        //Controller for validating hands
        public bool validateHands()
        {
            //Get the hand of the current player
            List<Card> hand;
            if (Game.PlayerTurn == 1)
            {
                hand = Game.PlayerDeck.Cards;
            }
            else
            {
                hand = Game.ComputerDeck.Cards;
            }


            //Call the appropriate function for checking the hand
            bool winner = false;
            switch (Game.CurrentHand)
            {
                case 1:
                    winner = checkHand1(hand);
                    break;
            }

            if (winner)
            {
                showWinner();
            }

            return winner;
        }

        //Check if hand has 3 sets of 3
        public bool checkHand1(List<Card> hand)
        {
            int numSets = 0;

            //Loops through each card and checks to see if there are 3 that are equal to the value being tested

            //Loop through values 1 - 13
            for (int value = 1; value <= 13; value++)
            {
                int isSet = 0;
                //Loop through each card in the hand
                foreach (Card card in hand)
                {
                    //Checks to see if card value is the same as the tested value
                    if((int)card.CardNumber == value)
                    {
                        isSet++;
                    }
                }

                //Test to see if there were enough matches to count
                if (isSet >= 3)
                {
                    numSets++;
                }

            }

            //Return True if there were 3 or more sets
            if (numSets >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //This runs when someone wins the game
        public void showWinner()
        {
            //Show the winning message
            if (Game.PlayerTurn == 1)
            {
                winnerLbl.Text = "You Won!";
            }
            else
            {
                winnerLbl.Text = "The Computer Won!";
            }

            drawDeckBtn.Enabled = false;                            //These are useless since they get renabled once the computer plays
            drawDiscardBtn.Enabled = false;

            simpleLogger(Game.PlayerTurn);
        }

        /**************************************************************
         * AI related code
         * ***********************************************************/
        //Logger code - Write code here to log turns for analysis later
        public void turnLogger()
        {
            var path = @"..\\..\\Resources\\logger.txt";
            
            string log = File.ReadAllText(path);

            //Output date time if its turn 0
            if (Game.TurnNumber == 0)
            {
                log += "\nGame Start: " + DateTime.Now;
            }

            log += Game.Out();

            File.WriteAllText(path, log);
            

            //This is a simplified turn logger for a CSV
            path = @"..\\..\\Resources\\loggerCSV.csv";

            log = File.ReadAllText(path);

            log += Game.CommaOut();

            File.WriteAllText(path, log);
        }

        public void simpleLogger(int winner)
        {
            var path = @"..\\..\\Resources\\loggerSimple.txt";

            string log = File.ReadAllText(path);
            log += "\n";
            log += winner + ", ";
            log += Game.TurnNumber + ", ";
            log += Game.ComputerLevel + ", ";
            log += Game.PlayerLevel;

            File.WriteAllText(path, log);

            //This is a simplified turn logger for a CSV
            path = @"..\\..\\Resources\\loggerCSV.csv";

            log = File.ReadAllText(path);

            log += ", " + winner;

            File.WriteAllText(path, log);


        }

        //Controls the AI turn depending on its difficulty level
        public void aiController()
        {
            switch (Game.ComputerLevel)
            {
                case 1:
                    easyAI();
                    break;
                case 2:
                    mediumAIDraw();
                    mediumAIDiscard();
                    break;
                case 3:
                    hardAIDraw();
                    hardAIDiscard();
                    break;
                default:
                    easyAI();
                    break;
            }
        }

        //Controls the AI turn depending on its difficulty level
        public void playerController()
        {
            switch (Game.PlayerLevel) //ai and player controller are different because they may have different levels
            {
                case 1:
                    easyAI();                           
                    break;
                case 2:
                    mediumAIDraw();
                    mediumAIDiscard();
                    break;
                case 3:
                    hardAIDraw();
                    hardAIDiscard();
                    break;
                default:
                    easyAI();
                    break;
            }
        }

        //An Easy AI
        //  Basically a macro to randomly select an index and take the computers turn
        public void easyAI()
        {
            //Create random integers for drawing and discarding
            Random rnd = new Random();
            int draw = rnd.Next(1, 3);
            int discard = rnd.Next(1, 14);

            drawAI(draw);
            discardAI(discard);
        }

        //A medium AI 
        //  Drawing
        public void mediumAIDraw()
        {
            //Get the hand of the current player
            List<Card> hand;
            if (Game.PlayerTurn == 1)
            {
                hand = Game.PlayerDeck.Cards;
            }
            else
            {
                hand = Game.ComputerDeck.Cards;
            }

            //Determine Draw 
            //Positive value to draw from discard, negative from deck
            //Com will prefer to draw from discard
            //  +5   If the top discard matches your hand
            //  -10  If the discard has >1 of top card
            //  +10  If the hand has a pair that can be completed with top card     (This is probably redundant)
            //  -6   If Hand has 3 pairs that cannot be completed with top card
            //  +1   If nothing else matters                                        (Make neg to prefer draw from deck)
            int draw = 0;
            if (countInHand(hand, Game.DiscardDeck.Cards.FirstOrDefault()) > 1)
            {
                draw += 5;
            }
            if (countInHand(Game.DiscardDeck.Cards, Game.DiscardDeck.Cards.FirstOrDefault()) > 1)
            {
                draw -= 10;
            }
            if (checkPairsInHand(hand, Game.DiscardDeck.Cards.FirstOrDefault()))
            {
                draw += 10;
            }
            else if (!checkPairsInHand(hand, Game.DiscardDeck.Cards.FirstOrDefault()))
            {
                draw -= 6;
            }
            if (draw == 0)  //Force a decision
            {
                draw += 1;
            }

            //Actually runs the draw function
            if (draw < 0)
            {
                drawAI(1);
            }
            else
            {
                drawAI(0);
            }
        }

        //  Discard
        public void mediumAIDiscard() 
        {
            //Get the hand of the current player
            List<Card> hand;
            if (Game.PlayerTurn == 1)
            {
                hand = Game.PlayerDeck.Cards;
            }
            else
            {
                hand = Game.ComputerDeck.Cards;
            }

            //Determine Discard
            //Loops through each of the 14 cards and assigns discard value
            //Highest value is discarded
            //Currently if multiple cards have the highest points, the most recent one is discarded
            //  +100 If hand has 4 of card      (This is the highest value)
            //  +6   If discard has >1 of card  (Will end up being +11)
            //  +5   If discard has 1 of card
            //  -8   If hand has 2 of card
            //  -50  If hand has 3 of card      (This is the lowest value
            
            int[] points = new int[14];
            int i = 0;
            foreach (Card card in hand)
            {
                int cardPoints = 0;
                if (countInHand(hand, card) == 4)
                {
                    cardPoints += 100;
                }
                if (countInHand(Game.DiscardDeck.Cards, card) > 1)
                {
                    cardPoints += 6;
                }
                if (countInHand(Game.DiscardDeck.Cards, card) == 1)
                {
                    cardPoints += 5;
                }
                if (countInHand(hand, card) == 2)
                {
                    cardPoints -= 8;
                }
                if (countInHand(hand, card) == 3)
                {
                    cardPoints -= 50;
                }

                points[i] = cardPoints;
            }

            //Get a random index of the cards with the highest points
            int maxPoints = points.Max();
            //int maxIndex = points.ToList().IndexOf(maxPoints);
            var matchingPoints = new List<int>();
            while (i < points.Length)
            {
                if(points[i] == maxPoints)
                {
                    matchingPoints.Add(i);
                }
                i++;
            }

            Random rnd = new Random();
            int maxIndex = rnd.Next(matchingPoints.Count);

            discardAI(matchingPoints[maxIndex]);

        }

        //A Hard AI
        //  Drawing
        //  This is the same as the medium AI
        public void hardAIDraw()
        {
            //Get the hand of the current player
            List<Card> hand;
            List<Card> opponentDraw;
            if (Game.PlayerTurn == 1)
            {
                hand = Game.PlayerDeck.Cards;
                opponentDraw = Game.ComputerFromDiscard.Cards;
            }
            else
            {
                hand = Game.ComputerDeck.Cards;
                opponentDraw = Game.PlayerFromDiscard.Cards;
            }

            //Determine Draw 
            //Positive value to draw from discard, negative from deck
            //Com will prefer to draw from discard
            //  +5   If the top discard matches your hand
            //  -10  If the discard has >1 of top card
            //  +10  If the hand has a pair that can be completed with top card     (This is probably redundant)
            //  -6   If Hand has 3 pairs that cannot be completed with top card
            //  +1   If nothing else matters                                        (Make neg to prefer draw from deck)
            int draw = 0;
            if (countInHand(hand, Game.DiscardDeck.Cards.FirstOrDefault()) > 1)
            {
                draw += 5;
            }
            if (countInHand(Game.DiscardDeck.Cards, Game.DiscardDeck.Cards.FirstOrDefault()) > 1)
            {
                draw -= 10;
            }
            if (checkPairsInHand(hand, Game.DiscardDeck.Cards.FirstOrDefault()))
            {
                draw += 10;
            }
            else if (!checkPairsInHand(hand, Game.DiscardDeck.Cards.FirstOrDefault()))
            {
                draw -= 6;
            }
            if (draw == 0)  //Force a decision
            {
                draw += 1;
            }

            //Actually runs the draw function
            if (draw < 0)
            {
                drawAI(1);
            }
            else
            {
                drawAI(0);
            }
        }

        //  Discard
        //  This takes into account what the other player drew
        public void hardAIDiscard()
        {
            //Get the hand of the current player
            List<Card> hand;
            List<Card> opponentDraw;
            if (Game.PlayerTurn == 1)
            {
                hand = Game.PlayerDeck.Cards;
                opponentDraw = Game.ComputerFromDiscard.Cards;
            }
            else
            {
                hand = Game.ComputerDeck.Cards;
                opponentDraw = Game.PlayerFromDiscard.Cards;
            }

            //Determine Discard
            //Loops through each of the 14 cards and assigns discard value
            //Highest value is discarded
            //Currently if multiple cards have the highest points, the most recent one is discarded
            //  +100 If hand has 4 of card      (This is the highest value)
            //  +6   If discard has >1 of card  (Will end up being +11)
            //  +5   If discard has 1 of card
            //  -8   If hand has 2 of card
            //  -50  If hand has 3 of card      (This is the lowest value)
            //  -7  If opponent drew that card 2x
            //  -3   If opponent drew that card recently
            //  +2   If there is only one in my hand

            int[] points = new int[14];
            int i = 0;
            foreach (Card card in hand)
            {
                int cardPoints = 0;
                if (countInHand(hand, card) == 4)
                {
                    cardPoints += 100;
                }
                if (countInHand(Game.DiscardDeck.Cards, card) > 1)
                {
                    cardPoints += 6;
                }
                if (countInHand(Game.DiscardDeck.Cards, card) == 1)
                {
                    cardPoints += 5;
                }
                if (countInHand(hand, card) == 2)
                {
                    cardPoints -= 8;
                }
                if (countInHand(hand, card) == 3)
                {
                    cardPoints -= 50;
                }
                if (countInHand(opponentDraw, card) > 1)
                {
                    cardPoints -= 7;
                }
                if (countMostRecentHand(opponentDraw, card, 5) >= 1)
                {
                    cardPoints -= 3;
                }
                if (countInHand(opponentDraw, card) == 1)
                {
                    cardPoints += 2;
                }
                points[i] = cardPoints;
            }

            //Get a random index of the cards with the highest points
            int maxPoints = points.Max();
            //int maxIndex = points.ToList().IndexOf(maxPoints);
            var matchingPoints = new List<int>();
            while (i < points.Length)
            {
                if (points[i] == maxPoints)
                {
                    matchingPoints.Add(i);
                }
                i++;
            }

            Random rnd = new Random();
            int maxIndex = rnd.Next(matchingPoints.Count);

            discardAI(matchingPoints[maxIndex]);

        }

        //Helpful code for the AI
        //check if pair can be completed with card
        public bool checkPairsInHand(List<Card> hand, Card cardToCheck)
        {
            foreach (Card card in hand)
            {
                if (countInHand(hand, card) >= 2)    //If there is a pair
                {
                    if (card.CardNumber == cardToCheck.CardNumber)  //If the pair matches the cardToCheck
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //Returns the number of specified cards in specified deck
        public int countInHand(List<Card> hand, Card cardToCheck)
        {
            int count = 0;
            foreach (Card card in hand)
            {
                if (card.CardNumber == cardToCheck.CardNumber)
                {
                    count++;
                }
            }

            return count;
        }

        //Counts if a card was in the nth most recent
        public int countMostRecentHand(List<Card> hand, Card cardToCheck, int num)
        {
            int count = 0;

            //Make sure we don't go out of range
            if(hand.Count() < num)
            {
                num = hand.Count();
            }


            for (int i = 0; i < num; i++)
            {
                if (hand[i].CardNumber == cardToCheck.CardNumber)
                {
                    count++;
                }
            }

            return count;
        }

        //Actual actions taken based on inputs
        //  draw should be 1 to draw from deck
        //  Works for both players
        public void drawAI(int draw)
        {
            //Draw from the draw or discard decks
            if (draw == 1)
            {
                drawFromDeck();
            }
            else
            {
                drawFromDiscard();
            }
        }

        //discard cards
        //  Works for both players
        public void discardAI (int discard)
        {
            if (Game.PlayerTurn == 2)
            {
                //Make the listbox visable
                comDeckList.Visible = true;

                //Select the index of the card to remove
                comDeckList.SelectedIndex = discard;

                //discard selected card
                discardSelected();

                //Make the listbox hidden
                comDeckList.Visible = false;

                Console.WriteLine("Computer took its turn");
            }
            else if (Game.PlayerTurn == 1)
            {
                //Select the index of the card to remove
                handDeckList.SelectedIndex = discard;

                //discard selected card
                discardSelected();

                Console.WriteLine("Player AI took its turn");
            }

        }


        /**************************************************************
          * Button Click code
          * ***********************************************************/
        private void newGameBtn_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void drawDeckBtn_Click(object sender, EventArgs e)
        {
            drawFromDeck();
        }

        private void discardFromHandBtn_Click(object sender, EventArgs e)
        {
            discardSelected();
        }

        private void drawDiscardBtn_Click(object sender, EventArgs e)
        {
            drawFromDiscard();
        }

        private void sortValueBtn_Click(object sender, EventArgs e)
        {
            var list = Game.PlayerDeck.Cards.OrderBy(s => s.CardNumber).ToList();
            
            handDeckList.DataSource = list;
        }

        private void sortSuitBtn_Click(object sender, EventArgs e)
        {
            var list = Game.PlayerDeck.Cards.OrderBy(s => s.CardNumber).ToList();
            list = list.OrderBy(s => s.Suit).ToList();

            handDeckList.DataSource = list;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //This will run the game multiple times for each AI level
        //  To do this, just click Play Loop
        //  You can change iterations Per Lvl to change how many games are played per level
        private void button1_Click(object sender, EventArgs e)     
        {
            int iterationsPerLvl = 200;

            AI2Check.Checked = true;    //This is to make sure that the 2 AI players box is checked in this case

            for (int x = 1; x <= 3; x++)
            {
                playLvl.Value = x;
                comLvl.Value = x;

                for (int i = 0; i < iterationsPerLvl; i++)
                {
                    newGame();
                }
            }
        }
    }
}
