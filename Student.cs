using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Student
    {
        string name;
        string surname;
        string department;
        int number;
        Lesson L;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
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

        public Student(string name, string surname, string department,int no, Lesson l)
        {
            this.Name = name;
            this.Surname = surname;
            this.Department = department;
            this.Number = no;
            L1 = l;
        }
    }
}
