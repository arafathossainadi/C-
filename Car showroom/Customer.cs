using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_showroom
{
    public partial class CustInfo : Form
    {
        CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
        
        public CustInfo()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = c.CustomerTables;
            textBox1.Hide();
            dataGridView1.Columns[7].Visible = false;
        }
      public  void GridViewUpdate()
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = c.CustomerTables;
        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var x = from a in c.CustomerTables
                        where a.Customer_Id == int.Parse(textBox1.Text.ToString())
                        select a;

                foreach (CustomerTable b in x)
                {
                    c.CustomerTables.DeleteOnSubmit(b);
                }
                c.SubmitChanges();
                MessageBox.Show(" Deleted");
                GridViewUpdate();
            }
            catch
            {
                MessageBox.Show("Failed to Delete");
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            var x = from a in c.CustomerTables
                    where a.First_Name == search.Text
                    select a;
            try
            {
                search.Text = x.First().First_Name.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not found. Try again");
            }

            dataGridView1.DataSource = x.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = dr.Cells["Customer_Id"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GridViewUpdate();
        }

    }
}
