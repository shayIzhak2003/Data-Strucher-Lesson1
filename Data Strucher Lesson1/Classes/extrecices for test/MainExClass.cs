using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class MainExClass
    {
        // liner lists start
        //EX1
        public static int Sum(IntNode lst)
        {
            int sum = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                sum += pos.GetValue();
                pos = pos.GetNext();
            }
            return sum;
        }
        //EX2
        public static bool IsExsist(IntNode lst, int num)
        {
            IntNode pos = lst;
            while (pos != null)
            {
                if (pos.GetValue() == num)
                {
                    return true;
                }
                pos = pos.GetNext();
            }
            return false;
        }
        //EX3
        public static void EnterLast(IntNode lst, int num)
        {
            IntNode pos = lst;
            while (pos.HasNext())
            {
                pos = pos.GetNext();
            }
            pos.SetValue(num);
        }
        //EX4
        public static void EnterSecond(IntNode lst, int num)
        {
            int count = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                count++;
                if (count == 2)
                {
                    pos.SetValue(num);
                }
                pos = pos.GetNext();
            }
        }
        //EX5
        public static int Size(IntNode lst)
        {
            int count = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }
        //EX6
        public static int HowMany(IntNode lst, int num)
        {
            int count = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                if (pos.GetValue() == num)
                    count++;

                pos = pos.GetNext();
            }
            return count;
        }
        //EX7
        public static bool InOrder(IntNode lst)
        {
            IntNode pos = lst;
            while (pos.HasNext())
            {
                if (pos.GetValue() > pos.GetNext().GetValue())
                    return false;

                pos = pos.GetNext();
            }
            return true;
        }
        //EX8
        public static int SumOdd(IntNode lst)
        {
            IntNode pos = lst;
            int count = 0;
            int sum = 0;
            while (pos != null)
            {
                count++;
                if (count % 2 != 0)
                    sum += pos.GetValue();

                pos = pos.GetNext();
            }
            return sum;
        }
        //EX9
        public static void EnterInOrder(IntNode lst, int num)
        {
            IntNode newNode = new IntNode(num);

            if (lst == null || lst.GetValue() >= num)
            {
                newNode.setNext(lst);
                lst = newNode;
                return;
            }


            IntNode current = lst;
            while (current.HasNext() && current.GetNext().GetValue() < num)
            {
                current = current.GetNext();
            }

            newNode.setNext(current.GetNext());
            current.setNext(newNode);
        }
        //EX10
        public static bool IsSerial(IntNode lst)
        {
            if (lst == null || !lst.HasNext())
                return true;

            IntNode current = lst;
            int diff = current.GetNext().GetValue() - current.GetValue();
            while (current.HasNext())
            {
                if (current.GetNext().GetValue() - current.GetValue() != diff)
                    return false;

                current = current.GetNext();
            }
            return true;
        }
        //EX11
        public static IntNode RemovePos(IntNode lst, int num)
        {
            IntNode pos = lst;
            int count = 0;
            while (pos != null)
            {
                count++;
                if (count == num)
                {
                    pos.setNext(pos.GetNext().GetNext());
                }
                pos = pos.GetNext();
            }
            return pos;
        }
        //EX12
        public static int ReturnAtPos(IntNode lst, int step)
        {
            IntNode pos = lst;
            int count = 0;
            int val = 0; ;
            while (pos != null)
            {
                count++;
                if (count == step)
                {
                    val = pos.GetValue();
                }
                pos = pos.GetNext();
            }
            return val;
        }
        //EX13
        public static int ReturnNum(IntNode lst, int num)
        {
            IntNode pos = lst;
            int count = 0;
            while (pos != null)
            {
                count++;
                if (num == pos.GetValue())
                {
                    return count;
                }
                pos = pos.GetNext();
            }
            return -1;

        }
        //EX14
        public static int Max(IntNode lst)
        {
            IntNode pos = lst;
            int max = pos.GetValue();
            while (pos != null)
            {
                if (pos.GetValue() > max)
                {
                    max = pos.GetValue();
                }
                pos = pos.GetNext();
            }
            return max;
        }
        //EX15
        public static int Prev(IntNode lst, int num)
        {
            IntNode pos = lst;
            int prev = 0;
            while (pos != null)
            {
                if (pos.GetNext().GetValue() == num)
                {
                    return pos.GetValue();
                }
                pos = pos.GetNext();
            }
            return -1;
        }
        // liner lists ends

        //Node<T> Extracisses Start
        public static Node<int> BuildEvenNode(Node<int> lst)
        {
            Node<int> pos = lst;
            Node<int> nodeHead = null;
            Node<int> nodeTail = null;
            while (pos != null)
            {
                if (pos.GetValue() % 2 == 0)
                {
                    Node<int> newNode = new Node<int>(pos.GetValue());
                    if (nodeHead != null)
                    {
                        nodeHead = newNode;
                        nodeTail = newNode;
                    }
                    else
                    {
                        nodeTail.SetNext(newNode);
                        nodeTail = newNode;
                    }
                }
                pos = pos.GetNext();
            }
            return nodeHead;
        }
        //Node<T> Extracisses Start

        //Two ways List Starts
        //EX1
        public static BinNode<int> BuildRandomList(int size, int from, int to)
        {
            Random random = new Random();
            int value = random.Next(from, to);
            BinNode<int> root = new BinNode<int>(value);
            BinNode<int> pos = root;

            for (int i = 0; i < size; i++)
            {
                int randomValue = random.Next(from, to);
                pos.SetRight(new BinNode<int>(pos, randomValue, null));
                pos =  pos.GetRight();
            }
            return root;

        }
        //Printing TwoList (Basic Printing)
        public static void PrintTwoWayList(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos + ",");
                pos = pos.GetRight();
            }
            Console.WriteLine("]");
        }
        //EX2
        public static void PrintFromLeft(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos + ",");
                pos = pos.GetRight();
            }
            Console.WriteLine("]");
        }
        //EX3
        public static void PrintFromRight(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            while (pos.HasRight())
            {
                pos = pos.GetRight();
            }

            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos + ",");
                pos = pos.GetLeft();
            }
            Console.WriteLine("]");
        }
        //EX4


        //EX5
        public static BinNode<int>DeleteNode(BinNode<int> lst, int x)
        {
            BinNode<int> pos = lst;
            while (pos != null)
            {
                if (pos.GetValue() > x)
                {
                    BinNode<int> posL = pos.GetLeft();
                    BinNode<int> posR = pos.GetRight();

                    if (posL == null && posR == null)
                    {
                        // Node is a single node and matches the condition, list becomes empty
                        return null;
                    }
                    else if (posL == null)
                    {
                        // Node is the head of the list
                        posR.SetLeft(null);
                        if (pos == lst) lst = posR;
                    }
                    else if (posR == null)
                    {
                        // Node is the tail of the list
                        posL.SetRight(null);
                        if (pos == lst) lst = posL;
                    }
                    else
                    {
                        // Node is in the middle of the list
                        posL.SetRight(posR);
                        posR.SetLeft(posL);
                        if (pos == lst) lst = posR;
                    }
                }
                pos = pos.GetRight();
            }
            return pos;
        }

        //EX7
        public static BinNode<int> BuildSortedRandomList(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("The size of the list should be greater than 0!");
            }

            Random rnd = new Random();
            int randomValue = rnd.Next(1, 31);
            BinNode<int> firstValue = new BinNode<int>(randomValue);
            BinNode<int> pos = firstValue;

            for (int i = 1; i <=size; i++)
            {
                int newValue;
                do
                {
                    newValue = rnd.Next(1, 31);
                } while (newValue <= pos.GetValue());

                BinNode<int> newNode = new BinNode<int>(newValue);
                pos.SetRight(newNode);
                newNode.SetLeft(pos);
                pos = newNode;
            }

            return firstValue;
        }
        //Circle Ex Of Lesson 4
        //EX1

        //EX2
        public static void MakeCircleToLinear(Node<int> lst)
        {
            if (lst == null)
                return;

            Node<int> pos = lst;
            Node<int> headNode = null;
            Node<int> tailNode = null;
            bool firstNode = true;

            do
            {
                Node<int> newNode = new Node<int>(pos.GetValue());
                if (firstNode)
                {
                    headNode = newNode;
                    tailNode = newNode;
                    firstNode = false;
                }
                else
                {
                    tailNode.SetNext(newNode);
                    tailNode = newNode;
                }
                pos = pos.GetNext();
            } while (pos != lst);

            PrintLinearList(headNode);
        }

        public static void PrintLinearList(Node<int> lst)
        {
            Node<int> pos = lst;
            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos.GetValue() + (pos.GetNext() != null ? ", " : ""));
                pos = pos.GetNext();
            }
            Console.WriteLine("]");
        }
    }
    public class RunMainExClass
    {
        public static void DemoMain()
        {
            //IntNode n1 = new IntNode(14);
            //IntNode n2 = new IntNode(24);
            //IntNode n3 = new IntNode(34);
            //IntNode n4 = new IntNode(44);
            //IntNode n5 = new IntNode(54);
            //n1.setNext(n2);
            //n2.setNext(n3);
            //n3.setNext(n4);
            //n4.setNext(n5);
            //int sum = MainExClass.Sum(n1);
            //Console.WriteLine($"the sum of the list is : {sum}");
            //int num = 1;
            //Console.WriteLine($"is the number {num} in the list? {MainExClass.IsExsist(n1, num)}");
            //Console.WriteLine("\nthe original list :");
            //IntNode.print(n1);
            ////Console.WriteLine("the list after entering 30 in the second place!");
            ////MainExClass.EnterSecond(n1, 30);
            ////IntNode.print(n1);
            //Console.WriteLine($"the size of the list is : {MainExClass.Size(n1)}");
            //Console.WriteLine($"the amount of times the the number 14 is of the list is {MainExClass.HowMany(n1, 14)}");
            //Console.WriteLine($"is the list in order ? {MainExClass.InOrder(n1)}");
            //Console.WriteLine($"the sum in the odd indexs is {MainExClass.SumOdd(n1)}");
            ////MainExClass.EnterInOrder(n1, 45);
            ////IntNode.print(n1);
            //Console.WriteLine($"is the list serial? {MainExClass.IsSerial(n1)}");
            //Console.WriteLine("the list after deleteing 54 :");
            ////MainExClass.RemovePos(n1,5);
            ////IntNode.print(n1);
            //Console.WriteLine($"the value in node 3 is {MainExClass.ReturnAtPos(n1, 3)}");
            //Console.WriteLine($"the first place to have the value 14 is {MainExClass.ReturnNum(n1, 14)}");
            //Console.WriteLine($"the node with the biggest value is  : {MainExClass.Max(n1)}");
            //Console.WriteLine($"the value before node 2 is {MainExClass.Prev(n1,2)}");

            //================================================================================

            ////EX1
            //Console.WriteLine("Filter Even Values Maintain Order:");
            //Node<int> node1 = new Node<int>(1);
            //Node<int> node2 = new Node<int>(2, node1);
            //Node<int> node3 = new Node<int>(3, node2);
            //Node<int> node4 = new Node<int>(4, node3);
            //Node<int> node5 = new Node<int>(5, node4);
            //Node<int> node6 = new Node<int>(6, node5);

            //Node<int> evenNodeList = MainExClass.BuildEvenNode(node1);
            //Console.WriteLine("Even Nodes (Maintain Order): " + evenNodeList.ToPrint());

            //Two List Ex
            //EX1
            //BinNode<int> randomList = MainExClass.BuildRandomList(6, 1, 100);
            //MainExClass.PrintFromLeft(randomList);
            //MainExClass.PrintFromRight(randomList);
            ////EX7
            //Console.WriteLine();
            //BinNode<int> randomSortedList = MainExClass.BuildSortedRandomList(4);
            //MainExClass.PrintFromLeft(randomSortedList);

            //===========================
            // Create circular linked list manually
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);
            Node<int> node6 = new Node<int>(6);

            // Circular linking
            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node5);
            node5.SetNext(node6);
            node6.SetNext(node1);
            MainExClass.MakeCircleToLinear(node1);



        }
    }
}
