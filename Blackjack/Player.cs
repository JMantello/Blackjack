using System.Collections.Generic;

namespace Blackjack
{
    public class Player
    {
        //fields
        private List<Card> hand;
        private int _points;
        private bool _bust;
        private bool _dealt21;

        //constructor
        public Player()
        {
            hand = new List<Card>();
            _points = 0;
            _bust = false;
            _dealt21 = false;
        }

        //properties
        public Card[] Hand
        {
            get { return hand.ToArray(); }
        }

        public int Points
        {
            get { return _points; }
        }

        public bool Bust
        {
            get { return _bust; }
        }

        public bool Dealt21
        {
            get { return _dealt21; }
        }

        public bool CanHit
        {
            get { return !Bust && Hand.Length < 5 && Points < 21; }
        }

        //methods
        public void StartingDeal(Deck deck)
        {
            hand.Add(deck.Deal());
            Hit(deck);

            if (Points == 21)
                _dealt21 = true;
        }

        public void Hit(Deck deck)
        {
            hand.Add(deck.Deal());
            UpdatePoints();
            UpdateBust();
        }

        public void UpdatePoints()
        {
            _points = 0;
            foreach (Card card in hand)
                _points += card.Value;

            //reduce value of ace
            if (Points > 21)
            {
                foreach (Card card in Hand)
                {
                    if (card.IsAce)
                        _points -= 10;
                    if (Points < 21)
                        return;
                }
            }
        }

        public void UpdateBust()
        {
            if (Points > 21)
                _bust = true;
        }

        public void Reset()
        {
            hand.Clear();
            _points = 0;
            _bust = false;
            _dealt21 = false;
        }
    }
}
