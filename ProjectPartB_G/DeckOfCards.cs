using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx] => cards[idx];
        public int Count => cards.Count();
        #endregion

        #region ToString() related
        public override string ToString()
        {
            string sRet = "";
            int counter = 0;

            for (int i = 0;  i < cards.Count(); i++)
            { 

                sRet += $"{cards[i],-8} ";
                counter++;

               if (counter == 13)
               {
                    sRet += "\n";
                    counter = 0;

               }

            }

            return sRet;

        } 
        #endregion 
        // done

        #region Shuffle and Sorting
        public void Shuffle()
        {
            Random rnd = new Random();
            int index;

            for (int i = 0; i < cards.Count; i++)
            {
                PlayingCard card = cards[i];
                index = rnd.Next(0,52);
               
                cards[i] = cards[index];
                cards[index] = card;
  
            }
        
        }
        public virtual void Sort()
        {
            //cards = cards.OrderBy(card => card.Value).ToList();
            this.cards = cards.OrderBy(c => c.Color).ToList();
            this.cards = cards.OrderBy(v => v.Value).ToList();
        }
        #endregion
        // done

        #region Creating a fresh Deck
        public void Clear()
        {          
            cards.Clear();           
        }

        public void CreateFreshDeck()
        {
            for (PlayingCardColor cardColor = PlayingCardColor.Clubs; cardColor <= PlayingCardColor.Spades ; cardColor++)
            {
                for (PlayingCardValue cardValue = PlayingCardValue.Two; cardValue <= PlayingCardValue.Ace; cardValue++)
                {
                    cards.Add( new PlayingCard { Color = cardColor, Value = cardValue } );
                }
            }
        }
        #endregion
        // done

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            PlayingCard removedCard;

            for (int i = 0; i < MaxNrOfCards; i++)
            {
                if (cards[i] != null)
                {
                    removedCard = cards[i];
                    cards.RemoveAt(i);
                    return removedCard;
                }  
            }
            Console.WriteLine("Deck is empty");
            return null;

        }
        #endregion
        // done
    }
}

