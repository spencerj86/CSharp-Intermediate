using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_cl
{
    public class BlackjackHand : Hand
    {
        public int Score { get; private set; }
        public bool IsDealer { get; set; }
        public BlackjackHand(bool isDealer = false)
        {
            IsDealer = isDealer;
        }
        public override void AddCard(ICard card)
        {
            base.AddCard(card);
            CalculateScore();
        }
        public override void Draw(int x, int y)
        {
            bool firstHand = false;
            if (!IsDealer || !firstHand)
            {
                base.Draw(x, y);
            }
            else
            {
                int xPos = x;
                int yPos = y;
                for (int i = 0; i < _cards.Count; i++)
                {
                    if (i == 0)
                        ((BlackjackCard)_cards[i]).Draw(xPos, yPos, false);
                    else
                        _cards[i].Draw(xPos, yPos);


                    xPos += 7;
                    if (xPos > Console.WindowWidth - 7)
                    {
                        yPos += 2;
                        xPos = x;
                    }
                }

            }
        }
        private void CalculateScore()
        {
            int value = 0;
            int acesCount = 0;
            foreach (BlackjackCard card in _cards)
            {
                value += card.Value;
                if (card.Face == CardFace.Ace)
                    acesCount++;
            }
            if (value > 21)
            {
                for (int i = 0; i < acesCount; i++)
                {
                    value -= 10;
                    if (value <= 21)
                        break;
                }
            }
            Score = value;
        }
    }
}
