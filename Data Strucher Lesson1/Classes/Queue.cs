using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;
        //-----------------------------------
        // constructor
        public Queue()
        {
            this.first = null;
            this.last = null;
        }
        //-----------------------------------
        // adds element x to the end of the queue
        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);
            if (this.first == null)
                this.first = temp;
            else
                this.last.SetNext(temp);
            this.last = temp;
        }
        //-----------------------------------
        // removes & returns the element from the head of the queue
        public T Remove()
        {
            if (IsEmpty())
                return default(T);
            T x = this.first.GetValue();
            this.first = this.first.GetNext();
            if (this.first == null)
                this.last = null;
            return x;
        }
        //-----------------------------------
        // returns the element from the head of the queue
        public T Head()
        {
            return this.first.GetValue();
        }
        //-----------------------------------
        //returns true if there are no elements in queue
        public bool IsEmpty()
        {
            return this.first == null;
        }
        //-------------------------------------
        // ToString
        public override string ToString()
        {
            if (this.IsEmpty())
                return "[]";
            string temp = this.first.ToString();
            return "QueueHead[" + temp.Substring(0, temp.Length - 1) + "]";
        }
    }
}
