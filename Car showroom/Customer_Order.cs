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
    public partial class OrderInfo : Form
    {
        CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
        ClientView cv = new ClientView();

        private void Customer_Order_Load(object sender, EventArgs e)
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = c.OrderTables;
            textBox1.Hide();
        }

        void GridViewUpdate()
        {
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = c.OrderTables;
        }
        public string fetchUser;

        public OrderInfo()
        {
            InitializeComponent();
            textBox4.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OrderTable ot = new OrderTable
                {
                    Vehicle_Id = int.Parse(textBox4.Text),
                    Customer_Id = textBox1.Text,
                    Catagory = textBox9.Text,
                    Brand_Name = textBox8.Text,
                    Car_Model = textBox2.Text,
                    Order_Quantity = int.Parse(textBox5.Text),
                    Price = int.Parse(textBox6.Text),
                    Color = textBox7.Text,
                    Order_Date = dateTimePicker1.Text
                };
                    c.OrderTables.InsertOnSubmit(ot);
                    c.SubmitChanges();
                    GridViewUpdate();

                    var x = from a in c.VehicleInfos
                            where a.Id == int.Parse(textBox4.Text.ToString())
                            select a;
                    int oq = int.Parse(textBox5.Text.ToString());
                    int vq;
                    int rslt;
                    vq = x.First().Quantity;
                    if ((vq > 0) && (oq < vq))
                    {
                        rslt = vq - oq;
                        x.First().Quantity = rslt;
                        c.SubmitChanges();
                        GridViewUpdate();
                        MessageBox.Show("Your order has been placed in queue. Please be with us untill we contact with you");
                    }
                    else
                    {
                        var z = from a in c.OrderTables
                                where a.Customer_Id == textBox1.Text
                                select a;
                        foreach (OrderTable vi in z)
                        {
                            c.OrderTables.DeleteOnSubmit(vi);
                        }
                        c.SubmitChanges();
                        GridViewUpdate();
                        MessageBox.Show(oq+" cars is not available right now");
                    }
            }
            catch (Exception ex)
            {
                if (textBox5.Text == "" && textBox8.Text != "")
                {
                    MessageBox.Show("Please provide order quantity");
                }
                else
                {
                    MessageBox.Show("Please provide all the information correctly");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var x = from a in c.OrderTables
                    where a.Customer_Id == textBox1.Text
                    select a;
            var y = from b in c.VehicleInfos
                    where b.Id == x.First().Vehicle_Id
                    select b;
            int oqq = x.First().Order_Quantity;
            int vqq = y.First().Quantity;
            int rs = vqq + oqq;
            y.First().Quantity = rs;
            foreach (OrderTable vi in x)
            {
                c.OrderTables.DeleteOnSubmit(vi);
            }
            c.SubmitChanges();
            MessageBox.Show("Your Order Has Been Cancelled");
            GridViewUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientView cv = new ClientView();
            cv.textBox3.Text = textBox1.Text;
            cv.Show();
            this.Hide();
        }
    }
}
