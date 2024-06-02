using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes
{
    internal class NodeTUsageForHomeWORK
    {
        //EX1
        public static Node<int> FilterEvenValuesMaintainOrder(Node<int> head)
        {
            Node<int> newHead = null;
            Node<int> newTail = null;

            Node<int> current = head;
            while (current != null)
            {
                if (current.GetValue() % 2 == 0)
                {
                    Node<int> newNode = new Node<int>(current.GetValue());
                    if (newHead == null)
                    {
                        newHead = newNode;
                        newTail = newNode;
                    }
                    else
                    {
                        newTail.SetNext(newNode);
                        newTail = newNode;
                    }
                }
                current = current.GetNext();
            }

            return newHead;
        }

        //EX2
        public static bool AreComplementary(Node<char> strand1, Node<char> strand2)
        {
            while (strand1 != null && strand2 != null)
            {
                char base1 = strand1.GetValue();
                char base2 = strand2.GetValue();

                if (!IsComplementary(base1, base2))
                {
                    return false;
                }

                strand1 = strand1.GetNext();
                strand2 = strand2.GetNext();
            }

            return strand1 == null && strand2 == null;
        }

        private static bool IsComplementary(char base1, char base2)
        {
            return (base1 == 'A' && base2 == 'T') ||
                   (base1 == 'T' && base2 == 'A') ||
                   (base1 == 'C' && base2 == 'G') ||
                   (base1 == 'G' && base2 == 'C');
        }

        public static Node<char> GetComplementaryStrand(Node<char> strand)
        {
            if (strand == null) return null;

            Node<char> newHead = null;
            Node<char> newTail = null;

            Node<char> current = strand;
            while (current != null)
            {
                char complementaryBase = GetComplementaryBase(current.GetValue());
                Node<char> newNode = new Node<char>(complementaryBase);

                if (newHead == null)
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

        private static char GetComplementaryBase(char baseChar)
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

        //EX3
        // פונקציה ראשית שמקבלת שרשרת ומספר ומוחקת את כל המופעים של המספר מהשרשרת
        public static Node<int> RemoveAllOccurrences(Node<int> head, int value)
        {
            // טיפול במקרה שהמספר נמצא בתחילת השרשרת פעם אחת או יותר
            while (head != null && head.GetValue() == value)
            {
                head = head.GetNext();
            }

            // טיפול במקרה שהמספר נמצא בהמשך השרשרת
            Node<int> current = head;
            while (current != null && current.GetNext() != null)
            {
                if (current.GetNext().GetValue() == value)
                {
                    current.SetNext(current.GetNext().GetNext());
                }
                else
                {
                    current = current.GetNext();
                }
            }

            return head;
        }
        //EX4
        public static int CountCirclesWithCenter(Node<Circle> head, Point p)
        {
            int count = 0;
            Node<Circle> current = head;
            while (current != null)
            {
                Circle circle = current.GetValue();
                if (circle.Center.Equals(p))
                {
                    count++;
                }
                current = current.GetNext();
            }
            return count;
        }
    }
    public class DemoRunHomeWork 
    {
        public static void DemoMain()
        {

            //Lesson2 homework
            Console.WriteLine();
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2, node1);
            Node<int> node3 = new Node<int>(3, node2);
            Node<int> node4 = new Node<int>(4, node3);
            Node<int> node5 = new Node<int>(5, node4);

            Node<int> evenNodeList = NodeTUsageForHomeWORK.FilterEvenValuesMaintainOrder(node5);
            Console.WriteLine("Even Nodes (Maintain Order): " + evenNodeList.ToPrint());

            Console.WriteLine();
            // יצירת גדילי DNA לדוגמה
            Node<char> strand1 = new Node<char>('A');
            strand1.SetNext(new Node<char>('T'));
            strand1.GetNext().SetNext(new Node<char>('C'));
            strand1.GetNext().GetNext().SetNext(new Node<char>('G'));

            Node<char> strand2 = new Node<char>('T');
            strand2.SetNext(new Node<char>('A'));
            strand2.GetNext().SetNext(new Node<char>('G'));
            strand2.GetNext().GetNext().SetNext(new Node<char>('C'));

            // בדיקת תקינות הגדילים
            bool areComplementary = NodeTUsageForHomeWORK.AreComplementary(strand1, strand2);
            Console.WriteLine("Are Complementary: " + areComplementary); 

            // יצירת גדיל תואם לגדיל נתון
            Node<char> complementaryStrand = NodeTUsageForHomeWORK.GetComplementaryStrand(strand1);
            Console.WriteLine("Complementary Strand: " + complementaryStrand.ToPrint());

            Console.WriteLine();

            // יצירת שרשרת לדוגמה
            Node<int> node12 = new Node<int>(8);
            node12.SetNext(new Node<int>(8));
            node12.GetNext().SetNext(new Node<int>(5));
            node12.GetNext().GetNext().SetNext(new Node<int>(8));
            node12.GetNext().GetNext().GetNext().SetNext(new Node<int>(2));
            node12.GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(8));
            node12.GetNext().GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(4));
            node12.GetNext().GetNext().GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(3));
            node12.GetNext().GetNext().GetNext().GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(8));

            Console.WriteLine("Original List: " + node12.ToPrint()); // Output: 8=>8=>5=>8=>2=>8=>4=>3=>8=>null

            // הסרת כל המופעים של המספר 8
            Node<int> newHead = NodeTUsageForHomeWORK.RemoveAllOccurrences(node12, 8);

            Console.WriteLine("Modified List: " + newHead.ToPrint());

            Console.WriteLine();

            Point p = new Point(1, 2);

            // יצירת עיגולים לדוגמה
            Circle c1 = new Circle(new Point(1, 2), 5);
            Circle c2 = new Circle(new Point(3, 4), 7);
            Circle c3 = new Circle(new Point(1, 2), 10);
            Circle c4 = new Circle(new Point(5, 6), 12);

            // יצירת שרשרת חוליות של עיגולים
            Node<Circle> node13 = new Node<Circle>(c1);
            node13.SetNext(new Node<Circle>(c2));
            node13.GetNext().SetNext(new Node<Circle>(c3));
            node13.GetNext().GetNext().SetNext(new Node<Circle>(c4));

            // חישוב מספר העיגולים שמרכזם בנקודה (1, 2)
            int count = NodeTUsageForHomeWORK.CountCirclesWithCenter(node13, p);
            Console.WriteLine("Number of circles with center at " + p + ": " + count);

        }
    }


}

