
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace FoodMachine
{
    public partial class payment : Form
    {
        private void payment_Load(object sender, EventArgs e)
        {

        }
        Product product;
        public payment(Product product)
        {
            this.product = product;
           
            Label label = new Label();
            label.Text = "please enter " + product.Price.ToString() + "$";
            label.Location = new System.Drawing.Point(350, 150);
            Controls.Add(label);
            InitializeComponent();
        }

      

        private void Pay_Click(object sender, EventArgs e)
        {
            double pay=product.Price;
            TextBox textBox = Controls.Find("Pay", true).FirstOrDefault() as TextBox;
            int num = int.Parse(textBox.Text);
            if (num == pay)
            {
                MessageBox.Show("Thank you for buying in our machine!!!");
                Form form = new Form1();
                form.Show();
                this.Hide();
            }
            else
            {
                if (num > pay)
                {
                    MessageBox.Show($"Change of {num-pay}$");
                    Form form = new Form1();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"{pay - num} missing.$");
                }

            }
        }

        private void Bag_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            BagDecorator bagDecorator = (BagDecorator)button.Tag;
            button.Tag = bagDecorator;
            bagDecorator.Bag(product);
            button.Click += Pay_Click;




        }

        private void Wrap_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            WrapDecorator wrapDecorator = (WrapDecorator)button.Tag;
            button.Click += Pay_Click;

        }
    }
}
