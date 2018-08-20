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
    public partial class ClientView : Form
    {
        CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
        public ClientView()
        {
            InitializeComponent();
        }

        private void Customer_product_Load(object sender, EventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = c.VehicleInfos;
            textBox2.Hide();
            textBox3.Hide();
        }

        void GridViewUpdate()
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = c.VehicleInfos;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginPage h = new LoginPage();
            h.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = dr.Cells["Id"].Value.ToString();
                try
                {
                    textBox1.Text = dr.Cells["Car_Brand"].Value.ToString();
                }
                catch (Exception ex)
                {
                    catcombo.Text = "";
                }
                try
                {
                    catcombo.Text = dr.Cells["Category"].Value.ToString();
                }
                catch (Exception ex)
                {
                    catcombo.Text = "";
                }
                try
                {
                    textBox4.Text = dr.Cells["Car_Model"].Value.ToString();
                }
                catch (Exception ex)
                {
                    catcombo.Text = "";
                }
                try
                {
                    textBox5.Text = dr.Cells["Quantity"].Value.ToString();
                }
                catch (Exception ex)
                {
                    catcombo.Text = "";
                }
                try
                {
                    textBox6.Text = dr.Cells["Price"].Value.ToString();
                }
                catch (Exception ex)
                {
                    catcombo.Text = "";
                }
                try
                {
                    textBox7.Text = dr.Cells["Color"].Value.ToString();
                }
                catch (Exception ex)
                {
                    catcombo.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderInfo od = new OrderInfo();
            od.textBox1.Text = textBox3.Text;
            od.textBox4.Text = textBox2.Text;
            od.textBox9.Text = catcombo.Text;
            od.textBox8.Text = textBox1.Text;
            od.textBox2.Text = textBox4.Text;
            od.textBox6.Text = textBox6.Text;
            od.textBox7.Text = textBox7.Text;
            od.Show();
            this.Hide();
        }

        private void refResh_Click(object sender, EventArgs e)
        {
            GridViewUpdate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            var x = from a in c.VehicleInfos
                    where a.Car_Brand == textBox1.Text
                    select a;
            try
            {
                textBox5.Text = x.First().Quantity.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not found. Try again");
            }

            dataGridView1.DataSource = x.ToList();
        }

    }
}

