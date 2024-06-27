using Data_Structure_Lesson1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class Ex2
    {
         // EX1
        public static Node<int> FilterEvenValuesMaintainOrder(Node<int> head)
        {
            Node<int> nodeHead = null;
            Node<int> nodeTail = null;
            Node <int> current = head;

            while (current != null)
            {
                if(current.GetValue() % 2 == 0)
                {
                    // this is how i make new node!
                    Node<int> newNode = new Node<int>(current.GetValue());
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
                current.GetNext();
            }
            return nodeHead;
        }
        //EX2
        //Helpers Functions
        public static bool IsComplementary(char base1, char base2)
        {
            return (base1 == 'A' && base2 == 'T') ||
                   (base1 == 'T' && base2 == 'A') ||
                   (base1 == 'C' && base2 == 'G') ||
                   (base1 == 'G' && base2 == 'C');
        }
        public static char GetComplementaryBase(char baseChar)
        {
            if (baseChar == 'A')
            {
                return 'T';
            }
            else if (baseChar == 'T')
            {
                return 'A';
            }
            else if (baseChar == 'C')
            {
                return 'G';
            }
            else if (baseChar == 'G')
            {
                return 'C';
            }
            else
            {
                throw new ArgumentException("Invalid DNA base");
            }

        }
        public static bool AreComplementary(Node<char> strand1, Node<char> strand2)
        {
            while(strand1!=null && strand2 != null)
            {
                char base1 = strand1.GetValue();
                char base2 = strand2.GetValue();

                if(!IsComplementary(base1, base2))
                {
                    return false;
                }
                strand1 = strand1.GetNext();
                strand2 = strand2.GetNext();
            }
            return strand1 == null && strand2 == null;
        }

        public static Node<char> GetComplementaryStrand(Node<char> strand)
        {
            if(strand == null)
                return null;

            Node<char> newHead = null;
            Node<char> newTail = null;

            Node<char> current = strand;

            while(current != null)
            {
                char complementaryBase = GetComplementaryBase(current.GetValue());
                Node<char> newNode = new Node<char>(complementaryBase);
                if(newHead == null)
                {
                    newHead = newNode;
                    newTail = newNode;
                }
                else
                {
                    newTail.SetNext(newNode);
                    newTail = newNode;
                }
                current = current.GetNext();
            }
            return newHead;
        }
        public static Node<int> RemoveAllOccurrences(Node<int> head, int value)
        {
            Node<int> current = head;
            while(current != null)
            {
                if(current.GetValue() == value)
                {
                    current = current.GetNext().GetNext();
                }
                current = current.GetNext();
            }
            return current;
        }
    }
    public class RunEx2
    {

        public static void DemoMain()
        {
            //EX1
            Console.WriteLine("Filter Even Values Maintain Order:");
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2, node1);
            Node<int> node3 = new Node<int>(3, node2);
            Node<int> node4 = new Node<int>(4, node3);
            Node<int> node5 = new Node<int>(5, node4);
            Node<int> node6 = new Node<int>(6, node5);

            Node<int> evenNodeList = NodeTUsageForHomeWORK.FilterEvenValuesMaintainOrder(node6);
            Console.WriteLine("Even Nodes (Maintain Order): " + evenNodeList.ToPrint());

            //EX2
            Console.WriteLine("\nDNA Strand Complementarity:");
            Node<char> strand1 = new Node<char>('A');
            strand1.SetNext(new Node<char>('T'));
            strand1.GetNext().SetNext(new Node<char>('C'));
            strand1.GetNext().GetNext().SetNext(new Node<char>('G'));

            Node<char> strand2 = new Node<char>('T');
            strand2.SetNext(new Node<char>('A'));
            strand2.GetNext().SetNext(new Node<char>('G'));
            strand2.GetNext().GetNext().SetNext(new Node<char>('C'));

            bool areComplementary = NodeTUsageForHomeWORK.AreComplementary(strand1, strand2);
            Console.WriteLine("Are Complementary: " + areComplementary);

            Node<char> complementaryStrand = NodeTUsageForHomeWORK.GetComplementaryStrand(strand1);
            Console.WriteLine("Complementary Strand: " + complementaryStrand.ToPrint());

            //EX3
            Console.WriteLine("\nRemove All Occurrences:");
            Node<int> node12 = new Node<int>(8);
            node12.SetNext(new Node<int>(8));
            node12.GetNext().SetNext(new Node<int>(5));
            node12.GetNext().GetNext().SetNext(new Node<int>(8));
            node12.GetNext().GetNext().GetNext().SetNext(new Node<int>(2));
            node12.GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(8));
            node12.GetNext().GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(4));
            node12.GetNext().GetNext().GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(3));
            node12.GetNext().GetNext().GetNext().GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(8));

            Console.WriteLine("Original List: " + node12.ToPrint());

            Node<int> newHead = NodeTUsageForHomeWORK.RemoveAllOccurrences(node12, 8);
            Console.WriteLine("Modified List: " + newHead.ToPrint());

            //EX4
        }
    }
}
