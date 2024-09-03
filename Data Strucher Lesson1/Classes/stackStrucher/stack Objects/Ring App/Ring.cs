using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Ring_App
{
    public class Ring
    {
        private string size;
        private int color;

        public Ring(string size, int color)
        {
            this.size = size;
            this.color = color;
        }
        public Ring()
        {
            this.size = "L";
            this.color = 0;
        }
        public string GetSize()
        {
            return this.size;
        }
        public int GetColor()
        {
            return this.color;
        }

    }
}
