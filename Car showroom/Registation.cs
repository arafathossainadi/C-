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
    public partial class Registation : Form
    {
        public Registation()
        {
            InitializeComponent();
        }

        private void Registation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = gcombo.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                CarDataContext c = new CarDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\adi\Documents\New folder\csms.mdf;Integrated Security=True;Connect Timeout=30");
                try
                {
                    RegistationTable rt = new RegistationTable
                    {
                        First_Name = textBox1.Text,
                        Last_Name = textBox2.Text,
                        Gender = gcombo.SelectedItem.ToString(),
                        phone = textBox4.Text,
                        Email = textBox5.Text,
                        Address = textBox6.Text,
                        Username = textBox7.Text,
                        Password = textBox8.Text
                    };

                    CustomerTable cta = new CustomerTable
                    {
                        First_Name = textBox1.Text,
                        Last_Name = textBox2.Text,
                        Email = textBox5.Text,
                        Phone = textBox4.Text
                    };

                    try
                    {
                        if (textBox1.Text == "")
                        {
                            MessageBox.Show("Provide Your First Name");
                        }
                        else if (textBox2.Text == "")
                        {
                            MessageBox.Show("Provide Your Last Name");
                        }
                        else if (textBox4.Text == "")
                        {
                            MessageBox.Show("Phone Number can't be empty");
                        }
                        else if (!textBox4.Text.StartsWith("016") && !textBox4.Text.StartsWith("017"))
                        {
                            MessageBox.Show("Provide a valid phone number ");
                        }
                        else if (textBox4.Text.Length <11)
                        {
                            MessageBox.Show("Provide a 11 digit valid phone number");
                        }
                        else if (textBox5.Text == "")
                        {
                            MessageBox.Show("Provide your email address");
                        }
                        else if (textBox7.Text == "")
                        {
                            MessageBox.Show("Provide your username");
                        }
                        else if (textBox8.Text == "")
                        {
                            MessageBox.Show("Provide a password");
                        }
                        else if (textBox7.Text != "")
                        {
                            var j = (from a in c.RegistationTables
                                     where a.Username == textBox7.Text
                                     select a);
                            if (textBox7.Text == j.First().Username)
                            {
                                MessageBox.Show("username is not available. provide anything new");
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        c.RegistationTables.InsertOnSubmit(rt);
                        c.CustomerTables.InsertOnSubmit(cta);
                        c.SubmitChanges();
                        MessageBox.Show("Registration Succesfull");
                        this.Hide();
                        LoginPage f1 = new LoginPage();
                        f1.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registration failed. Please provide all the information correctly.");
                }
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginPage f1 = new LoginPage();
            f1.Show();
            this.Hide();
        }

        private void gcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
