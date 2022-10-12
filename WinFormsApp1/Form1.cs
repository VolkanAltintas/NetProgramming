using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Id = Convert.ToInt32(txtId.Text);
            student.FirstName = txtName.Text; 
            student.LastName=txtLastName.Text;
            student.PhoneNumber = txtPhone.Text;
            student.Address = txtAddress.Text;
            
            students.Add(student);
            clearTxtBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (IPerson x in students)
                listBox1.Items.Add(x.FirstName+" "+x.LastName);
            
        }

        public void clearTxtBox()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    c.Text = " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();    
            teacher.Id = Convert.ToInt32(txtId.Text);
            teacher.FirstName = txtName.Text;
            teacher.LastName = txtLastName.Text;
            teacher.PhoneNumber = txtPhone.Text;
            teacher.Address = txtAddress.Text;
            teachers.Add(teacher);
            clearTxtBox();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Teacher teacher in teachers)
                listBox1.Items.Add(teacher.FirstName+" "+teacher.LastName);
        }
    }
}
