using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FoodMachine
{
    public partial class Form1 : Form
    {
        private Machine machine = new Machine();
        DaylyReport daylyReport;

        public Form1()
        {
            InitializeComponent();
        }

        private void DisplaySnacksAndBottles(object sender, EventArgs e)
        {
            int buttonTop = 50;
            foreach (var p in machine.SnacksAndBottles)
            {
                Button snackButton = new Button();
                snackButton.Tag = p.Key;
                snackButton.Text = p.Key.Name+" "+p.Key.Price;
                snackButton.Location = new System.Drawing.Point(10, buttonTop);
                snackButton.Click += snackAndButtelButton_click;
                Controls.Add(snackButton);
                buttonTop += snackButton.Height + 10;
            }

        }
        private void snackAndButtelButton_click(object sender, EventArgs e)
        {
            Button prodductbutton = (Button)sender;
            Snack snack = (Snack)prodductbutton.Tag;
            Button paymentkButton = new Button();
            paymentkButton.Tag = snack;

            paymentkButton.Text = "Payment";
            paymentkButton.Location = new System.Drawing.Point(300, 300);
            paymentkButton.Click += paymentButton_click;
            Controls.Add(paymentkButton);
        }

        private void DisplayDrinks(object sender, EventArgs e)
        {
            int buttonTop = 30;
            foreach (var p in machine.Drinks)
            {
                Button DrinkButton = new Button();
                DrinkButton.Tag = p.Key;
                DrinkButton.Text = p.Key.Name+ ""+  p.Key.Price;
                DrinkButton.Location = new System.Drawing.Point(300, buttonTop);
                DrinkButton.Click += DrinkButton_click;
            
                Controls.Add(DrinkButton);
                buttonTop += DrinkButton.Height + 10;
            }

        }
        private void DrinkButton_click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            Drink drink = (Drink)button.Tag;
          
            Button WhippedMilkButton = new Button();
            WhippedMilkButton.Text = "milk";
            WhippedMilkButton.Location = new System.Drawing.Point(250, 150);
            WhippedMilkButton.Click += addMilk_click;
            Controls.Add(WhippedMilkButton);

            int teaspoonsOfShugar;
            teaspoonsOfShugar = sugarTextBox();
            drink.spoonsOfSugar = teaspoonsOfShugar;

            Button paymentkButton = new Button();
            paymentkButton.Tag = drink;
            paymentkButton.Text = "Payment";
            paymentkButton.Location = new System.Drawing.Point(300, 300);
            paymentkButton.Click += paymentButton_click;
            if (Controls.Contains(paymentkButton))
                Controls.Remove(paymentkButton);

            Controls.Add(paymentkButton);
        }
        
        private int sugarTextBox()
        {
            Label label = new Label();
            label.Text = "sugar";
            label.Location = new System.Drawing.Point(250, 250);

            TextBox sugar = new TextBox();
            sugar.Text = "2";
            sugar.Name = "sugarBtn";
            sugar.Location = new System.Drawing.Point(300, 250);
            Controls.Add(sugar);
            Controls.Add(label);
            TextBox sugarTextBox = Controls.Find("sugarBtn", true).FirstOrDefault() as TextBox;
            string sugarValue = sugarTextBox.Text;
            int num;
            int.TryParse(sugarValue, out num);
            return num;

        }

        private void paymentButton_click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            Product product = (Product)button.Tag;  
            daylyReport = new DaylyReport(product);

            Form form = new payment(product);
            form.Show();
            this.Hide();
        }
        private void addMilk_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Drink dr = (Drink)button.Tag;
            Milk milkedDrink = new Milk(dr);

            CheckBox milkCheckBox = new CheckBox();
            milkCheckBox.Text = " Whipped Milk";
            milkCheckBox.Location = new System.Drawing.Point(350, 150);
            Controls.Add(milkCheckBox);
            bool isWhippedMilk = milkCheckBox.Checked;

            CheckBox coldMilkCheckBox = new CheckBox();
            coldMilkCheckBox.Text = " Hot Milk";
            coldMilkCheckBox.Location = new System.Drawing.Point(350, 200);
            Controls.Add(coldMilkCheckBox);
            bool isCoddMilk = coldMilkCheckBox.Checked;
            milkedDrink.HotOrColdMilk(isCoddMilk);
          
        }


       


    }
}
