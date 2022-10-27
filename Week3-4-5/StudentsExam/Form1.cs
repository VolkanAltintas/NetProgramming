using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        dbStudentRegisterEntities db = new dbStudentRegisterEntities();
        private void btnListStudent_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.tblStudents.ToList();

            var query = from x in db.tblStudents
                        select new
                        {
                            x.id,
                            x.firstName,
                            x.lastName,
                            x.phoneNumber
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.NOTLIST();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            tblStudent tblStudent = new tblStudent();
            tblStudent.firstName = textBox1.Text;
            tblStudent.lastName = textBox2.Text;
            tblStudent.phoneNumber = textBox3.Text;

            db.tblStudents.Add(tblStudent);
            db.SaveChanges();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(textBox4.Text);
            tblStudent t= db.tblStudents.Find(id);

            db.tblStudents.Remove(t);
            db.SaveChanges();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(textBox4.Text);
            tblStudent t = db.tblStudents.Find(id);

            t.firstName=textBox1.Text;
            t.lastName=textBox2.Text;
            t.phoneNumber=textBox3.Text;

            db.SaveChanges();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnNoteList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.tblNotes.ToList();
        }
    }
}
