namespace CARDGAMES
{
    // Standard deck of 52 cards, 4 suits
    class Card
    {
        public enum suit
        {
            Diamonds, 
            Hearts, 
            Spades, 
            Clubs
        }
        public enum value
        {
            Two = 2, 
            Three, 
            Four, 
            Five, 
            Six, 
            Seven, 
            Eight, 
            Nine, 
            Ten, 
            Jack, 
            Queen, 
            King, 
            Ace
        }

        // Properties
        public suit getSuit{ get; set;}
        public value getValue{ get; set;}

    
    }
}   