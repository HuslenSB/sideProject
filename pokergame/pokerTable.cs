using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARDGAMES
{
    class pokerTable
    {
        // 2 = hold em game, 4= omaha, 5= omaha5
        private int amountCardsPlayer;
        private double potSize;
        private double betSize;
        private pokerPlayer[] listPlayers;
        private Queue<Card> deck;
        private List<Card> board;
        private bool[] possibleHands;
        // Based on integer -> 0 = royal straight flush, 10 = no pair
        private int[] bestPlayersHands;
        //public
        public testev evaluatorTEST;
   

        public pokerTable(int amountCardsPlayer, pokerPlayer[] listPlayers, Queue<Card> deck)
        {
            this.amountCardsPlayer = amountCardsPlayer;
            this.listPlayers = listPlayers;
            this.deck = deck;
            this.board = new List<Card>();
            this.potSize = 0;
            this.betSize = 0;
            this.possibleHands = new bool[10];
            this.bestPlayersHands = new int[listPlayers.Length];

            this.evaluatorTEST = new testev(listPlayers);
            testGame();

        }
        public void testGame()
        {
            dealPlayerCards();
            dealFlop();
            dealCard();
            dealCard();

            //todo playRound() w/ player actions

            compareHands();

            showBoardCards();
            showPlayerCards();

            //todo FindWinner();
        }

        public void compareHands()
        {
            foreach( pokerPlayer pk in listPlayers )
            {
                var x = pk.getHand;
                x.AddRange(board);
                evaluatorTEST.checkSets(x, pk);
               
            }
        }


        // Adds pot to winners chips 
        public void addChipsWinner(double chips, pokerPlayer winner)
        {
            winner.getChips = chips;
        }

        // Reset values & round to play another round.
        public void resetRound()
        {

        }
        public void dealPlayerCards()
        {
            // If amount = 2 -> regular poker game
            // If amount = 4 -> omaha poker game
            for(int i = 0; i < amountCardsPlayer; i++)
            {
                for(int j = 0; j < listPlayers.Length; j++)
                {
                    listPlayers[j].addCard( deck.Dequeue() );
                }
            }
        }

        
        public void showBoardCards()
        {
            Console.WriteLine("\nBOARD CARDS\n==============");
            foreach( Card c in board )
            {
                Console.WriteLine( $"{ (int) c.getValue} { c.getSuit } " );
            }
            Console.WriteLine("==============");

        }
        public void showPlayerCards()
        {
            // Showing all players card //testing//
            foreach( pokerPlayer player in listPlayers )
            {
                Console.WriteLine($"{ player.stringHand } || { player.getHandValue }" );
            }
        }

        // Deals 3 cards to the board
        public void dealFlop()
        {
             for(int i=0; i<3 ; i++) { board.Add( deck.Dequeue() ); }
        }
        // Deals 1 card to the board
        public void dealCard()
        {
            board.Add( deck.Dequeue() ); 
        }

     
        


    }
}