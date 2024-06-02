using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes
{
    public class Node<T>
    {
        private T value;
        private Node<T> next;

        
        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }

        
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

       
        public T GetValue()
        {
            return this.value;
        }

        
        public Node<T> GetNext()
        {
            return this.next;
        }

        
        public bool HasNext()
        {
            return this.next != null;
        }

        
        public void SetValue(T value)
        {
            this.value = value;
        }

        
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }

       
        public override string ToString()
        {
            return value+" ";
        }

        
        public string ToPrint()
        {
            if (this.HasNext())
            {
                return value + "=>" + this.next.ToPrint();
            }
            return value + "=>null";  
        }
    }
}
