using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Queue.campusIL_Course.Queue_Objects.Cinima_App
{
    public class Cinema
    {
        private Queue<string>[] halls;

        // מייצר בית קולנוע ריק, עם 10 תורים ריקים 
        public Cinema()
        {
            this.halls = new Queue<string>[10];

            for (int i = 0; i < this.halls.Length; i++)
                this.halls[i] = new Queue<string>(); // אולם חדש וריק
        }
        public bool IsEmpty()
        {
            for (int i = 0; i < this.halls.Length; i++)
            {
                if (!this.halls[i].IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }
        public void Insert(string id, int standPoint)
        {
            if (standPoint <= 0 && standPoint > 10)  // אם מספר העמדה לא תקין -> נסיים
                return;

            Queue<string> tmp = new Queue<string>();  // תור עזר
            bool found = false;

            while (!this.halls[standPoint - 1].IsEmpty())
            {
                found = this.halls[standPoint - 1].Head() == id;
                tmp.Insert(this.halls[standPoint - 1].Remove());
            }
            while (!tmp.IsEmpty())
            {
                this.halls[standPoint - 1].Insert(tmp.Remove());
            }
            if (!found)
            {
                this.halls[standPoint - 1].Insert(id);
            }
        }
        public string Remove(int standPoint)
        {
            if (standPoint <= 0 && standPoint > 10)  // אם מספר העמדה לא תקין -> נחזיר מחרוזת שגיאה
                return "Error standPoint";

            //   הוא 1-10, אבל המספר של האולם במערך הוא  0-9 standPoint מספר האולם
            Queue<string> q = this.halls[standPoint - 1];
            // הנחה: העמדה איננה ריקה
            return q.Remove();


        }
        public string Head(int standPoint)
        {
            if (standPoint <= 0 && standPoint > 10)  // אם מספר העמדה לא תקין -> נחזיר מחרוזת שגיאה
                return "Error standPoint";

            // מספר האולם  standPoint הוא 1-10,   אבל המספר של האולם במערך הוא 0-9
            Queue<string> q = this.halls[standPoint - 1];
            // הנחה: העמדה איננה ריקה
            return q.Head();

        }
        public override string ToString()
        {

            string strCinema = "";
            Queue<string> tmp = new Queue<string>();

            for (int i = 0; i < this.halls.Length; i++)
            {
                // נשרשר למחרוזת תיאור הקולנוע את התור הנוכחי עם כל העומדים בתור
                Queue<string> q = this.halls[i];
                strCinema += "Stand point #" + (i + 1) + " <- ";
                while (!q.IsEmpty())
                {
                    strCinema += q.Head() + " , ";
                    tmp.Insert(q.Remove());
                }
                strCinema += " <- \n";
                // נחזיר את התור הנוכחי למצבו הקודם
                while (!tmp.IsEmpty())
                    q.Insert(tmp.Remove());
            }

            return strCinema;
        }
    }
}
