using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class Deck
    {
        private Random random;
        private readonly List<Card> cards;
        private List<Card> activeCards;
        private List<Card> inactiveCards;


        public Deck()
        {
            cards = new List<Card>();
            InitializeListOfCards();
            activeCards = new List<Card>();
            inactiveCards = cards.ToList();
            random = new Random();
        }

        public Card Deal()
        {
            //shuffle if cards run out
            if (inactiveCards.Count == 0)
                ShuffleDeck();

            //deal new card from inactive card list
            Card card = inactiveCards[random.Next(inactiveCards.Count)];
            activeCards.Add(card);
            inactiveCards.Remove(card);
            return card;
        }

        private void ShuffleDeck()
        {
            activeCards.Clear();
            inactiveCards.Clear();
            inactiveCards = cards.ToList();
        }

        private void InitializeListOfCards()
        {
            //suits
            string clubs = "clubs";
            string hearts = "hearts";
            string spades = "spades";
            string diamonds = "diamonds";

            //types
            string ace = "ace";
            string number = "number";
            string jack = "jack";
            string queen = "queen";
            string king = "king";

            //clubs
            Card card0 = new Card(ace, clubs, 11);
            Card card1 = new Card(number, clubs, 2);
            Card card2 = new Card(number, clubs, 3);
            Card card3 = new Card(number, clubs, 4);
            Card card4 = new Card(number, clubs, 5);
            Card card5 = new Card(number, clubs, 6);
            Card card6 = new Card(number, clubs, 7);
            Card card7 = new Card(number, clubs, 8);
            Card card8 = new Card(number, clubs, 9);
            Card card9 = new Card(number, clubs, 10);
            Card card10 = new Card(jack, clubs, 10);
            Card card11 = new Card(queen, clubs, 10);
            Card card12 = new Card(king, clubs, 10);
            card0.Image = Properties.Resources.AC;
            card1.Image = Properties.Resources._2C;
            card2.Image = Properties.Resources._3C;
            card3.Image = Properties.Resources._4C;
            card4.Image = Properties.Resources._5C;
            card5.Image = Properties.Resources._6C;
            card6.Image = Properties.Resources._7C;
            card7.Image = Properties.Resources._8C;
            card8.Image = Properties.Resources._9C;
            card9.Image = Properties.Resources._10C;
            card10.Image = Properties.Resources.JC;
            card11.Image = Properties.Resources.QC;
            card12.Image = Properties.Resources.KC;

            //hearts
            Card card13 = new Card(ace, hearts, 11);
            Card card14 = new Card(number, hearts, 2);
            Card card15 = new Card(number, hearts, 3);
            Card card16 = new Card(number, hearts, 4);
            Card card17 = new Card(number, hearts, 5);
            Card card18 = new Card(number, hearts, 6);
            Card card19 = new Card(number, hearts, 7);
            Card card20 = new Card(number, hearts, 8);
            Card card21 = new Card(number, hearts, 9);
            Card card22 = new Card(number, hearts, 10);
            Card card23 = new Card(jack, hearts, 10);
            Card card24 = new Card(queen, hearts, 10);
            Card card25 = new Card(king, hearts, 10);
            card13.Image = Properties.Resources.AH;
            card14.Image = Properties.Resources._2H;
            card15.Image = Properties.Resources._3H;
            card16.Image = Properties.Resources._4H;
            card17.Image = Properties.Resources._5H;
            card18.Image = Properties.Resources._6H;
            card19.Image = Properties.Resources._7H;
            card20.Image = Properties.Resources._8H;
            card21.Image = Properties.Resources._9H;
            card22.Image = Properties.Resources._10H;
            card23.Image = Properties.Resources.JH;
            card24.Image = Properties.Resources.QH;
            card25.Image = Properties.Resources.KH;

            //spades
            Card card26 = new Card(ace, spades, 11);
            Card card27 = new Card(number, spades, 2);
            Card card28 = new Card(number, spades, 3);
            Card card29 = new Card(number, spades, 4);
            Card card30 = new Card(number, spades, 5);
            Card card31 = new Card(number, spades, 6);
            Card card32 = new Card(number, spades, 7);
            Card card33 = new Card(number, spades, 8);
            Card card34 = new Card(number, spades, 9);
            Card card35 = new Card(number, spades, 10);
            Card card36 = new Card(jack, spades, 10);
            Card card37 = new Card(queen, spades, 10);
            Card card38 = new Card(king, spades, 10);
            card26.Image = Properties.Resources.AS;
            card27.Image = Properties.Resources._2S;
            card28.Image = Properties.Resources._3S;
            card29.Image = Properties.Resources._4S;
            card30.Image = Properties.Resources._5S;
            card31.Image = Properties.Resources._6S;
            card32.Image = Properties.Resources._7S;
            card33.Image = Properties.Resources._8S;
            card34.Image = Properties.Resources._9S;
            card35.Image = Properties.Resources._10S;
            card36.Image = Properties.Resources.JS;
            card37.Image = Properties.Resources.QS;
            card38.Image = Properties.Resources.KS;

            //diamonds
            Card card39 = new Card(ace, diamonds, 11);
            Card card40 = new Card(number, diamonds, 2);
            Card card41 = new Card(number, diamonds, 3);
            Card card42 = new Card(number, diamonds, 4);
            Card card43 = new Card(number, diamonds, 5);
            Card card44 = new Card(number, diamonds, 6);
            Card card45 = new Card(number, diamonds, 7);
            Card card46 = new Card(number, diamonds, 8);
            Card card47 = new Card(number, diamonds, 9);
            Card card48 = new Card(number, diamonds, 10);
            Card card49 = new Card(jack, diamonds, 10);
            Card card50 = new Card(queen, diamonds, 10);
            Card card51 = new Card(king, diamonds, 10);
            card39.Image = Properties.Resources.AD;
            card40.Image = Properties.Resources._2D;
            card41.Image = Properties.Resources._3D;
            card42.Image = Properties.Resources._4D;
            card43.Image = Properties.Resources._5D;
            card44.Image = Properties.Resources._6D;
            card45.Image = Properties.Resources._7D;
            card46.Image = Properties.Resources._8D;
            card47.Image = Properties.Resources._9D;
            card48.Image = Properties.Resources._10D;
            card49.Image = Properties.Resources.JD;
            card50.Image = Properties.Resources.QD;
            card51.Image = Properties.Resources.KD;

            //add cards to cards list
            cards.Add(card0);
            cards.Add(card1);
            cards.Add(card2);
            cards.Add(card3);
            cards.Add(card4);
            cards.Add(card5);
            cards.Add(card6);
            cards.Add(card7);
            cards.Add(card8);
            cards.Add(card9);
            cards.Add(card10);
            cards.Add(card11);
            cards.Add(card12);
            cards.Add(card13);
            cards.Add(card14);
            cards.Add(card15);
            cards.Add(card16);
            cards.Add(card17);
            cards.Add(card18);
            cards.Add(card19);
            cards.Add(card20);
            cards.Add(card21);
            cards.Add(card22);
            cards.Add(card23);
            cards.Add(card24);
            cards.Add(card25);
            cards.Add(card26);
            cards.Add(card27);
            cards.Add(card28);
            cards.Add(card29);
            cards.Add(card30);
            cards.Add(card31);
            cards.Add(card32);
            cards.Add(card33);
            cards.Add(card34);
            cards.Add(card35);
            cards.Add(card36);
            cards.Add(card37);
            cards.Add(card38);
            cards.Add(card39);
            cards.Add(card40);
            cards.Add(card41);
            cards.Add(card42);
            cards.Add(card43);
            cards.Add(card44);
            cards.Add(card45);
            cards.Add(card46);
            cards.Add(card47);
            cards.Add(card48);
            cards.Add(card49);
            cards.Add(card50);
            cards.Add(card51);
        }
    }
}
