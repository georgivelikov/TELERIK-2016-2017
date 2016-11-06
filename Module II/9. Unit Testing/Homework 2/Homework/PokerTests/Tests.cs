namespace PokerTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Poker;

    [TestFixture]
    public class Tests
    {
        [TestCase(CardFace.Ace, CardSuit.Clubs, "A♣")]
        [TestCase(CardFace.Queen, CardSuit.Spades, "Q♠")]
        [TestCase(CardFace.Seven, CardSuit.Diamonds, "7♦")]
        [TestCase(CardFace.Ten, CardSuit.Hearts, "10♥")]
        public void TestIfCardToStringIsIplementedCorrectly(CardFace face, CardSuit suit, string result)
        {
            var card = new Card(face, suit);

            var expected = result;
            var actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestIfHandToStringIsIplementedCorrectly()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var c2 = new Card(CardFace.Eight, CardSuit.Hearts);
            var c3 = new Card(CardFace.King, CardSuit.Hearts);
            var c4 = new Card(CardFace.Eight, CardSuit.Spades);
            var c5 = new Card(CardFace.Six, CardSuit.Clubs);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);

            var expected = "A♦ 8♥ K♥ 8♠ 6♣";
            var actual = hand.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestIsValidHandReturnsTrueWhenHandIsValid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var c2 = new Card(CardFace.Eight, CardSuit.Hearts);
            var c3 = new Card(CardFace.King, CardSuit.Hearts);
            var c4 = new Card(CardFace.Eight, CardSuit.Spades);
            var c5 = new Card(CardFace.Six, CardSuit.Clubs);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsValidHand(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIsValidHandReturnsFlaseWhenHandIsInvalid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var c2 = new Card(CardFace.Eight, CardSuit.Hearts);
            var c3 = new Card(CardFace.Eight, CardSuit.Hearts);
            var c4 = new Card(CardFace.Eight, CardSuit.Spades);
            var c5 = new Card(CardFace.Six, CardSuit.Clubs);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsValidHand(hand);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestIfIsFlushMethodReturnsTrueWhenHandIsFlush()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Seven, CardSuit.Hearts);
            var c3 = new Card(CardFace.Queen, CardSuit.Hearts);
            var c4 = new Card(CardFace.Two, CardSuit.Hearts);
            var c5 = new Card(CardFace.Six, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsFlush(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfIsFlushMethodReturnsFalseWhenHandIsNotFlush()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Seven, CardSuit.Hearts);
            var c3 = new Card(CardFace.Queen, CardSuit.Hearts);
            var c4 = new Card(CardFace.Two, CardSuit.Hearts);
            var c5 = new Card(CardFace.Six, CardSuit.Diamonds);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsFlush(hand);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestIfIsFlushMethodReturnsFalseWhenHandIsActuallyStraightFlush()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.King, CardSuit.Hearts);
            var c3 = new Card(CardFace.Queen, CardSuit.Hearts);
            var c4 = new Card(CardFace.Jack, CardSuit.Hearts);
            var c5 = new Card(CardFace.Ten, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsFlush(hand);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestIfIsFourOfAKindReturnsTrueWhenThereAreFourCardsWithTheSameFace()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Ace, CardSuit.Spades);
            var c4 = new Card(CardFace.Ace, CardSuit.Clubs);
            var c5 = new Card(CardFace.Seven, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsFourOfAKind(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfIsFourOfAKindReturnsFalseWhenThereAreNotFourCardsWithTheSameFace()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Seven, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Seven, CardSuit.Spades);
            var c4 = new Card(CardFace.Ace, CardSuit.Clubs);
            var c5 = new Card(CardFace.Seven, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsFourOfAKind(hand);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestIfIsIsHighCardReturnsTrueWhenValid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Six, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Queen, CardSuit.Spades);
            var c4 = new Card(CardFace.King, CardSuit.Clubs);
            var c5 = new Card(CardFace.Seven, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsHighCard(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfIsIsOnePairReturnsTrueWhenValid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Six, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Ace, CardSuit.Spades);
            var c4 = new Card(CardFace.King, CardSuit.Clubs);
            var c5 = new Card(CardFace.Seven, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsOnePair(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfIsIsOnePairReturnsFalseWhen2Pairs()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Six, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Ace, CardSuit.Spades);
            var c4 = new Card(CardFace.Six, CardSuit.Clubs);
            var c5 = new Card(CardFace.Seven, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsOnePair(hand);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestIfIsIswoPairsReturnsTrueWhenValid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Six, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Ace, CardSuit.Spades);
            var c4 = new Card(CardFace.Six, CardSuit.Clubs);
            var c5 = new Card(CardFace.Seven, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsTwoPair(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfIsIsThreeOfAKindReturnsTrueWhenValid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Ace, CardSuit.Spades);
            var c4 = new Card(CardFace.King, CardSuit.Clubs);
            var c5 = new Card(CardFace.Seven, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsThreeOfAKind(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfIsIsThreeOfAKindReturnsFalseWhenHandIsActuallyFullHouse()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Ace, CardSuit.Spades);
            var c4 = new Card(CardFace.King, CardSuit.Clubs);
            var c5 = new Card(CardFace.King, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsThreeOfAKind(hand);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestIfIsIsFullHouseReturnsTrueWhenValid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Ace, CardSuit.Spades);
            var c4 = new Card(CardFace.King, CardSuit.Clubs);
            var c5 = new Card(CardFace.King, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsFullHouse(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfIsIsStraightReturnsTrueWhenValid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.King, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Queen, CardSuit.Spades);
            var c4 = new Card(CardFace.Jack, CardSuit.Clubs);
            var c5 = new Card(CardFace.Ten, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsStraight(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfIsIsStraightReturnsFalseWhenInvalid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.King, CardSuit.Diamonds);
            var c3 = new Card(CardFace.Nine, CardSuit.Spades);
            var c4 = new Card(CardFace.Jack, CardSuit.Clubs);
            var c5 = new Card(CardFace.Ten, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsStraight(hand);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestIfIsIsStraightFlushReturnsTrueWhenValid()
        {
            var c1 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c2 = new Card(CardFace.King, CardSuit.Hearts);
            var c3 = new Card(CardFace.Queen, CardSuit.Hearts);
            var c4 = new Card(CardFace.Jack, CardSuit.Hearts);
            var c5 = new Card(CardFace.Ten, CardSuit.Hearts);

            var list = new List<ICard>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);

            var hand = new Hand(list);
            var checker = new PokerHandsChecker();
            bool result = checker.IsStraightFlush(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestComparissonOfTwoHandsToReturnAsExpected()
        {
            // ALSO SHOULD TEST IF THE TWO HANDS ARE OF 10 DIFFRENT CARDS
            var c1 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var c2 = new Card(CardFace.Ace, CardSuit.Hearts);
            var c3 = new Card(CardFace.Ace, CardSuit.Clubs);
            var c4 = new Card(CardFace.Jack, CardSuit.Spades);
            var c5 = new Card(CardFace.Jack, CardSuit.Hearts);

            var list1 = new List<ICard>();
            list1.Add(c1);
            list1.Add(c2);
            list1.Add(c3);
            list1.Add(c4);
            list1.Add(c5);

            var hand1 = new Hand(list1);

            var c6 = new Card(CardFace.Three, CardSuit.Diamonds);
            var c7 = new Card(CardFace.Three, CardSuit.Hearts);
            var c8 = new Card(CardFace.Seven, CardSuit.Clubs);
            var c9 = new Card(CardFace.Six, CardSuit.Spades);
            var c10 = new Card(CardFace.Five, CardSuit.Hearts);

            var list2 = new List<ICard>();
            list2.Add(c6);
            list2.Add(c7);
            list2.Add(c8);
            list2.Add(c9);
            list2.Add(c10);

            var hand2 = new Hand(list2);


            var checker = new PokerHandsChecker();
            var expected = 1;
            var actual = checker.CompareHands(hand1, hand2);

            Assert.AreEqual(expected, actual);
        }
    }
}
