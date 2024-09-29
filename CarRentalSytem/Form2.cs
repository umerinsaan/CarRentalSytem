using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSytem
{
    public partial class Form2 : Form
    {
        private bool isForRented = false;
        public string selectedCar {  get; set; }
        public Form2(bool isForRented, ListBox availableCars, ListBox rentedCars)
        {
            InitializeComponent();
            this.selectedCar = "";
            this.isForRented = isForRented;
            this.button1.Text = "Make " + ((this.isForRented) ? "Available" : "Rented");
            this.listBox1.Items.Clear();
            if (!this.isForRented)
            {
                foreach(var item in  availableCars.Items)
                {
                    this.listBox1.Items.Add(item);
                }

            }
            
            else if (this.isForRented)
            {
                foreach( var item in rentedCars.Items)
                {
                    this.listBox1.Items.Add(item);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.listBox1.SelectedIndex !=  -1)
            {
                string selected_car = this.listBox1.Items[this.listBox1.SelectedIndex].ToString();

                if(!this.isForRented)
                    Form1.selectedCar_rented = selected_car;
                else if(this.isForRented) 
                    Form1.selectedCar_available = selected_car;
            }
            
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.selectedCar_available = "";
            Form1.selectedCar_rented = "";

            this.Close();
        }
    }
}
