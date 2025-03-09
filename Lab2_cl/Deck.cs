using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_cl
{
    public class Deck
    {
        List<ICard> cardList;
        public Deck()
        {
            BuildDeck();
        }
        public ICard Deal()
        {
            if(cardList.Count == 0)
            {
                BuildDeck();
                Shuffle();
            }

            ICard card = Factory.CreateBlackjackCard(cardList[0].Face, cardList[0].Suit);
            cardList.RemoveAt(0);
            return card;
        }
        public void Shuffle()
        {
            Random rng = new Random();
            List<ICard> shuffleCards = new List<ICard>();
            int i = 0;
            while (cardList.Count > 0)
            {
                i = rng.Next(0, cardList.Count);
                shuffleCards.Add(cardList[i]);
                cardList.RemoveAt(i);
            }
            cardList = shuffleCards;
        }

        private void BuildDeck()
        {
            cardList = new List<ICard>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardFace face in Enum.GetValues(typeof(CardFace)))
                {
                    cardList.Add(Factory.CreateBlackjackCard(face, suit));
                }
            }
        }
    }
}
