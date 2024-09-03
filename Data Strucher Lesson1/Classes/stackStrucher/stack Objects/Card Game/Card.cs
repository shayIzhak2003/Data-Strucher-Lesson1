using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Card_Game
{
    public class Card
    {
        public int value;
        public int shape;
        public Card(int value, int shape)
        {
            this.value = value;
            this.shape = shape;
        }
        public int GetValue()
        {
            return this.value;
        }

        public int GetShape()
        {
            return this.shape;
        }


    }
}
