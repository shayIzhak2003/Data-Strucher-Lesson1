using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Lesson2
{
    public class Train
    {
        private Locomotive locomotive;
        private Stack<Carriage> carriages;

        public Train(Locomotive locomotive)
        {
            this.locomotive = locomotive;
            carriages = new Stack<Carriage>();
        }

        public void AttachCarriage(Carriage carriage)
        {
            carriages.Push(carriage);
        }

        public Carriage DetachCarriage(int serialNumber)
        {
            Stack<Carriage> tempStack = new Stack<Carriage>();
            Carriage removedCarriage = null;

            while (!carriages.IsEmpty())
            {
                Carriage currentCarriage = carriages.Pop();
                if (currentCarriage.GetSerialNumber() == serialNumber)
                {
                    removedCarriage = currentCarriage;
                    break;
                }
                else
                {
                    tempStack.Push(currentCarriage);
                }
            }

            // Restore the stack
            while (!tempStack.IsEmpty())
            {
                carriages.Push(tempStack.Pop());
            }

            return removedCarriage;
        }

        public Train ReduceCarriages(Locomotive newLocomotive)
        {
            Train newTrain = new Train(newLocomotive);
            Stack<Carriage> tempStack = new Stack<Carriage>();

            while (!carriages.IsEmpty())
            {
                Carriage currentCarriage = carriages.Pop();

                while (!tempStack.IsEmpty() && currentCarriage.GetNumberOfPassengers() > 0)
                {
                    Carriage nextCarriage = tempStack.Pop();
                    int availableSpace = Carriage.GetMaxPassengers() - nextCarriage.GetNumberOfPassengers();
                    int passengersToMove = Math.Min(availableSpace, currentCarriage.GetNumberOfPassengers());
                    nextCarriage.SetNumberOfPassengers(nextCarriage.GetNumberOfPassengers() + passengersToMove);
                    currentCarriage.SetNumberOfPassengers(currentCarriage.GetNumberOfPassengers() - passengersToMove);

                    
                    if (nextCarriage.GetNumberOfPassengers() == Carriage.GetMaxPassengers() || currentCarriage.GetNumberOfPassengers() == 0)
                    {
                        newTrain.AttachCarriage(nextCarriage);
                    }
                    else
                    {
                        tempStack.Push(nextCarriage);
                    }
                }

               
                if (currentCarriage.GetNumberOfPassengers() > 0)
                {
                    newTrain.AttachCarriage(currentCarriage);
                }
            }

            while (!tempStack.IsEmpty())
            {
                newTrain.AttachCarriage(tempStack.Pop());
            }

            return newTrain;
        }



        public override string ToString()
        {
            string trainInfo = locomotive.ToString() + "\n";
            trainInfo += "Carriages:\n";

            Stack<Carriage> tempStack = new Stack<Carriage>();

            while (!carriages.IsEmpty())
            {
                Carriage carriage = carriages.Pop();
                trainInfo += carriage.ToString() + "\n";
                tempStack.Push(carriage);  // Preserve the original stack
            }

            // Restore the original stack
            while (!tempStack.IsEmpty())
            {
                carriages.Push(tempStack.Pop());
            }

            return trainInfo;
        }
    }
}
