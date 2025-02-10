using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024.Summer_mohed_A.EX11
{
    public class RunStudentsApp
    {
        public static void DemoMain()
        {

            // יצירת מאגר סטודנטים
            StudentsData studentsData = new StudentsData();

            // הוספת סטודנטים למאגר
            studentsData.AddStudent(new Student("123456789", "David Cohen", "Tel Aviv", true, "Hebrew", "English"));
            studentsData.AddStudent(new Student("987654321", "Sara Levi", "Jerusalem", false, "Hebrew", "French"));
            studentsData.AddStudent(new Student("567891234", "Michael Rosen", "Haifa", true, "Russian", "English"));
            studentsData.AddStudent(new Student("112233445", "Lea Bar", "Tel Aviv", false, "Hebrew", "Spanish"));
            studentsData.AddStudent(new Student("556677889", "Noam Katz", "Jerusalem", true, "Hebrew", "Arabic"));

            Console.WriteLine("");
            Console.WriteLine("the students data base:");
            studentsData.PrintAllStudents();
            Console.WriteLine();
            // הדפסת מספר הסטודנטים בעיר מסוימת
            string cityToCheck = "Jerusalem";
            Console.WriteLine($"Number of students in {cityToCheck}: {studentsData.NumStudents(cityToCheck)}");

            // הדפסת סטודנטים לפי עיר ושפה נוספת
            string searchCity = "Tel Aviv";
            string searchLanguage = "Spanish";
            Console.WriteLine($"\nStudents in {searchCity} who speak {searchLanguage}:");
            studentsData.Print(searchCity, searchLanguage);
            // מחיקת סטודנט מהמאגר לפי מספר זהות
            string studentToRemove = "123456789";
            Console.WriteLine($"\nRemoving student with ID: {studentToRemove}");
            studentsData.EraseStudent(studentToRemove);

            // הצגת הסטודנטים לאחר המחיקה
            Console.WriteLine("\nRemaining students:");
            studentsData.PrintAllStudents();


            // מציאת העיר עם הכי הרבה סטודנטים
            string[] cities = { "Tel Aviv", "Jerusalem", "Haifa" };
            string mostStudentsCity = studentsData.CityName(cities);
            Console.WriteLine($"\nCity with the most students: {mostStudentsCity}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
