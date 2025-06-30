using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Guy
{
    public class NodeExGuy
    {
       // count all Nodes in the list 
       public static int countNodes<T>(Node<T> lst)
        {
            int count = 0;
            while (lst != null)
            {
                count++;
                lst = lst.GetNext();
            }
            return count; 
        }

        public static int SumNodes(Node<int> lst)
        {
            Node<int> pos = lst;
            int sum = 0;
            while (pos != null)
            {
                sum += pos.GetValue();
                pos = pos.GetNext();
            }
            return sum;
        }

        // find min value node function
        public static Node<int> MinNode(Node<int> lst)
        {
            Node<int> pos = lst;
            int min = pos.GetValue();
            Node<int> minP = pos.GetNext();
            while (pos != null)
            {
                int currentValue = pos.GetValue();
                if(currentValue < min)
                {
                    min = currentValue;
                    minP = pos;
                }
                    

                pos = pos.GetNext();
            }
            return minP;
        }
        // 
        public static Node<int> AfterSteps(Node<int> lst, int steps, int x)
        {
            if (lst == null || steps < 0)
                return lst;

            Node<int> pos = lst;
            int count = 0;
            while (pos != null)
            {
                count++;
                if (count == steps)
                {
                    Node<int> newValue = new Node<int>(x); // זוהי הדרך להוספת חוליה (תמיד!!)
                    newValue.SetNext(pos.GetNext());
                    pos.SetNext(newValue);
                }
                
                pos = pos.GetNext();
            }
            return lst;
        }
        public static Node<int> Merge(Node<int> lst1, Node<int> lst2)
        {
            Node<int> dummyHead = new Node<int>(0); // צומת התחלה מזויף
            Node<int> pos = dummyHead;

            // כל עוד יש ערכים בשתי הרשימות
            while (lst1 != null && lst2 != null)
            {
                if (lst1.GetValue() <= lst2.GetValue())
                {
                    pos.SetNext(new Node<int>(lst1.GetValue())); 
                    lst1 = lst1.GetNext();
                }
                else
                {
                    pos.SetNext(new Node<int>(lst2.GetValue()));
                    lst2 = lst2.GetNext();
                }

                pos = pos.GetNext(); 
            }

           
            while (lst1 != null)
            {
                pos.SetNext(new Node<int>(lst1.GetValue()));
                lst1 = lst1.GetNext();
                pos = pos.GetNext();
            }

            while (lst2 != null)
            {
                pos.SetNext(new Node<int>(lst2.GetValue()));
                lst2 = lst2.GetNext();
                pos = pos.GetNext();
            }

            return dummyHead.GetNext(); // מחזיר את הראש האמיתי של הרשימה
        }

        public static Node<int> DeleteAfter(Node<int> lst, Node<int> prev)
        {
            if (lst == null)
                return null;

            if (prev == null)
            {
                // מוחק את הראש של הרשימה
                return lst.GetNext();
            }

            if (prev.GetNext() != null) // הערך שצריך למחוק
            {
                // דילוג על הצומת הבא (כלומר מחיקה)
                prev.SetNext(prev.GetNext().GetNext()); // צורת מחיקה
            }

            return lst;
        }

        public static void VirtualMain()
        {
            Node<int> node5 = new Node<int>(5);
            Node<int> node4 = new Node<int>(4, node5);
            Node<int> node3 = new Node<int>(3, node4);
            Node<int> node2 = new Node<int>(2, node3);
            Node<int> node1 = new Node<int>(1, node2);
            // lst1 = 1 → 2 → 3 → 4 → 5

            Node<int> node6 = new Node<int>(6);
            Node<int> node7 = new Node<int>(7, node6);
            Node<int> node8 = new Node<int>(8, node7);
            Node<int> node9 = new Node<int>(9, node8);
            Node<int> node10 = new Node<int>(10, node9);
            // lst2 = 10 → 9 → 8 → 7 → 6 ❌ הפוך!

            // פתרון: נבנה אותה כמו את הראשונה – מהקטן לגדול
            Node<int> n6 = new Node<int>(10);
            Node<int> n5 = new Node<int>(9, n6);
            Node<int> n4 = new Node<int>(8, n5);
            Node<int> n3 = new Node<int>(7, n4);
            Node<int> n2 = new Node<int>(6, n3);
            // lst2 = 6 → 7 → 8 → 9 → 10 ✅

            Node<int> merged = Merge(node1, n2);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(merged.ToPrint());// תדפיס את הרשימה הממוזגת בסדר עולה

        }
    }
}
