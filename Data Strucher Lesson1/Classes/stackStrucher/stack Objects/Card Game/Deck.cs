using Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Card_Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects
{
    public class Deck
    {
        private Stack<Card>[] heaps;   // ערימות הקלפים
        private int sum;
        private static Random r = new Random();

        public Deck()
        {
            this.heaps = new Stack<Card>[5];
            for (int i = 0; i < 5; i++)
                this.heaps[i] = new Stack<Card>();
        }
        public void Insert(Card cr)
        {
            Card c = new Card(cr.GetValue(), cr.GetShape());   // ניצור עותק של הקלף
            (this.heaps[cr.GetShape() - 1]).Push(c);
        }
        public bool Move()
        {
            int shape = r.Next(1, 5);
            if (this.heaps[shape - 1].IsEmpty())
                return false;
            else
            {
                this.heaps[4].Push(heaps[shape - 1].Pop());
                this.sum = this.sum + (this.heaps[4].Top()).GetValue();
                return true;
            }
        }
        public int Sum()
        {
            return this.sum;
        }
    }
}
