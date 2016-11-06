using System;

namespace Poker
{
    using System.Collections.Generic;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            var checkerList = new List<ICard>();

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var currentCard = hand.Cards[i];
                for (int j = 0; j < checkerList.Count; j++)
                {
                    if (currentCard.Equals(checkerList[j]))
                    {
                        return false;
                    }
                }

                checkerList.Add(currentCard);
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                var currentCard = hand.Cards[i];
                var nextCard = hand.Cards[i + 1];

                if (currentCard.Face <= nextCard.Face || currentCard.Suit != nextCard.Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var cardsCounts = this.CheckHand(hand);

            foreach (var count in cardsCounts)
            {
                if (count.Value == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            var cardsCounts = this.CheckHand(hand);

            foreach (var count in cardsCounts)
            {
                if (count.Value == 3 && cardsCounts.Count == 2)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                var currentCard = hand.Cards[i];
                var prevCard = hand.Cards[i - 1];

                if (currentCard.Suit != prevCard.Suit)
                {
                    return false;
                }
            }

            if (this.IsStraightFlush(hand))
            {
                return false; // hand is actually straight flush
            }
            else
            {
                return true;
            }
        }

        public bool IsStraight(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                var currentCard = hand.Cards[i];
                var nextCard = hand.Cards[i + 1];

                if (currentCard.Face <= nextCard.Face)
                {
                    return false;
                }
            }

            if (this.IsStraightFlush(hand))
            {
                return false; // hand is actually straight flush
            }
            else
            {
                return true;
            }
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            var cardsCounts = this.CheckHand(hand);

            foreach (var count in cardsCounts)
            {
                if (count.Value == 3 && cardsCounts.Count == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            var cardsCounts = this.CheckHand(hand);

            foreach (var count in cardsCounts)
            {
                if (count.Value == 2 && cardsCounts.Count == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            var cardsCounts = this.CheckHand(hand);

            if (cardsCounts.Count == 4)
            {
                return true;
            }


            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            var cardsCounts = this.CheckHand(hand);

            if (cardsCounts.Count == 5)
            {
                return true;
            }

            return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            var priorityFirstHand = this.EvaluateHand(firstHand);
            var prioritySecondHand = this.EvaluateHand(secondHand);

            return priorityFirstHand.CompareTo(prioritySecondHand);
        }

        private int EvaluateHand(IHand hand)
        {
            int priority = 0;

            if (this.IsHighCard(hand))
            {
                priority = 1;
            }

            if (this.IsOnePair(hand))
            {
                priority = 2;
            }

            if (this.IsTwoPair(hand))
            {
                priority = 3;
            }

            if (this.IsThreeOfAKind(hand))
            {
                priority = 4;
            }

            if (this.IsStraight(hand))
            {
                priority = 5;
            }

            if (this.IsFlush(hand))
            {
                priority = 6;
            }

            if (this.IsFullHouse(hand))
            {
                priority = 7;
            }

            if (this.IsFourOfAKind(hand))
            {
                priority = 8;
            }

            if (this.IsStraightFlush(hand))
            {
                priority = 9;
            }

            return priority;
        }


        private Dictionary<CardFace, int> CheckHand(IHand hand)
        {
            Dictionary<CardFace, int> checker = new Dictionary<CardFace, int>();
            foreach (var card in hand.Cards)
            {
                if (!checker.ContainsKey(card.Face))
                {
                    checker.Add(card.Face, 1);
                }
                else
                {
                    checker[card.Face]++;
                }
            }

            return checker;
        }
    }
}
