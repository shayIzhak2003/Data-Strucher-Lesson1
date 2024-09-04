using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Task_Manneger_App
{
    public class RunTaskMannegerApp
    {
        public static void DemoMain()
        {
            TaskManagement ts = new TaskManagement();
            Task t1 = new Task("Easy", 3);
            ts.AddTask(t1);
            Task t2 = new Task("Urgent", 1);
            ts.AddTask(t2);
            Task t3 = new Task("Fifty/fifty", 2);
            ts.AddTask(t3);
            Console.WriteLine(ts);
            ts.ToString();
        }
    }
}
