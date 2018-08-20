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
    public partial class LoginPage : Form
    {
        CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registation r = new Registation();
            r.Show();
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string uname = username.Text;
            string pass = password.Text;
            CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");


            if (uname == "" || pass == "")
            {

                MessageBox.Show("Provide Your Username and Password");
            }

            else
            {


                var i = (from a in c.RegistationTables
                         where a.Username == uname && a.Password == pass
                         select a);


                if (i.Any())
                {

                    if (uname == "admin" && pass == "admin")
                    {
                        Home h = new Home();
                        h.Show();
                        Visible = false;

                    }
                    else
                    {
                        ClientView cv = new ClientView();
                        OrderInfo co = new OrderInfo();
                        cv.textBox3.Text = uname;
                        cv.Show();
                        Visible = false;
                    }

                }

                else
                {
                    MessageBox.Show("Invalid Username or Password ");

                }
            }
        }
               
                


            

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                 password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
