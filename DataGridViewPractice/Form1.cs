using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewPractice
{
    public partial class Form1 : Form
    {

        public List<Person> People { get; set; }

        public Form1()
        {
            People = GetPeople();
            InitializeComponent();
        }

        private List<Person> GetPeople()
        {
            var list = new List<Person>();

            list.Add(new Person()
            {
                PersonId = 1,
                Name = "Bob", 
                Surname = "Smith",
                Profession = "Programmer"
            });

            list.Add(new Person()
            {
                PersonId = 2,
                Name = "John",
                Surname = "Wayne",
                Profession = "Salesman"
            });

            return list;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var people = this.People;

            dataGridView1.DataSource = people;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var selectedPerson = dataGridView1.SelectedRows[0].DataBoundItem as Person;
                txtPersonId.Text = selectedPerson.PersonId.ToString();
                txtFirstName.Text = selectedPerson.Name;
                txtSecondName.Text = selectedPerson.Surname;
                txtProfession.Text = selectedPerson.Profession;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred: " + ex.Message + " - " + ex.Source);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selectedPerson = dataGridView1.SelectedRows[0].DataBoundItem as Person;
            var selectedPersonId = selectedPerson.PersonId;

            int textPersonId = Convert.ToInt32(txtPersonId.Text);
            try
            {
                if (selectedPersonId == textPersonId) {
                    this.People[selectedPersonId - 1].Name = txtFirstName.Text;
                    this.People[selectedPersonId - 1].Surname = txtSecondName.Text;
                    this.People[selectedPersonId - 1].Profession = txtProfession.Text;
                    MessageBox.Show("Existing record succesfully updated! \n Please click 'Refresh' to see changes", "Success!");
                } 
                else
                {
                    MessageBox.Show("Exisitng PersonID cannot be changed!", "Error!");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("An Error Occurred: " + ex.Message + " - " + ex.Source);
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            nullFields();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var selectedPerson = dataGridView1.SelectedRows[0];

            nullFields();

            selectedPerson.Selected = false;

            dataGridView1.DataSource = this.People;

        }

        private void nullFields()
        {
            txtPersonId.Text = null;
            txtFirstName.Text = null;
            txtSecondName.Text = null;
            txtProfession.Text = null;
        }

    }
}
