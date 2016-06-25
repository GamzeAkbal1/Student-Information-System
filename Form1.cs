using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List <Lesson> LessonsArray = new List <Lesson>(); 
        List<Student> StudentList = new List<Student>();
        List<AverageStudent> AverageStudentList = new List<AverageStudent>();
        List<float> TopGrades = new List<float>();
        
       
        public Form1()
        {
            InitializeComponent();
        }
        private void AddStudent()
        {
            try
            {
                Lesson L = new Lesson(textBoxL1.Text, textBoxL2.Text, textBoxL3.Text, Convert.ToInt32(textBoxG1.Text), Convert.ToInt32(textBoxG2.Text), Convert.ToInt32(textBoxG3.Text));
                Student st = new Student(textBoxName.Text.ToUpper(), textBoxSurname.Text.ToUpper(), textBoxDep.Text.ToUpper(),Convert.ToInt32(textBoxNo.Text), L);
                StudentList.Add(st);
                

                MessageBox.Show("Success!");
                
            }
            catch 
            {
                ClearAllBoxes();
                MessageBox.Show("Error Please attention to the number of inputs");
                
            }
            
            
            
        } 
        private void AddLesson()
        {
            
                if (listBox1.SelectedItems.Count == 3)
                {
                    textBoxL1.Text = listBox1.SelectedItems[0].ToString();
                    textBoxL2.Text = listBox1.SelectedItems[1].ToString();
                    textBoxL3.Text = listBox1.SelectedItems[2].ToString();
                    DeleteSelectedLessons();
                    ReverseLessonButton.Enabled = true;
                    textBoxG1.ReadOnly = false;
                    textBoxG2.ReadOnly = false;
                    textBoxG3.ReadOnly = false;
                }

            
           else
            {

                MessageBox.Show("Please Chose 3 Lessons!");
            }
        }
        private void DeleteSelectedLessons()
        {
            for (int i = 0; i < 3; i++)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }

        }
        private void ReLoadSelectedLessons()
        {
            if (textBoxL1.Text != "")
            {
                listBox1.Items.Add(textBoxL1.Text);
                listBox1.Items.Add(textBoxL2.Text);
                listBox1.Items.Add(textBoxL3.Text);
                ReverseLessonButton.Enabled = false;
               
                textBoxG1.ReadOnly = true;
                textBoxG2.ReadOnly = true;
                textBoxG3.ReadOnly = true;

            }
            else
                MessageBox.Show("You must add lesson before you delete !");
            
        }
        private void ClearBoxes()
        {
            textBoxL1.Clear();
            textBoxL2.Clear();
            textBoxL3.Clear();
        } 
        private void ClearAllBoxes()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.Clear();
                }
            }
        }
        private void SearchLesson()
        {
            int countLessonStudent = 0;
            for (int i = 0; i < StudentList.Count(); i++)
            {
                if (StudentList[i].L1.LName1 == comboBox1.SelectedItem.ToString())
                {
                    countLessonStudent++;
                }
                else if (StudentList[i].L1.LName2 == comboBox1.SelectedItem.ToString())
                {
                    countLessonStudent++;
                }
                else if (StudentList[i].L1.LName3 == comboBox1.SelectedItem.ToString())
                {
                    countLessonStudent++;
                }

            }
            labelCountSt.Visible = true;
            labelCountSt.Text = "Number of people taking the course " + " "+countLessonStudent;


        } 
        private int SearchLessonR() 
        {
            int countLessonStudent = 0;
            for (int i = 0; i < StudentList.Count(); i++)
            {
                if (StudentList[i].L1.LName1 == comboBox1.SelectedItem.ToString())
                {
                    countLessonStudent++;
                }
                else if (StudentList[i].L1.LName2 == comboBox1.SelectedItem.ToString())
                {
                    countLessonStudent++;
                }
                else if (StudentList[i].L1.LName3 == comboBox1.SelectedItem.ToString())
                {
                    countLessonStudent++;
                }

            }
            
            return countLessonStudent;

        }
        private void FindLessonAverage()
        {
            if (SearchLessonR() != 0)
            {
                float average;
                int sum = 0, count = 0;
                for (int i = 0; i < StudentList.Count; i++)
                {
                    if (StudentList[i].L1.LName1 == comboBox1.SelectedItem.ToString())
                    {
                        sum += StudentList[i].L1.Grade1;
                        count++;
                    }
                    else if (StudentList[i].L1.LName2 == comboBox1.SelectedItem.ToString())
                    {
                        sum += StudentList[i].L1.Grade2;
                        count++;
                    }
                    else if (StudentList[i].L1.LName3 == comboBox1.SelectedItem.ToString())
                    {
                        sum += StudentList[i].L1.Grade3;
                        count++;
                    }

                }
                average = (float)sum / count;
                label1.Visible = true;
                label1.Text = "Average of Lesson" + " " + average;

            }
            else
            {
                label1.Visible = true;
                label1.Text = "Average of Lesson" + " " + "0";
            }

        }
        private void FindLower60()
        {
            listBox2.Items.Clear();
            listBox2.Visible = true;
            label13.Visible = true;
            for (int i = 0; i < StudentList.Count(); i++)
            {
                if (StudentList[i].L1.LName1 == comboBox1.SelectedItem.ToString())
                {
                    if (StudentList[i].L1.Grade1 < 60)
                    {
                        listBox2.Items.Add(StudentList[i].L1.Grade1 +"\t "+ StudentList[i].Number +"\t"+ StudentList[i].Name+"\t"+StudentList[i].Surname);
                    }
                }
                else if (StudentList[i].L1.LName2 == comboBox1.SelectedItem.ToString())
                {
                    if (StudentList[i].L1.Grade2 < 60)
                    {
                        listBox2.Items.Add(StudentList[i].L1.Grade2 +"\t "+ StudentList[i].Number +" \t"+ StudentList[i].Name+"\t" + StudentList[i].Surname);
                    }
                    
                }
                else if (StudentList[i].L1.LName3 == comboBox1.SelectedItem.ToString())
                {
                    if (StudentList[i].L1.Grade3 < 60)
                    {
                        listBox2.Items.Add(StudentList[i].L1.Grade3 +"\t "+ StudentList[i].Number +"\t "+ StudentList[i].Name+ "\t" + StudentList[i].Surname);
                    }
                }

            }
            

        } 
        private float FindMaxGrade(object lst)
        {
            float max1 = 0;

            for (int i = 0; i < StudentList.Count; i++)
            {
                if (StudentList[i].L1.LName1 == lst.ToString())
                {
                    if (StudentList[i].L1.Grade1 >= max1)
                        max1 = StudentList[i].L1.Grade1;
                }
                else if (StudentList[i].L1.LName2 == lst.ToString())
                {
                    if (StudentList[i].L1.Grade2 >= max1)
                        max1 = StudentList[i].L1.Grade2;
                }
                else if (StudentList[i].L1.LName3 == lst.ToString())
                {
                    if (StudentList[i].L1.Grade3 >= max1)
                        max1 = StudentList[i].L1.Grade3;
                }
            }
            return max1;
        }
        private void ClearTopGradesListBox()
        {
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
        }
        private void GetTopGrades()
        {
            ClearTopGradesListBox();

            for (int i = 0; i <listBox3.Items.Count  ; i++)
            {
                
                if (i == 0)
                    HowManyTopGrade(listBox3.Items[i], listBox4, FindMaxGrade(listBox3.Items[i]));
                else if (i == 1)
                    HowManyTopGrade(listBox3.Items[i], listBox5, FindMaxGrade(listBox3.Items[i]));
                else if (i == 2)
                    HowManyTopGrade(listBox3.Items[i], listBox6, FindMaxGrade(listBox3.Items[i]));
                else if (i == 3)
                    HowManyTopGrade(listBox3.Items[i], listBox7, FindMaxGrade(listBox3.Items[i]));
                else if (i == 4)
                    HowManyTopGrade(listBox3.Items[i], listBox8, FindMaxGrade(listBox3.Items[i]));
                else
                    MessageBox.Show("Error!");

            }
        }
        private void DoVisible()
        {
            listBox3.Visible = true;
            listBox4.Visible = true;
            listBox5.Visible = true;
            listBox6.Visible = true;
            listBox7.Visible = true;
            listBox8.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;

        }
        private void HowManyTopGrade(object lst,ListBox lb,float max1)
        {
            for (int i = 0; i < StudentList.Count; i++)
            {
                if (StudentList[i].L1.LName1 == lst.ToString())
                {
                    if (StudentList[i].L1.Grade1 == max1)
                    {
                        lb.Items.Add(max1);
                    }

                }
                else if (StudentList[i].L1.LName2 ==lst.ToString())
                {
                    if (StudentList[i].L1.Grade2 == max1)
                    {
                        lb.Items.Add(max1);
                    }

                }
                else if (StudentList[i].L1.LName3 == lst.ToString())
                {
                    if (StudentList[i].L1.Grade3 == max1)
                    {
                        lb.Items.Add(max1);
                    }

                }
            }
        }
        private void AddAverage()
        {
            float average = 0;
            average = (float)(Convert.ToInt32(textBoxG1.Text)+ Convert.ToInt32(textBoxG2.Text)+ Convert.ToInt32(textBoxG3.Text)) / 3;
            Lesson L2 = new Lesson(textBoxL1.Text, textBoxL2.Text, textBoxL3.Text, Convert.ToInt32(textBoxG1.Text), Convert.ToInt32(textBoxG2.Text), Convert.ToInt32(textBoxG3.Text));
            AverageStudent avst = new AverageStudent(textBoxName.Text.ToUpper(), textBoxSurname.Text.ToUpper(), textBoxDep.Text.ToUpper(), Convert.ToInt32(textBoxNo.Text),average,L2);
            AverageStudentList.Add(avst);
            ClearAllBoxes();
           
        }
        private void SortGrades()
        {
            AverageStudent temp;
            for (int i = 0; i < AverageStudentList.Count; i++)

            {

                for (int j = i + 1; j < AverageStudentList.Count; j++)

                {

                    if (AverageStudentList[j].Average < AverageStudentList[i].Average)

                    {

                        temp = AverageStudentList[i];

                        AverageStudentList[i] = AverageStudentList[j];

                        AverageStudentList[j] = temp;

                    }

                }

            }

            
        }
        private void AddListboxSortedGrades()
        {
            listBox9.Items.Clear();
            for (int i = 0; i < AverageStudentList.Count; i++)
            {
                listBox9.Items.Add(AverageStudentList[i].Number + "\t\t" + AverageStudentList[i].Name + "\t\t" + AverageStudentList[i].Surname + "\t\t"+AverageStudentList[i].L1.Grade1 + "\t\t" + AverageStudentList[i].L1.Grade2 + "\t\t" + AverageStudentList[i].L1.Grade3+"\t\t"+"Ortalama >>"+AverageStudentList[i].Average+"\t\t");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

       
        private void button1_Click(object sender, EventArgs e)
        {

            AddLesson();     
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ReLoadSelectedLessons();
            ClearBoxes();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReLoadSelectedLessons();
            AddStudent();
            AddAverage();
        }

       

        private void textBoxG1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;
            }

        }
      

        private void buttonSearchL_Click(object sender, EventArgs e)
        {
            SearchLesson();
            FindLessonAverage();
            FindLower60();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetTopGrades();
            DoVisible();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            SortGrades();
            AddListboxSortedGrades();

        }

        private void SearchFromName_Click(object sender, EventArgs e)
        {
            listBox10.Items.Clear();
            listBox10.Visible = true;
            for (int i = 0; i < AverageStudentList.Count; i++)
            {
                if (AverageStudentList[i].Name == textBoxNS.Text.ToUpper() && AverageStudentList[i].Surname==textBoxNSS.Text.ToUpper())
                    listBox10.Items.Add(AverageStudentList[i].L1.LName1 + "\t\t" + AverageStudentList[i].L1.Grade1 + "\t\t" + AverageStudentList[i].L1.LName2 + "\t\t" + AverageStudentList[i].L1.Grade2 + "\t\t" + AverageStudentList[i].L1.LName3 + "\t\t" + AverageStudentList[i].L1.Grade3 + "\t\t" + "Ortalama>>"+AverageStudentList[i].Average+"\t\t");
            }
        } //ada gore ogrenci arama

        private void button7_Click(object sender, EventArgs e)
        {
            listBox11.Items.Clear();
            listBox11.Visible = true;
            for (int i = 0; i < AverageStudentList.Count; i++)
            {
                if(AverageStudentList[i].Number==Convert.ToInt32(textBoxNoS.Text))
                    listBox11.Items.Add(AverageStudentList[i].L1.LName1 + "\t\t" + AverageStudentList[i].L1.Grade1 + "\t\t" + AverageStudentList[i].L1.LName2 + "\t\t" + AverageStudentList[i].L1.Grade2 + "\t\t" + AverageStudentList[i].L1.LName3 + "\t\t" + AverageStudentList[i].L1.Grade3 + "\t\t" + "Ortalama>>" + AverageStudentList[i].Average+"\t\t");
            }
        }//numaraya gore Ogrenci arama

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox12.Items.Clear();
            listBox12.Visible = true;
            int count = 0;
            float sum = 0;
            float depAvg = 0;
            for (int i = 0; i < AverageStudentList.Count; i++)
            {
                if (AverageStudentList[i].Department == textBox1.Text.ToUpper())
                {
                    count++;
                    sum += AverageStudentList[i].Average;
                }
            }
            depAvg = sum / count;
            listBox12.Items.Add("Number of peaople in the department >> " + count + "\t\t" + "Average of Department >> " + depAvg);
        }//bolume ait kişi sayisi ve bölümün ortalaması

        private void textBoxG1_Leave(object sender, EventArgs e)
        {
            if (textBoxG1.Text != "") 
            {
                try
                {
                    if (Convert.ToInt32(textBoxG1.Text) < 0 || Convert.ToInt32(textBoxG1.Text) > 100)
                    {
                        MessageBox.Show("Value  must be between 0-100");
                        textBoxG1.Text = "";
                        textBoxG1.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter the integer value");
                    textBoxG1.Text = "";
                    textBoxG1.Focus();
                }
            }
        } 

        private void textBoxG2_Leave(object sender, EventArgs e)
        {
            if (textBoxG2.Text != "")
            {
                try
                {
                    if (Convert.ToInt32(textBoxG2.Text) < 0 || Convert.ToInt32(textBoxG2.Text) > 100)
                    {
                        MessageBox.Show("Value  must be between 0-100");
                        textBoxG2.Text = "";
                        textBoxG2.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter the integer value");
                    textBoxG2.Text = "";
                    textBoxG2.Focus();
                }
            }
        }

        private void textBoxG3_Leave(object sender, EventArgs e)
        {
            if (textBoxG3.Text != "")
            {
                try
                {
                    if (Convert.ToInt32(textBoxG3.Text) < 0 || Convert.ToInt32(textBoxG3.Text) > 100)
                    {
                        MessageBox.Show("Value  must be between 0-100");
                        textBoxG3.Text = "";
                        textBoxG3.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter the integer value");
                    textBoxG3.Text = "";
                    textBoxG3.Focus();
                }
            }
        }

        private void textBoxNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
