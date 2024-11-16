using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data_Strucher_Lesson1.Classes.exrisice_for_summer_smaster.Test;

namespace Data_Strucher_Lesson1.Classes.exrisice_for_summer_smaster
{
    public class Test
    {
        // EX1
        public static Queue<int> SumQueues(Queue<int> queue1, Queue<int> queue2)
        {
            Queue<int> resultQueue = new Queue<int>();
            int carry = 0;
            while (!queue1.IsEmpty() || !queue2.IsEmpty() || carry > 0)
            {
                int digit1;
                int digit2;
                if (!queue1.IsEmpty())
                {
                    digit1 = queue1.Remove();
                }
                else
                {
                    digit1 = 0;
                }
                if (!queue2.IsEmpty())
                {
                    digit2 = queue2.Remove();
                }
                else
                {
                    digit2 = 0;
                }
                int sum = digit1 + digit2 + carry;
                resultQueue.Insert(sum % 10); carry = sum / 10;
            }
            return resultQueue;
        }

        // EX2
        public static void SecretMessage(Queue<string> words, Queue<int> wordLengths)
        {
            string mainString = ""; 

            while (!words.IsEmpty() && !wordLengths.IsEmpty())
            {
                int wordLength = wordLengths.Remove();

                if (wordLength <= 0)
                {
                    Console.WriteLine("ERROR: Invalid word length.");
                    return;
                }

                
                if (words.IsEmpty())
                {
                    Console.WriteLine("ERROR: Insufficient words.");
                    return;
                }

                string word = words.Remove();

               
                if (word.Length != wordLength)
                {
                    Console.WriteLine("ERROR: Word length mismatch.");
                    return;
                }

               
                mainString += word;

               
                if (!wordLengths.IsEmpty())
                {
                    mainString += ' '; 
                }
            }

            
            if (!words.IsEmpty() || !wordLengths.IsEmpty())
            {
                Console.WriteLine("ERROR: Queues are inconsistent.");
                return;
            }

           
            Console.WriteLine(mainString);
        }
        //EX3
        //סעיף ב
        public static void FindAndMoveMax(Stack<int> S1, Stack<int> S2)
        {
            if (S1.IsEmpty())
            {
                return; 
            }

            int max = S1.Top(); 

            while (S1.IsEmpty())
            {
                int current = S1.Pop();
                if (current > max)
                {
                    max = current;
                }
                
                S1.Push(current);
            }

           
            while (S1.Top() != max)
            {
                S1.Push(S1.Pop());
            }
            S2.Push(S1.Pop());
        }

        //EX4
        public static void MergeStacks(Stack<int> stack1, Stack<int> stack2)
        {
            if (stack1.IsEmpty() || stack2.IsEmpty())
            {
                throw new ArgumentException("Both stacks must be non-empty.");
            }

            int stack1Length = GetStackLength(stack1);
            int stack2Length = GetStackLength(stack2);

            
            if (stack1Length % 2 == 0 && stack2Length % 2 == 0)
            {
                
                InsertStackIntoMiddle(stack1, stack2);
            }
            else if (stack1Length % 2 != 0 && stack2Length % 2 == 0)
            {
                
                InsertStackIntoMiddle(stack2, stack1);
            }
            else if (stack1Length % 2 == 0 && stack2Length % 2 != 0)
            {
                
                InsertStackIntoMiddle(stack1, stack2);
            }
            
        }

        private static int GetStackLength(Stack<int> stack)
        {
            int length = 0;
            Stack<int> tempStack = new Stack<int>();

            
            while (!stack.IsEmpty())
            {
                int value = stack.Pop();
                tempStack.Push(value);
                length++;
            }

            
            while (!tempStack.IsEmpty())
            {
                stack.Push(tempStack.Pop());
            }

            return length;
        }

        private static void InsertStackIntoMiddle(Stack<int> sourceStack, Stack<int> targetStack)
        {
            int targetStackLength = GetStackLength(targetStack);
            int middleIndex = targetStackLength / 2;

            
            Stack<int> tempStack = new Stack<int>();

            
            for (int i = 0; i < middleIndex; i++)
            {
                tempStack.Push(targetStack.Pop());
            }

            
            Stack<int> tempSourceStack = new Stack<int>();

            while (!sourceStack.IsEmpty())
            {
                tempSourceStack.Push(sourceStack.Pop());
            }

            
            while (!tempSourceStack.IsEmpty())
            {
                targetStack.Push(tempSourceStack.Pop());
            }

           
            while (!tempStack.IsEmpty())
            {
                targetStack.Push(tempStack.Pop());
            }
        }


    }

    public class RunTest
    {
        public static void DemoMain()
        {
            
            TestSumLongNumbers();

            TestSecretMessage();
            TestMergeStacks();
        }

        private static void PrintQueue(Queue<int> queue)
        {
            while (!queue.IsEmpty())
            {
                Console.Write(queue.Remove() + " ");
            }
            Console.WriteLine();
        }

        
        private static void TestSumLongNumbers()
        {
           
            Queue<int> queue1 = new Queue<int>();
            queue1.Insert(1);  // Thousands place
            queue1.Insert(5);  // Hundreds place
            queue1.Insert(0);  // Tens place
            queue1.Insert(0);  // Units place

            Queue<int> queue2 = new Queue<int>();
            queue2.Insert(1);  // Ten-thousands place
            queue2.Insert(2);  // Thousands place
            queue2.Insert(0);  // Hundreds place
            queue2.Insert(0);  // Tens place
            queue2.Insert(0);  // Units place

            
            Queue<int> resultQueue = Test.SumQueues(queue1, queue2);

           
            Console.WriteLine("The sum of the numbers is:");
            PrintQueue(resultQueue);
        }

        
        private static void TestSecretMessage()
        {
            
            Queue<string> words = new Queue<string>();
            words.Insert("Hello there");
            words.Insert("World");

            
            Queue<int> wordLengths = new Queue<int>();
            wordLengths.Insert(11); 
            wordLengths.Insert(5);

           
            Console.WriteLine("The secret message is:");
            Test.SecretMessage(words, wordLengths);
        }


        private static void TestMergeStacks()
        {
            // Create and populate the first stack
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4); // Even length

            // Create and populate the second stack
            Stack<int> stack2 = new Stack<int>();
            stack2.Push(5);
            stack2.Push(6);
            stack2.Push(7); // Odd length

            Console.WriteLine("Before merging:");
            Console.WriteLine($"Stack 1: {stack1}");
            Console.WriteLine($"Stack 2: {stack2}");

            // Merge the stacks
            Test.MergeStacks(stack1, stack2);

            Console.WriteLine("\nAfter merging:");
            Console.WriteLine($"Stack 1: {stack1}");
            Console.WriteLine($"Stack 2: {stack2}");
        }





    }
}
