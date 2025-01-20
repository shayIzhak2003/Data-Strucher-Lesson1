using System;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exercises._2022.Ex3
{
    public class A
    {
        // Base method to be overridden
        protected virtual void A1()
        {
            Console.WriteLine("Hello A!");
        }

        // Public method to allow calling A1 indirectly
        public void CallA1()
        {
            A1();
        }
    }

    public class B : A
    {
        // Override A1 method
        protected override void A1()
        {
            Console.WriteLine("Bye B!");
        }
    }

    public class RunB
    {
        public static void DemoMain()
        {
            // Create an instance of B as type A
            A b = new B();

            // Call the A1 method indirectly using the public method
            b.CallA1();
        }
    }
}
