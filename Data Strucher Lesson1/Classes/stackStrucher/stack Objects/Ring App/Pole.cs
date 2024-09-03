using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Ring_App
{
    public class Pole
    {
        private Stack<Ring> po;
        public Pole()
        {
            this.po = new Stack<Ring>();
        }
        public void Add(Ring r)
        {
            po.Push(r);
        }
        public Ring Remove(Ring r)
        {
             return this.po.Pop();
        }
        public bool IsEmpty()
        {
          return po.IsEmpty();
        }
        public void Sort()
        {

        }

    }
}
