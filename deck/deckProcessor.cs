namespace CARDGAMES
{
    class deckProcessor
    {
        private holdemPokerFactory holdemPokerFactory;
        //private ShortPokerFactory shortPokerFactory;
        private omahaPokerFactory omahaPokerFactory;
        public deckProcessor()
        {

            holdemPokerFactory = new holdemPokerFactory();
            omahaPokerFactory = new omahaPokerFactory();
    
        }

        // returns deck of cards for holdem poker
        public Queue<Card> holdem_ProcessDeck()
        {
            List<Card> deck = holdemPokerFactory.buildDeck();
            shuffleDeck( deck );
            return new Queue<Card>( deck );
        }


        // returns deck of cards for omaha
        public List<Card> omaha_ProcessDeck()
        {
            List<Card> deck = omahaPokerFactory.buildDeck();
            shuffleDeck( deck );
            return deck;
        }

        // Shuffles deck of cards 500x
        public List<Card> shuffleDeck( List<Card> deck )
        {
            for( int i = 0; i < 500; i++) 
            {
                Random rng = new Random();
                int n = deck.Count;

                while ( n>1 )
                {
                    n--;
                    int k = rng.Next(n+1);
                    Card temp = deck[k];
                    deck[k] = deck[n];
                    deck[n] = temp;
                }

            } 

            return deck;
        }
    }
}