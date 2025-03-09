using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_cl
{
    public interface ICard
    {
        CardFace Face { get; } //initializing getter property for face value of card
        CardSuit Suit { get; } // initializing getter property for suit value of card

        public void Draw(int x, int y); // Calling the Draw() method, to be able to call and display the card on the console.
    }
}
