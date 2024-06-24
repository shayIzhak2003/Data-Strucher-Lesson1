using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson5
{
    // מחלקה המייצגת טווח ימים
    public class DayRange
    {
        private int from;
        private int to;

        public int GetFrom()
        {
            return this.from;
        }
        public int GetTo()
        {
            return this.to;
        }
        public DayRange(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public override string ToString()
        {
            return $"({from}, {to})";
        }
    }

    // מחלקה למציאת ימי גשם לא תואמים
    public class RainfallMismatch
    {
        // פונקציה למציאת והדפסת ימי גשם לא תואמים
        public void FindMismatchedDays(bool[] rainfallArray, Node<DayRange> rainDaysList)
        {
            bool[] daysWithRainInList = new bool[30];

            // מעבר על הרשימה המקושרת לסימון הימים עם גשם
            Node<DayRange> current = rainDaysList;
            while (current != null)
            {
                DayRange range = current.GetValue();
                for (int day = range.GetFrom(); day <= range.GetTo(); day++)
                {
                    if (day >= 1 && day <= 30) // בדיקת תקינות הטווח
                        daysWithRainInList[day - 1] = true; // המרה לאינדקס מבוסס 0
                }
                current = current.GetNext();
            }

            // בדיקת אי התאמות והדפסתן
            for (int i = 1; i <= 30; i++) // ימי 1 עד 30 (לא כולל 0)
            {
                bool expectedRain = rainfallArray[i]; // שימוש באינדקס מבוסס 1
                bool actualRain = daysWithRainInList[i - 1]; // המרה לאינדקס מבוסס 0
                if (expectedRain != actualRain)
                {
                    Console.WriteLine($"Mismatch on day {i}");
                }
            }
        }
    }

    public class RunRainfallMismatch
    {
        public static void DemoMainForReal()
        {
            // יצירת מערך המייצג ימי גשם בחודש (האינדקס ה-0 אינו בשימוש, ימים מ-1 עד 30)
            bool[] rainfallArray = new bool[31];
            rainfallArray[1] = false;
            rainfallArray[2] = true;
            rainfallArray[3] = true;
            rainfallArray[4] = false;
            rainfallArray[5] = false;
            rainfallArray[6] = true;
            rainfallArray[7] = false;
            // הוספת עוד ערכים בהתאם לצורך

            // הוספת הדפסות לבדיקה
            Console.WriteLine("Rainfall Array: ");
            for (int i = 1; i <= 30; i++)
            {
                Console.WriteLine($"Day {i}: {(rainfallArray[i] ? "Rain" : "No Rain")}");
            }

            // יצירת רשימה מקושרת של DayRange
            Node<DayRange> head = new Node<DayRange>(new DayRange(2, 3));
            Node<DayRange> node2 = new Node<DayRange>(new DayRange(6, 6));
            head.SetNext(node2);

            // הוספת הדפסות לבדיקה
            Console.WriteLine("Day Ranges:");
            Node<DayRange> current = head;
            while (current != null)
            {
                Console.WriteLine(current.GetValue());
                current = current.GetNext();
            }

            // יצירת אובייקט של RainfallMismatch
            RainfallMismatch rainfallMismatch = new RainfallMismatch();

            // מציאת והדפסת ימי גשם לא תואמים
            rainfallMismatch.FindMismatchedDays(rainfallArray, head);
        }
    }

}
