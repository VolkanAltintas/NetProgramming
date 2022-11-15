using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EntityModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        dbStudentsRegisterEntities db = new dbStudentsRegisterEntities();
        private void btnListLecture_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NF93H7L\SQLEXPRESS;Initial Catalog=dbStudentsRegister;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from tblStudents",conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = db.tblStudents.ToList();
        }

        private void btnListNotes_Click(object sender, EventArgs e)
        {
            var query = from item in db.tblNotes
                        select new
                        {
                            item.notId,
                            item.student,
                            item.exam1,
                            item.exam2,
                            item.exam3,
                            item.average,
                            item.state
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //SET IDENTITY_INSERT student ON
            tblStudents t = new tblStudents();
            t.name = txtName.Text;
            t.lastname = txtLastName.Text;

            db.tblStudents.Add(t);
            db.SaveChanges();
            MessageBox.Show("Process Complete..");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtId.Text);
            var x = db.tblStudents.Find(id);
            db.tblStudents.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Delete process complete...");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var x = db.tblStudents.Find(id);

            x.name = txtName.Text;
            x.lastname = txtLastName.Text;
            x.photo = txtPhoto.Text;
            db.SaveChanges();
            MessageBox.Show("Update Process Complete...");
        }

        private void btnUpdateNotes_Click(object sender, EventArgs e)
        {

        }

        private void btnProc_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.NOTLISTESI();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.tblStudents.Where(x => x.name == txtName.Text).ToList();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtName.Text;
            var degerler = from item in db.tblStudents
                           where item.name.Contains(aranan)
                           select item;

            dataGridView1.DataSource = degerler.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //asc
                List<tblStudents> liste1 = db.tblStudents.OrderBy(p => p.name).ToList();
                dataGridView1.DataSource = liste1;
            }
            if (radioButton2.Checked)
            {
                List<tblStudents> liste2 = db.tblStudents.OrderByDescending(p => p.name).ToList();
                dataGridView1.DataSource = liste2;
            }
            if (radioButton3.Checked)
            {
                List<tblStudents> liste3 = db.tblStudents.OrderBy(p => p.name).Take(2).ToList();
                dataGridView1.DataSource = liste3;
            }
            if (radioButton4.Checked)
            {
                int id = int.Parse(txtId.Text);
                List<tblStudents> liste4 = db.tblStudents.Where(p => p.id ==id).ToList();
                dataGridView1.DataSource = liste4;
            }
            if (radioButton5.Checked)
            {
                List<tblStudents> liste5 = db.tblStudents.Where(p => p.name.StartsWith("A")).ToList();
                dataGridView1.DataSource = liste5;
            }
            if (radioButton6.Checked)
            {
                List<tblStudents> liste6 = db.tblStudents.Where(p => p.name.EndsWith("A")).ToList();
                dataGridView1.DataSource = liste6;
            }
            if (radioButton7.Checked)
            {
                bool deger = db.tblStudents.Any();
                MessageBox.Show(deger.ToString());
            }
            if (radioButton8.Checked)
            {
                int number = db.tblStudents.Count();
                MessageBox.Show(number.ToString());
            }
            if (radioButton9.Checked)
            {
                var toplam = db.tblNotes.Sum(p => p.exam1);
                MessageBox.Show(toplam.ToString());
            }
            if (radioButton10.Checked)
            {
                var ort = db.tblNotes.Average(p => p.exam1);
                MessageBox.Show(ort.ToString());
            }
            if (radioButton11.Checked)
            {
                var max = db.tblNotes.Max(p => p.exam1);
                MessageBox.Show(max.ToString());
            }
            if (radioButton12.Checked)
            {
                var min = db.tblNotes.Min(p => p.exam1);
                MessageBox.Show(min.ToString());
            }
        }
    }
}
