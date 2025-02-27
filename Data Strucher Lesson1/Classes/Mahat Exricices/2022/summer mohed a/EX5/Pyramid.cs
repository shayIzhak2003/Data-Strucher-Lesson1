using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX5
{
    public class Pyramid
    {
        public Stack<Clown> clowns {  get; set; }

        public Pyramid()
        {
            clowns = new Stack<Clown>();
        }

        //pt.1
        public bool IsStable()
        {
            Stack<Clown> temp = new Stack<Clown> ();
            bool flag = true;

            // first
            Clown firstClown = clowns.Pop();
            int prevW = firstClown.GetWeight();
            temp.Push(firstClown);

            while (!clowns.IsEmpty())
            {
                Clown currentClown = clowns.Pop();
                int currentW = currentClown.GetWeight();

                temp.Push(currentClown);
                if (prevW >= currentW)
                    flag = false;

                prevW = currentW;
            }

            while (!temp.IsEmpty())
                clowns.Push(temp.Pop());

            return flag;

        }
        //pt.2
        public bool AddClown(Clown c)
        {
            Stack<Clown> temp = new Stack<Clown>();
            bool canBeAdded = true;

            // If the stack is empty, just push the clown
            if (clowns.IsEmpty())
            {
                clowns.Push(c);
                return true;
            }

            // Check if new clown can be added
            while (!clowns.IsEmpty())
            {
                Clown topClown = clowns.Pop();
                temp.Push(topClown);

                if (topClown.GetWeight() <= c.GetWeight())
                {
                    canBeAdded = false;
                    break;
                }
            }

            // Restore original stack
            while (!temp.IsEmpty())
            {
                clowns.Push(temp.Pop());
            }

            // If valid, push the new clown
            if (canBeAdded)
            {
                clowns.Push(c);
            }

            return canBeAdded;
        }

    }
}
