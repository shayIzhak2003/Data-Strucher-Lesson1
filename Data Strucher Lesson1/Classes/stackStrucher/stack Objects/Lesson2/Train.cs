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

                
                while (currentCarriage.GetNumberOfPassengers() > 0)
                {
                    Carriage nextCarriage;

                    if (tempStack.IsEmpty() || tempStack.Top().GetNumberOfPassengers() == Carriage.GetMaxPassengers())
                    {
                        
                        nextCarriage = new Carriage(currentCarriage.GetSerialNumber(), 0);
                        tempStack.Push(nextCarriage);

                       
                        if (!tempStack.IsEmpty())
                        {
                            nextCarriage.SetSerialNumber(tempStack.Top().GetSerialNumber() + 1);
                        }
                    }
                    else
                    {
                        nextCarriage = tempStack.Top();
                    }

                    int availableSpace = Carriage.GetMaxPassengers() - nextCarriage.GetNumberOfPassengers();
                    int passengersToMove = Math.Min(availableSpace, currentCarriage.GetNumberOfPassengers());
                    nextCarriage.SetNumberOfPassengers(nextCarriage.GetNumberOfPassengers() + passengersToMove);
                    currentCarriage.SetNumberOfPassengers(currentCarriage.GetNumberOfPassengers() - passengersToMove);

                    
                    if (nextCarriage.GetNumberOfPassengers() == Carriage.GetMaxPassengers())
                    {
                        newTrain.AttachCarriage(tempStack.Pop());
                    }
                }

               
                if (currentCarriage.GetNumberOfPassengers() > 0)
                {
                    tempStack.Push(currentCarriage);
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
                tempStack.Push(carriage);  
            }

           
            while (!tempStack.IsEmpty())
            {
                carriages.Push(tempStack.Pop());
            }

            return trainInfo;
        }
    }
}
