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
    public partial class vInfo : Form
    {
        CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");

        public vInfo()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Product_Load(object sender, EventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = c.VehicleInfos;
            textBox2.Hide();
        }
        void GridViewUpdate()
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = c.VehicleInfos;
        }

        private void Product_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                VehicleInfo ct = new VehicleInfo
                {
                    Category = catcombo.SelectedItem.ToString(),
                    Car_Brand = textBox1.Text,
                    Car_Model = textBox4.Text,
                    Color = textBox7.Text,
                    Quantity = int.Parse(textBox5.Text),
                    Price = int.Parse(textBox6.Text)
                };

                c.VehicleInfos.InsertOnSubmit(ct);
                c.SubmitChanges();
                GridViewUpdate();

                MessageBox.Show("vehicle added");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed. Please try again");
            }
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            Home s = new Home();
            s.Show();
            this.Hide();
        }

        private void catcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = dr.Cells["Id"].Value.ToString();
                textBox1.Text = dr.Cells["Car_Brand"].Value.ToString();
                try
                {
                    catcombo.Text = dr.Cells["Category"].Value.ToString();
                }
                catch (Exception ex)
                {
                    catcombo.Text = "";
                }
                textBox4.Text = dr.Cells["Car_Model"].Value.ToString();
                textBox5.Text = dr.Cells["Quantity"].Value.ToString();
                textBox6.Text = dr.Cells["Price"].Value.ToString();
                textBox7.Text = dr.Cells["Color"].Value.ToString();

            }
        }

        private void refResh_Click(object sender, EventArgs e)
        {
            GridViewUpdate();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
                var x = from a in c.VehicleInfos
                        where a.Id == int.Parse(textBox2.Text.ToString())  
                        select a;
                x.First().Category = catcombo.SelectedItem.ToString();
                x.First().Quantity = int.Parse(textBox5.Text.ToString());
                x.First().Car_Model = textBox4.Text;
                x.First().Price = float.Parse(textBox6.Text.ToString());
                x.First().Car_Brand = textBox1.Text;
                x.First().Color = textBox7.Text;
                c.SubmitChanges();
                GridViewUpdate();
                MessageBox.Show("Updated");
            }
            catch
            {
                MessageBox.Show("failed");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            var x = from a in c.VehicleInfos
                    where a.Id == int.Parse(textBox2.Text)
                    select a;
            foreach (VehicleInfo vi in x)
            {
                c.VehicleInfos.DeleteOnSubmit(vi);
            }
            c.SubmitChanges();
            GridViewUpdate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            catcombo.Text = textBox1.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
        }

    }
}