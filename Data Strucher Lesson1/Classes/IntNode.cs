﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes
{
    public class IntNode
    {
        private int value;
        private IntNode next;
        public IntNode(int value)
        {
            this.value = value;
            this.next = null;
        }
        public IntNode(int value, IntNode next)
        {
            this.value = value;
            this.next = next;
        }
        public int GetValue()
        {
            return this.value;
        }
        public IntNode GetNext()
        {
            return this.next;
        }
        public void SetValue(int value)
        {
            this.value = value;
        }
        public void setNext(IntNode next)
        {
            this.next = next;
        }
        public string toString()
        {
            return this.value + " ";
        }
        public bool HasNext() { return next != null; }

        public override string ToString() { return value.ToString(); }

        public static void print(IntNode lst)
        {
            IntNode pos = lst;
            while (pos != null)
            {
                // הדפס את האיבר
                Console.Write(pos.GetValue() + "-->");
                // עבור לאיבר הבא
                pos = pos.GetNext();
            }
            Console.WriteLine();
        }

    }
}
