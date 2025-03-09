using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_cl
{
    public class Hand
    {
        protected List<ICard> _cards = new List<ICard>();
        public virtual void AddCard(ICard card)
        {
            _cards.Add(card);
        }
        public virtual void Draw(int x, int y)
        {
            int xPos = x;
            int yPos = y;
            foreach (Card card in _cards)
            {
                card.Draw(xPos, yPos);
                xPos += 7;
                if (xPos > Console.WindowWidth - 7)
                {
                    yPos += 2;
                    xPos = x;
                }
            }
        }
    }
}
