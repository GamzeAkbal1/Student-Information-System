using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Lesson
    {
        string lName1;
        string lName2;
        string lName3;
        int grade1;
        int grade2;
        int grade3;

        public string LName1
        {
            get
            {
                return lName1;
            }

            set
            {
                lName1 = value;
            }
        }

        public string LName2
        {
            get
            {
                return lName2;
            }

            set
            {
                lName2 = value;
            }
        }

        public string LName3
        {
            get
            {
                return lName3;
            }

            set
            {
                lName3 = value;
            }
        }

        public int Grade1
        {
            get
            {
                return grade1;
            }

            set
            {
                grade1 = value;
            }
        }

        public int Grade2
        {
            get
            {
                return grade2;
            }

            set
            {
                grade2 = value;
            }
        }

        public int Grade3
        {
            get
            {
                return grade3;
            }

            set
            {
                grade3 = value;
            }
        }

        public Lesson(string lName1, string lName2, string lName3, int grade1, int grade2, int grade3)
        {
            this.LName1 = lName1;
            this.LName2 = lName2;
            this.LName3 = lName3;
            this.Grade1 = grade1;
            this.Grade2 = grade2;
            this.Grade3 = grade3;
        }
    }
}
