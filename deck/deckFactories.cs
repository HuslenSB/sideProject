namespace CARDGAMES
{
    
    abstract class deckFactory : Card
    {
        public abstract List<Card> buildDeck();
    }

    // Standard deck for hold em poker
    class holdemPokerFactory : deckFactory
    {
       public override List<Card> buildDeck()
        {
            List<Card> deck = new List<Card>();
            foreach( suit s in Enum.GetValues ( typeof ( suit ) ) )
            {
                foreach( value v in Enum.GetValues ( typeof ( value ) ) )
                {
                    deck.Add( new Card { getSuit =s, getValue = v } );
                }
            }
            return deck;
        }
    }
    
    class omahaPokerFactory : deckFactory
    {
        public override List<Card> buildDeck()
        {
            List<Card> deck = new List<Card>();
            foreach( suit s in Enum.GetValues ( typeof ( suit ) ) )
            {
                foreach( value v in Enum.GetValues ( typeof ( value ) ) )
                {
                    
                    deck.Add( new Card { getSuit = s, getValue = v } );
                }
            }
            return deck;
        }
    }
}