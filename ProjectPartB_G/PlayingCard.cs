using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project
		public int CompareTo(PlayingCard card1)
        {

			int result = 0;
			if (Value < card1.Value)
			{
				result = -1;
			}
			if (Value > card1.Value)
			{
				result = 1;
			}



			return result;
			
        }
		#endregion

        #region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression
			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode	
		
			get
			{
				char clubs = '\u2663';
				char diamonds = '\u2666';
				char hearts = '\u2665';
				char spades = '\u2660';

				string cardColor = Color switch
				{
					PlayingCardColor.Clubs => $"{clubs} {Value}",
					PlayingCardColor.Diamonds => $"{diamonds} {Value}",
					PlayingCardColor.Hearts => $"{hearts} {Value}",
					PlayingCardColor.Spades => $"{spades} {Value}",
					_ => "invalid",

				};

				return cardColor;
			}
		}

		public override string ToString() => ShortDescription;
        #endregion
    }
}
