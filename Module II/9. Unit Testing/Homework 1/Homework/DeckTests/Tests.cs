using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeckTests
{
    using NUnit.Framework;

    using Santase.Logic;
    using Santase.Logic.Cards;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestIfCardsLeftReturnsCorectValueAtTheBegginigOfTheGame()
        {
            Deck deck = new Deck();

            int expectedCardsCount = 24;

            int actualCarsCount = deck.CardsLeft;

            Assert.AreEqual(expectedCardsCount, actualCarsCount);
        }

        [TestCase(5, 19)]
        [TestCase(10, 14)]
        public void TestIfCardsLeftReturnsCorectValueAfterNCardsAreRemoved(int cardsToRemove, int expectedCardsCount)
        {
            Deck deck = new Deck();

            for (int i = 0; i < cardsToRemove; i++)
            {
                var card = deck.GetNextCard();
            }

            int actualCardsCount = deck.CardsLeft;

            Assert.AreEqual(expectedCardsCount, actualCardsCount);
        }

        [Test]
        public void TestIfChangeTrumpCardCorrecltyChangesTheTrumpCardWithTheNewOne()
        {
            Deck deck = new Deck();
            var newCard = new Card(CardSuit.Diamond, CardType.Ace);
            deck.ChangeTrumpCard(newCard);
            
            Assert.AreEqual(deck.TrumpCard, newCard);
        }

        [Test]
        public void TestIfGetNextCardThrowsInternalGameExceptionWhenTryToRemoveMoreThan24Cards()
        {
            Deck deck = new Deck();
            int cardsToRemove = 24;

            for (int i = 0; i < cardsToRemove; i++)
            {
                var card = deck.GetNextCard();
            }

            Assert.Throws(typeof(InternalGameException), () => deck.GetNextCard());
        }
    }
}
