using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Task_Manneger_App
{
    public class TaskManagement
    {
        private Stack<Task> tasks;
        public TaskManagement()
        {
            tasks = new Stack<Task>();
        }
        private void AddTaskWithUrgency(Task ts, int urg)
        {
            Stack<Task> temp = new Stack<Task>();
            while (!tasks.IsEmpty() && (tasks.Top()).GetCode() <= urg)
                temp.Push(tasks.Pop());
            tasks.Push(ts);
            while (!temp.IsEmpty())
                tasks.Push(temp.Pop());
        }
        public void AddTask(Task ts)
        {
            int urgency = ts.GetCode();
            AddTaskWithUrgency(ts, urgency);
        }
        public Task RemoveTask()
        {
            Task ts = tasks.Pop();
            return ts;
        }
        public override string ToString()
        {
            string taskMannegmantReivew = "";
            Stack<Task> temp = new Stack<Task>();
            while (!this.tasks.IsEmpty())
            {
                Task currentTask = this.tasks.Pop();
                temp.Push(currentTask);
                taskMannegmantReivew += "\n" + currentTask;
            }
            while (!temp.IsEmpty())
            {
                Task task = temp.Pop();
                this.tasks.Push(task);
            }
            return  taskMannegmantReivew;
        }
    }
}
