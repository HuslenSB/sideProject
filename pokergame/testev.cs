using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARDGAMES
{
    // Test hand evaluator
    class testev : Card
    {
        private int[] bestPlayerHands;
        //public int totalHandValue;
        private pokerPlayer[] pokerPlayers;
        public testev( pokerPlayer[] players )
        {
            this.pokerPlayers = players;
            this.bestPlayerHands = new int[ pokerPlayers.Length ];
            
        }
        public pokerPlayer checkSets( List<Card> hand, pokerPlayer player )
        {
            var test = hasNoPair( hand,player );
            var test2= hasPair( hand,player );
            var test3= has2Pair( hand,player );
            var test4= hasThreeKind( hand,player );
            var test5 = hasStraight( hand,player );
            var test6 = hasFlush( hand,player );
            var test7 = hasFullHouse( hand, player );
            var test8 = hasStraightFlush( hand, player );
            var test9 = hasRoyalStraightFlush( hand, player );
            //Console.WriteLine($"[checkSETS] {test} {test2} {test3} {test4} {test5}  ");

            return player;
        }


        public bool hasNoPair( List<Card> hand, pokerPlayer player  )
        {
            
           var test = hand;     
           if( test.GroupBy( v => v.getValue ).Where( c => c.Count() == 1 ).Count() == 7 )
            {

                player.getSumHand = (int) hand[0].getValue;
                player.sethandValueByInt( 9 );
  
                return true;
            }
            return false;

        }
        public bool hasPair( List<Card> hand, pokerPlayer player  )
        {
            if(hand.GroupBy( v => v.getValue ).Where( c => c.Count() == 2 ).Count() == 1 )
            {
                
                //var highCard = player.getHand.OrderBy(v => v.getValue ).ToList();

                // IF -> pair ace vs ace -> second card < wins
                
                // Print board + player cards
                string s ="";
                for(int i=0;i<hand.Count();i++)
                {
                    s+= hand[i].getValue+"|";
                }
                Console.WriteLine(player.stringHand);
                Console.WriteLine(s);


                player.sethandValueByInt( 8 );
                return true;
            }
            return false;
        }

        public bool has2Pair( List<Card> hand, pokerPlayer player )
        {
            if(hand.GroupBy( v => v.getValue ).Where( c => c.Count() == 2 ).Count() == 2 )
            {
                player.sethandValueByInt( 7 );
                return true;
            }
            return false;
        }
        public bool hasThreeKind( List<Card> hand, pokerPlayer player)
        {
            
            if(hand.GroupBy( v => v.getValue ).Where( c => c.Count() == 3 ).Count() == 1 )
            {
                player.sethandValueByInt(6);
                //player.getSumHand = (int)hand[0].getValue * 3 * 3;
                return true;
            }
           return false;
        }
        public bool hasStraight( List<Card> hand, pokerPlayer player)
        {
            var order = hand.OrderBy( v => v.getValue ).ToArray();

            // Works -> find winner of tie
            if( ((int)order[0].getValue).Equals( 2 ) &&
                ((int)order[1].getValue).Equals( 3 ) &&
                ((int)order[2].getValue).Equals( 4 ) &&
                ((int)order[3].getValue).Equals( 5 ) &&
                ((int)order[6].getValue).Equals( 14 ))
                {
                    //
                    player.sethandValueByInt( 5 );
                    return true;
                }

            var start = (int) order.First().getValue;


            for( int i = 1; i < order.Length; i++ )
            {
                if( start == (int) order[i].getValue + i )
                    continue;
                else{
                    return false;
                }
                
            }
            player.sethandValueByInt( 5 );
            return true;
        }
        // Find winner of tie

        public bool hasFlush( List<Card> hand, pokerPlayer player )
        {
            if(hand.GroupBy( s => s.getSuit ).Where( s => s.Count() == 5 ).Count() == 1 )
            {
                player.sethandValueByInt( 4 );
                //player.getSumHand = (int)hand.GroupBy( s => s.getSuit ).Where( c => c.Count() == 5 );
                return true;
            }
            return false;
        }

        public bool hasFullHouse( List<Card> hand, pokerPlayer player )
        {
            if(has2Pair( hand, player  ) && hasThreeKind( hand, player  ) )
            {
                player.sethandValueByInt( 3 );
                return true;
            }
            return false;
        }

        public bool hasfourKind( List<Card> hand, pokerPlayer player )
        {
            if(hand.GroupBy( v => v.getValue ).Where( c => c.Count() == 4 ).Count() == 1)
            {
                //player.getSumHand = (int)hand[0].getValue * 4 * 4;
                player.sethandValueByInt(2);
                return true;
            }
            return false;
        }

        // RoyalStraightflush broken -> straight flush too prob
        public bool hasStraightFlush( List<Card> hand, pokerPlayer player )
        {
            if( hasStraight ( hand, player  ) && hasFlush( hand, player ) )
            {
                player.sethandValueByInt(1);
                return true;
            }
            return false;
        }
        public bool hasRoyalStraightFlush( List<Card> hand, pokerPlayer player )
        {
            var order = hand.OrderBy( v => v.getValue ).ToArray();
            if( hasStraightFlush( hand, player ) && order[0].getValue.Equals( 10 ) )
            {

                player.sethandValueByInt(0);
                return true;
            }  
            return false;
        }       
    }
}