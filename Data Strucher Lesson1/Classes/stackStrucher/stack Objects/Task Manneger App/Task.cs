using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Task_Manneger_App
{
    public class Task
    {
        private string content;
        private int code;


        public Task(string content, int code)
        {
            this.content = content;
            this.code = code;
        }

        public override string ToString()
        {
            return $"content = {this.content}, code = {this.code}";
        }

        public void SetContent(string cont)
        {
            this.content = cont;
        }
        public void SetCode(int code)
        {
            this.code = code;
        }

        public int GetCode()
        {
            return this.code;
        }
        public string GetContent()
        {
            return this.content;
        }
    }
}
