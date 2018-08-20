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
    public partial class orderInformation : Form
    {
        CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
        public orderInformation()
        {
            InitializeComponent();
        }

        private void orderInformation_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = from a in c.OrderTables
                    where a.Order_Id == int.Parse(textBox1.Text)
                    select a;
            foreach (OrderTable vi in x)
            {
                c.OrderTables.DeleteOnSubmit(vi);
            }
            c.SubmitChanges();
            GridViewUpdate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = dr.Cells["Order_Id"].Value.ToString();
            }
        }
    }
}
