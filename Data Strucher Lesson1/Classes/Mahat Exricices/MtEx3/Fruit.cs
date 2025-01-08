using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices.MtEx3
{
    public class Fruit
    {
        // תכונה מוגנת למשקל
        protected int weight;

        // בנאי לקבלת ערך התחלתי למשקל
        public Fruit(int weight)
        {
            this.weight = weight;
        }

        // פעולה המחזירה את המשקל
        public int GetWeight()
        {
            return this.weight;
        }

        // פעולה וירטואלית שניתן לעקוף במחלקות יורשות
        public virtual string GetDescription()
        {
            return $"Fruit with weight: {this.weight}";
        }
    }

}
