using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Card_Game
{
    public class Game
    {
        Deck dc;

        public bool IsWin(Card[] cards)
        {
            bool moveDone = true;
            this.dc = new Deck();
            for (int i = 0; i < cards.Length; i++)
            {
                this.dc.Insert(cards[i]);
            }
            while (moveDone)
            {
                moveDone = this.dc.Move();
            }

            if (this.dc.Sum() % 100 == 0)
                return true;
            else
                return false;
            //  return (this.dc.Sum() % 100 == 0);  
        }
    }
}
