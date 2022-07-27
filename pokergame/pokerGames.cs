using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARDGAMES
{
    class pokerGames
    {
        private deckProcessor deckprocessor;
        private Queue<Card> deck;
        private pokerPlayer[] listPlayers;
        private pokerTable table;

        public pokerGames()
        {
            
        }
        // Todo UI menu to pick poker type-> holdem, omaha, shortdeck
        // And initialize poker game.

        public void playHoldem()
        {
            // Build deck
            deckprocessor = new deckProcessor();
            deck = new Queue<Card>(deckprocessor.holdem_ProcessDeck());

            // Test player list
            listPlayers = new pokerPlayer[6]{
                new pokerPlayer( "Alex" ), 
                new pokerPlayer( "Bobby" ), 
                new pokerPlayer( "Casper" ),
                new pokerPlayer( "Diana" ),
                new pokerPlayer( "Evelyn" ),
                new pokerPlayer( "Floor" )};

            // Starts poker
            table = new pokerTable(2, listPlayers, deck);
        }
        
        // TODO
        public void playOmaha()
        {
            
        }

    }
}