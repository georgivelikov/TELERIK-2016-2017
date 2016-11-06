using System;

namespace Poker
{
    using System.Collections.Generic;

    public class Card : ICard
    {
        private Dictionary<CardFace, string> faces = new Dictionary<CardFace, string>();
        private Dictionary<CardSuit, string> suits = new Dictionary<CardSuit, string>();

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
            this.FillDictionaries();
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}{1}", this.faces[this.Face], this.suits[this.Suit]);
        }

        public override bool Equals(object obj)
        {
            var otherCard = obj as Card;

            if (otherCard.Face == this.Face && otherCard.Suit == this.Suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FillDictionaries()
        {
            this.faces.Add(CardFace.Two, "2");
            this.faces.Add(CardFace.Three, "3");
            this.faces.Add(CardFace.Four, "4");
            this.faces.Add(CardFace.Five, "5");
            this.faces.Add(CardFace.Six, "6");
            this.faces.Add(CardFace.Seven, "7");
            this.faces.Add(CardFace.Eight, "8");
            this.faces.Add(CardFace.Nine, "9");
            this.faces.Add(CardFace.Ten, "10");
            this.faces.Add(CardFace.Jack, "J");
            this.faces.Add(CardFace.Queen, "Q");
            this.faces.Add(CardFace.King, "K");
            this.faces.Add(CardFace.Ace, "A");

            this.suits.Add(CardSuit.Clubs, "♣");
            this.suits.Add(CardSuit.Diamonds, "♦");
            this.suits.Add(CardSuit.Hearts, "♥");
            this.suits.Add(CardSuit.Spades, "♠");
        }
    }
}
