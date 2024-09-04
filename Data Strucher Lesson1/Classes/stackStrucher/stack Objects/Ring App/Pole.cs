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
            Stack<Ring> stackL = new Stack<Ring>();
            Stack<Ring> stackS = new Stack<Ring>();
            while (!this.po.IsEmpty())
            {
                Ring ring = this.po.Pop();
                if (ring.GetSize() == "L")
                {
                    stackL.Push(ring);
                }
                else
                {
                    stackS.Push(ring);
                }
            }

            while (!stackL.IsEmpty())
            {
                Ring currentRing = stackL.Pop();
                Add(currentRing);
            }

            while (!stackS.IsEmpty())
            {
                Ring currentRing = stackS.Pop();
                Add(currentRing);
            }
        }

    }
}
