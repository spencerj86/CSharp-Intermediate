using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_cl
{
    public class Factory
    {
        public static ICard CreateCard(CardFace face, CardSuit suit)
        {
            return new Card(suit, face);
        }
        public static ICard CreateBlackjackCard(CardFace face, CardSuit suit)
        {
            return new BlackjackCard(suit, face);
        }
    }
}
