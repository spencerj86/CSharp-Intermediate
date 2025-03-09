using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_cl
{
    public class BlackjackCard : Card
    {
        public int Value { get; set; }
        public BlackjackCard(CardSuit suit, CardFace face) : base(suit, face)
        {
            switch (face)
            {
                case CardFace.Ace:
                    Value = 11;
                    break;
                case CardFace.Two:
                    Value = 2;
                    break;
                case CardFace.Three:
                    Value = 3;
                    break;
                case CardFace.Four:
                    Value = 4;
                    break;
                case CardFace.Five:
                    Value = 5;
                    break;
                case CardFace.Six:
                    Value = 6;
                    break;
                case CardFace.Seven:
                    Value = 7;
                    break;
                case CardFace.Eight:
                    Value = 8;
                    break;
                case CardFace.Nine:
                    Value = 9;
                    break;
                case CardFace.Ten:
                    Value = 10;
                    break;
                case CardFace.Jack:
                    Value = 10;
                    break;
                case CardFace.Queen:
                    Value = 10;
                    break;
                case CardFace.King:
                    Value = 10;
                    break;
            }

        }
        public void Draw(int x, int y, bool show = true)
        {
            if (show)
            {
                base.Draw(x, y);
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(" ???? ");
                Console.ResetColor();
            }
        }
    }
}
