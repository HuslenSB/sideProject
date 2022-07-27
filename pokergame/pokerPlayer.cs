namespace CARDGAMES
{
    class pokerPlayer
    {
        private string name;
        private double chips;
        private double bet;
        private int index;
        private int sumHandValue;
        private List<Card> hand;

        private handValue _handValue;

        public enum handValue
        {

            Royal_Straight_FLush,
            Straight_Flush,
            Four_Kind,
            Full_House,
            Flush,
            Straight,
            Three_Kind,
            Two_Pair,
            One_Pair,
            No_Pair

        }
        
    
        public pokerPlayer( string name )
        {

           this.name = name;
           hand = new List<Card>();
           sumHandValue=0;
           chips = 100.0;

        }
        // Adds card to player hand
        public void addCard( Card card ) 
        {
            hand.Add(card);
        }
        // todo Game Mechanics - check, raise, fold
        public void check(){}
        public void raise(){}
        public void fold(){}


        // Properties
        public double getBet { get { return bet; } } 
        public double getChips{ get { return chips; } set { chips = chips+value; } }
        public string getName{ get { return name; } }
        public string stringHand{ get { return $"{name}: {(int)hand[0].getValue} {hand[0].getSuit}  {(int)hand[1].getValue} {hand[1].getSuit} ||"+ getSumHand;} }
        public List<Card> getHand { get { return hand; } set { hand = value; } }
        public handValue getHandValue { get{ return _handValue; } set { _handValue = value; } }
        public int getSumHand { get{ return sumHandValue; } set { sumHandValue = value; } }

        public void sethandValueByInt( int val )
        {
            handValue hval = (handValue) val;
            getHandValue = hval;
        }
        public int gethandValueInt()
        {
            var hval = (int) getHandValue;
            return hval;
        }
    }
}