using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024.Summer_mohed_A.EX11
{
    public class Student
    {
        private string id;         // מספר תעודת זהות של הסטודנט
        private string name;       // שם הסטודנט
        private string city;       // יישוב מגורים
        private bool hasCar;       // האם יש לסטודנט רכב
        private string motherTongue; // שפת אם
        private string additionalLanguage; // שפה נוספת שהסטודנט שולט בה היטב

        /// <summary>
        /// בנאי המאתחל את פרטי הסטודנט
        /// </summary>
        public Student(string id, string name, string city, bool hasCar, string motherTongue, string additionalLanguage)
        {
            this.id = id;
            this.name = name;
            this.city = city;
            this.hasCar = hasCar;
            this.motherTongue = motherTongue;
            this.additionalLanguage = additionalLanguage;
        }

        // פעולות Get ו-Set לכל תכונה
        public string GetId() => id;
        public void SetId(string id) => this.id = id;

        public string GetName() => name;
        public void SetName(string name) => this.name = name;

        public string GetCity() => city;
        public void SetCity(string city) => this.city = city;

        public bool HasCar() => hasCar;
        public void SetHasCar(bool hasCar) => this.hasCar = hasCar;

        public string GetMotherTongue() => motherTongue;
        public void SetMotherTongue(string motherTongue) => this.motherTongue = motherTongue;

        public string GetAdditionalLanguage() => additionalLanguage;
        public void SetAdditionalLanguage(string additionalLanguage) => this.additionalLanguage = additionalLanguage;

        /// <summary>
        /// פעולה שמחזירה מחרוזת עם פרטי הסטודנט
        /// </summary>
        public override string ToString()
        {
            return $"ID: {this.id}, Name: {this.name}, City: {this.city}, Has Car: {this.hasCar}, Mother Tongue: {this.motherTongue}, Additional Language: {this.additionalLanguage}";
        }
    }
}
