using System;
using System.IO;
using System.Collections.Generic;

class PokerHands
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // code here

                string leftHandString = line.Substring(0, 14);
                string rightHandString = line.Substring(15);

                Hand leftHand = new Hand(leftHandString);
                Hand rightHand = new Hand(rightHandString);

                if (leftHand.GetHandValue() > rightHand.GetHandValue())
                    Console.WriteLine("left");
                else if (leftHand.GetHandValue() < rightHand.GetHandValue())
                    Console.WriteLine("right");
                else if (leftHand.GetHandValue() == rightHand.GetHandValue())
                    Console.WriteLine("none");
                
                               
                // end of code
            }

        Console.ReadLine();
    }

    public enum Suit
    {
        Diamonds = 2, 
        Hearts, Spades, Clubs
    }

    public enum Rank
    {
        Two = 2,
        Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }

    public enum HandType
    {
        HighCard = 2000000,
        OnePair = 4000000,
        TwoPairs = 6000000,
        ThreeOfAKind = 8000000,
        Straight = 10000000,
        Flush = 12000000,
        FullHouse = 14000000,
        FourOfAKind = 16000000,
        StraightFlush = 18000000,
        RoyalFlush = 200000000        
    }

    public class Card
    {
        public Rank rank;
        public Suit suit;

        public Card(string cardString)
        {
            Char rankChar = cardString[0];
            Char suitChar = cardString[1];

            switch(rankChar)
            {
                case '2':
                    this.rank = Rank.Two;
                    break;
                case '3':
                    this.rank = Rank.Three;
                    break;
                case '4':
                    this.rank = Rank.Four;
                    break;
                case '5':
                    this.rank = Rank.Five;
                    break;
                case '6':
                    this.rank = Rank.Six;
                    break;
                case '7':
                    this.rank = Rank.Seven;
                    break;
                case '8':
                    this.rank = Rank.Eight;
                    break;
                case '9':
                    this.rank = Rank.Nine;
                    break;
                case 'T':
                    this.rank = Rank.Ten;
                    break;
                case 'J':
                    this.rank = Rank.Jack;
                    break;
                case 'Q':
                    this.rank = Rank.Queen;
                    break;
                case 'K':
                    this.rank = Rank.King;
                    break;
                case 'A':
                    this.rank = Rank.Ace;
                    break;
            }

            switch(suitChar)
            {
                case 'D':
                    this.suit = Suit.Diamonds;
                    break;
                case 'H':
                    this.suit = Suit.Hearts;
                    break;
                case 'S':
                    this.suit = Suit.Spades;
                    break;
                case 'C':
                    this.suit = Suit.Clubs;
                    break;
            }
        }
    }

    public class SuitComparer : IComparer<Card>
    {
        int IComparer<Card>.Compare(Card c1, Card c2)
        {
            return c1.suit.CompareTo(c2.suit);
        }
    }
    public class RankComparer : IComparer<Card>
    {
        int IComparer<Card>.Compare(Card c1, Card c2)
        {
            return c1.rank.CompareTo(c2.rank);
        }
    }

    public class Hand
    {
        public List<Card> cards;
        public HandType handType;
        public int handValue;

        public Hand(string handString)
            : this(handString.Split(' '))
        { }
        public Hand(string[] handString)
        {
            this.cards = new List<Card>();

            foreach(string cardString in handString)
            {
                this.cards.Add(new Card(cardString));
            }

            this.SetHandType();
        }

        private void SetHandType()
        {
            if (this.isRoyalFlush())
                this.handType = HandType.RoyalFlush;
            else if (this.isStraightFlush())
                this.handType = HandType.StraightFlush;
            else if (this.isFourOfAKind())
                this.handType = HandType.FourOfAKind;
            else if (this.isFullHouse())
                this.handType = HandType.FullHouse;
            else if (this.isFlush())
                this.handType = HandType.Flush;
            else if (this.isStraight())
                this.handType = HandType.Straight;
            else if (this.isThreeOfAKind())
                this.handType = HandType.ThreeOfAKind;
            else if (this.isTwoPairs())
                this.handType = HandType.TwoPairs;
            else if (this.isOnePair())
                this.handType = HandType.OnePair;
            else
                this.handType = HandType.HighCard;
        }

        public int GetHandValue()
        {
            switch (this.handType)
            {
                case HandType.RoyalFlush:
                    return this.RoyalFlushValue();
                case HandType.StraightFlush:
                    return this.StraightFlushValue();
                case HandType.FourOfAKind:
                    return this.FourOfAKindValue();
                case HandType.FullHouse:
                    return this.FullHouseValue();
                case HandType.Flush:
                    return this.FlushValue();
                case HandType.Straight:
                    return this.StraightValue();
                case HandType.ThreeOfAKind:
                    return this.ThreeOfAKindValue();
                case HandType.TwoPairs:
                    return this.TwoPairsValue();
                case HandType.OnePair:
                    return this.OnePairValue();
                case HandType.HighCard:
                    return this.HighCardValue();
                default:
                    return 0;
            }
        }

        public int RoyalFlushValue()
        {
            int value = this.HighCardValue();

            return (int)HandType.RoyalFlush + value;
        }

        public int StraightFlushValue()
        {
            int value = this.HighCardValue();

            return (int)HandType.StraightFlush + value;
        }

        public int FlushValue()
        {
            int value = this.HighCardValue();

            return (int)HandType.Flush + value;
        }

        public int StraightValue()
        {
            int value = this.HighCardValue();

            return (int)HandType.Straight + value;
        }

        public int FourOfAKindValue()
        {
            int value = 0;
            this.SortHandByRank();

            value = (int)this.cards[2].rank;
            return (int)HandType.FourOfAKind + value;
        }

        public int FullHouseValue()
        {
            int value = 0;
            this.SortHandByRank();

            value = (int)this.cards[2].rank;
            return (int)HandType.FullHouse + value;
        }

        public int ThreeOfAKindValue()
        {
            int value = 0;
            this.SortHandByRank();

            value = (int)this.cards[2].rank;
            return (int)HandType.ThreeOfAKind + value;
        }

        public int TwoPairsValue()
        {
            int value = 0;
            this.SortHandByRank();

            if (this.cards[0].rank == this.cards[1].rank && this.cards[2].rank == this.cards[3].rank)
                value = 14 * 14 * (int)this.cards[2].rank + 14 * (int)this.cards[0].rank + (int)this.cards[4].rank;
            else if (this.cards[0].rank == this.cards[1].rank && this.cards[3].rank == this.cards[4].rank)
                value = 14 * 14 * (int)this.cards[3].rank + 14 * (int)this.cards[0].rank + (int)this.cards[2].rank;
            else if (this.cards[1].rank == this.cards[2].rank && this.cards[3].rank == this.cards[4].rank)
                value = 14 * 14 * (int)this.cards[3].rank + 14 * (int)this.cards[1].rank + (int)this.cards[0].rank;
            return (int)HandType.TwoPairs + value;
        }

        public int OnePairValue()
        {
            int value = 0;
            this.SortHandByRank();

            if (this.cards[0].rank == this.cards[1].rank)
                value = 14 * 14 * 14 * (int)this.cards[0].rank + (int)this.cards[2].rank + 14 * (int)this.cards[3].rank + 14 * 14 * (int)this.cards[4].rank;
            else if (this.cards[1].rank == this.cards[2].rank)
                value = 14 * 14 * 14 * (int)this.cards[1].rank + (int)this.cards[0].rank + 14 * (int)this.cards[3].rank + 14 * 14 * (int)this.cards[4].rank;
            else if (this.cards[2].rank == this.cards[3].rank)
                value = 14 * 14 * 14 * (int)this.cards[2].rank + (int)this.cards[0].rank + 14 * (int)this.cards[1].rank + 14 * 14 * (int)this.cards[4].rank;
            else if (this.cards[3].rank == this.cards[4].rank)
                value = 14 * 14 * 14 * (int)this.cards[3].rank + (int)this.cards[0].rank + 14 * (int)this.cards[1].rank + 14 * 14 * (int)this.cards[2].rank;
            return (int)HandType.OnePair + value;
        }

        public int HighCardValue()
        {
            int value = 0;
            this.SortHandByRank();

            value = (int)this.cards[0].rank + 14*(int)this.cards[1].rank + 14*14*(int)this.cards[2].rank + 14*14*14*(int)this.cards[3].rank + 14*14*14*14*(int)this.cards[4].rank;
            return value;
        }

        public void SortHandByRank()
        {            
            this.cards.Sort(new RankComparer());
        }

        public void SortHandBySuit()
        {
            this.cards.Sort(new SuitComparer());
        }

        public bool isFlush()
        {
            this.SortHandBySuit();

            return (this.cards[0].suit == this.cards[4].suit);
        }

        public bool isStraight()
        {
            this.SortHandByRank();

            if(this.cards[4].rank == Rank.Ace)
            {
                // TJQKA
                bool highAceStraight = (this.cards[0].rank == Rank.Ten);

                // A2345
                bool lowAceStraight = (this.cards[3].rank == Rank.Five);

                return (highAceStraight || lowAceStraight);
            }
            else
            {
                return (this.cards[4].rank - this.cards[0].rank == 4);
            }
        }

        public bool isStraightFlush()
        {
            return (this.isFlush() && this.isStraight());
        }

        public bool isRoyalFlush()
        {
            this.SortHandByRank();

            return (this.isFlush() && this.isStraight() && (this.cards[0].rank == Rank.Ten));
        }

        public bool isFourOfAKind()
        {
            this.SortHandByRank();

            // aaaax
            bool low4 = ((this.cards[0].rank == this.cards[1].rank) && (this.cards[1].rank == this.cards[2].rank) && (this.cards[2].rank == this.cards[3].rank));

            // xaaaa
            bool high4 = ((this.cards[1].rank == this.cards[2].rank) && (this.cards[2].rank == this.cards[3].rank) && (this.cards[3].rank == this.cards[4].rank));

            return (low4 || high4);
        }

        public bool isFullHouse()
        {
            this.SortHandByRank();

            // aaabb
            bool low3high2 = (((this.cards[0].rank == this.cards[1].rank) && (this.cards[1].rank == this.cards[2].rank)) && (this.cards[3].rank == this.cards[4].rank));

            // aabbb
            bool low2high3 = ((this.cards[0].rank == this.cards[1].rank) && ((this.cards[2].rank == this.cards[3].rank) && (this.cards[3].rank == this.cards[4].rank)));

            return (low3high2 || low2high3);
        }

        public bool isThreeOfAKind()
        {
            if (this.isFourOfAKind() || this.isFullHouse())
                return false;

            this.SortHandByRank();

            // aaaxy
            bool low3 = ((this.cards[0].rank == this.cards[1].rank) && (this.cards[1].rank == this.cards[2].rank));

            // xaaay
            bool middle3 = ((this.cards[1].rank == this.cards[2].rank) && (this.cards[2].rank == this.cards[3].rank));

            // xyaaa
            bool high3 = ((this.cards[2].rank == this.cards[3].rank) && (this.cards[3].rank == this.cards[4].rank));

            return (low3 || middle3 || high3);
        }

        public bool isTwoPairs()
        {
            if (this.isFourOfAKind() || this.isFullHouse() || this.isThreeOfAKind())
                return false;

            this.SortHandByRank();

            // aabbx
            bool lowPairs = ((this.cards[0].rank == this.cards[1].rank) && (this.cards[2].rank == this.cards[3].rank));

            // aaxbb
            bool lowHighPairs = ((this.cards[0].rank == this.cards[1].rank) && (this.cards[3].rank == this.cards[4].rank));

            // xaabb
            bool highPairs = ((this.cards[1].rank == this.cards[2].rank) && (this.cards[3].rank == this.cards[4].rank));

            return (lowPairs || lowHighPairs || highPairs);
        }

        public bool isOnePair()
        {
            if (this.isFourOfAKind() || this.isFullHouse() || this.isThreeOfAKind() || this.isTwoPairs())
                return false;

            this.SortHandByRank();

            // aaxyz
            bool lowPair = (this.cards[0].rank == this.cards[1].rank);

            // xaayz
            bool lowMidPair = (this.cards[1].rank == this.cards[2].rank);

            // xyaaz
            bool highMidPair = (this.cards[2].rank == this.cards[3].rank);

            // xyzaa
            bool highPair = (this.cards[3].rank == this.cards[4].rank);

            return (lowPair || lowMidPair || highMidPair || highPair);
        }
    }
}