using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {

        #region Pick and Add related
        public void Add(PlayingCard card)
        {
            cards.Add(card);
        
        }
        #endregion

        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
                cards.Sort();
                PlayingCard highestCard = cards[^1];
                
                return highestCard;
            }
         }
        public PlayingCard Lowest
        {
            get
            {
                cards.Sort();
                PlayingCard lowestCard = cards[0];

                return lowestCard;
            }
        }
        #endregion
    }
    // done
}
