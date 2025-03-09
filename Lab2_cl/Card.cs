using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_cl
{
    public class Card : ICard // Creating a Card class, deriving from ICard Interface
    {
        public CardSuit Suit // Cardsuit Property
        {
            get; private set;
        }
        public CardFace Face // CardFace Property
        {
            get; private set;
        }
        public Card(CardSuit suit, CardFace face) // Card Constructor, overloaded with suit and face, turning them to the property Face, and Suit
        {
            Suit = suit; 
            Face = face;
        }
        public void Draw(int x, int y) //initialize Draw method, with int x and y initialized as variables of int
        {
            Encoding originalEncoding = Console.OutputEncoding;
            Console.BackgroundColor = ConsoleColor.White; //Creates background color for the cards to display
            if(Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds) //checking for red suits
            {
                Console.ForegroundColor = ConsoleColor.Red; //sets color to red for red suits
            }
            else // if not red suits
            {
                Console.ForegroundColor = ConsoleColor.Black; // sets color to black for black suits
            }
            string faceNumber = ""; // initialize card face variable
            switch (Face) //switch shortcut, super cool 8)
            {
                case CardFace.Ace:
                    faceNumber = "A";
                    break;
                case CardFace.Two:
                    faceNumber = "2";
                    break;
                case CardFace.Three:
                    faceNumber = "3";
                    break;
                case CardFace.Four:
                    faceNumber = "4";
                    break;
                case CardFace.Five:
                    faceNumber = "5";
                    break;
                case CardFace.Six:
                    faceNumber = "6";
                    break;
                case CardFace.Seven:
                    faceNumber = "7";
                    break;
                case CardFace.Eight:
                    faceNumber = "8";
                    break;
                case CardFace.Nine:
                    faceNumber = "9";
                    break;
                case CardFace.Ten:
                    faceNumber = "10";
                    break;
                case CardFace.Jack:
                    faceNumber = "J";
                    break;
                case CardFace.Queen:
                    faceNumber = "Q";
                    break;
                case CardFace.King:
                    faceNumber = "K";
                    break;
            }
            char cardSuit = ' '; 
            switch (Suit)
            {
                case CardSuit.Hearts:
                    cardSuit = '\u2665';
                    break;
                case CardSuit.Diamonds:
                    cardSuit = '\u2666';
                    break;
                case CardSuit.Clubs:
                    cardSuit = '\u2663';
                    break;
                case CardSuit.Spades:
                    cardSuit = '\u2660';
                    break;
            }
            Console.SetCursorPosition(x, y);
            Console.Write($" {faceNumber,-2} {cardSuit} ");
            Console.ResetColor();
            Console.OutputEncoding = originalEncoding;
        }
    }
}
