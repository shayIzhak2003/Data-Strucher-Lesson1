using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices.MtEx3
{
    public class Apple : Fruit
    {
        // תכונה פרטית לצבע התפוח
        private string color;

        // בנאי לקבלת משקל וצבע
        public Apple(int weight, string color) : base(weight)
        {
            this.color = color;
        }

        // פעולה לבדיקת תקינות המשקל
        public bool ValidWeight()
        {
            return this.weight > 80 && this.weight < 140;
        }

        // פעולה המחזירה את הצבע
        public string GetColor()
        {
            return this.color;
        }

        // עקיפת הפעולה `GetDescription`
        public override string GetDescription()
        {
            return $"Apple with weight: {this.weight} and color: {this.color}";
        }
    }

}
