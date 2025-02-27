using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX10
{
    public class SpeedCamera
    {
        private int cameraID;         // Unique ID for the speed camera
        private int location;         // Location ID
        private int speedLimit;       // Maximum allowed speed
        private Stack<int> violations; // Stack of car speeds exceeding the limit

        //Getters
        //pt.1
        public int GetCameraID() => this.cameraID;
        public int GetLocation() => this.location;
        public int GetSpeedLimit() => this.speedLimit;
        public Stack<int> GetViolationsStack()
        {
            Stack<int> stack = new Stack<int>();
            Stack<int> clone = new Stack<int>();

            while (!this.violations.IsEmpty())
            {
                stack.Push(this.violations.Pop());
            }
            while (!stack.IsEmpty())
            {
                this.violations.Push(stack.Pop());
                clone.Push(stack.Pop());
            }
            return clone;
        }


        //pt.2
        public void AddCar(int carSpeed, int carNum)
        {
            if (carSpeed > this.speedLimit)
            {
                violations.Push(carNum);
            }
        }

        public int GetVauletionsNum()
        {
            int count = 0;
            Stack<int> temp = new Stack<int>();
            while (!this.violations.IsEmpty())
            {
                temp.Push(this.violations.Pop());
                count++;
            }

            while(!temp.IsEmpty())
                this.violations.Push(temp.Pop());

            return count;
        }
    }
}
