using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class AverageStudent
    {
        string namee;
        string surnamee;
        string departmentt;
        int number;
        float average;
        Lesson L;



        public string Name
        {
            get
            {
                return namee;
            }

            set
            {
                namee = value;
            }
        }

        public string Surname
        {
            get
            {
                return surnamee;
            }

            set
            {
                surnamee = value;
            }
        }

        public string Department
        {
            get
            {
                return departmentt;
            }

            set
            {
                departmentt = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public float Average
        {
            get
            {
                return average;
            }

            set
            {
                average = value;
            }
        }

        internal Lesson L1
        {
            get
            {
                return L;
            }

            set
            {
                L = value;
            }
        }

        public AverageStudent(string name, string surname, string department, int number, float average, Lesson l)
        {
            this.namee = name;
            this.surnamee = surname;
            this.departmentt = department;
            this.number = number;
            this.average = average;
            L = l;
        }
    }
}
