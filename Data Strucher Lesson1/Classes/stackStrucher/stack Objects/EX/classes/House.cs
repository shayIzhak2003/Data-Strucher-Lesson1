using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.EX.classes
{
    public class House
    {
        public int roomsCount { get; set; }
        public int properti { get; set; }
        public string address { get; set; }
        public bool isForRent { get; set; }

        public House(int roomCount, int properti, string address, bool isForRent)
        {
            this.roomsCount = roomCount;
            this.properti = properti;
            this.address = address;
            this.isForRent = isForRent;
        }


        //EX1
        public string GetBiggerPropertiAddress(House currentHouse)
        {
            string address = "";
            if(currentHouse.properti > this.properti)
            {
                address = currentHouse.address;
            }
            else
            {
                address =  this.address;
            }
            return address;
        }
        public override string ToString()
        {
            return $"Address: {this.address}, Rooms: {this.roomsCount}, Size: {this.properti} sqm, For Rent: {(this.isForRent ? "Yes" : "No")}";
        }
    }
}
