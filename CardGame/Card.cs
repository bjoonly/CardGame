using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public enum SuitCard { Diamonds, Hearts, Spades, Clubs };
    public enum RankCard { Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
    class  Card:IComparable<Card>
    {
        public SuitCard Suit { get; set; }
        public RankCard Rank { get; set; }
        public Card(SuitCard suit, RankCard rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public override string ToString()
        {
            return "{" + Rank.ToString() + " " + Suit.ToString() + "}";

        }

        public int CompareTo(Card other)
        {
            return (((int)Rank).CompareTo((int)other.Rank));
        }
    }
}
