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
    public partial class Form1 : Form
    {
        public ListBox AvailableCarsListBox {  get; set; }
        public ListBox RentedCarsListBox {  get; set; }

        public static string selectedCar_rented {  get; set; }
        public static string selectedCar_available { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.UpdateValues();

            this.AvailableCarsListBox = new ListBox();
            this.RentedCarsListBox = new ListBox();

            Form1.selectedCar_available = "";
            Form1.selectedCar_rented = "";
        }

        private double total_rented = 0;
        private double total_available = 0;
        private double Total = 0;

        private void UpdateValues()
        {
            this.Total = (this.total_rented = this.Rented()) + (this.total_available = this.Available());

            this.textBox1.Text = $"${this.total_rented:F2}";

            this.textBox2.Text = $"{this.total_available:F2} $";

            this.textBox3.Text = $"${this.Total:F2}";


        }

        private int CountRented()
        {
            int count = 0;
            foreach(var item in  this.listBox1.Items) {
                count += item.ToString().Contains("RENTED") == true ? 1 : 0;
            }

            return count;
        }

        private int CountAvailable()
        {
            int count = 0;
            foreach (var item in this.listBox1.Items)
            {
                count += item.ToString().Contains("AVAILABLE") == true ? 1 : 0;
            }

            return count;
        }

        private double Rented()
        {
            double rented = 0;
            foreach(var item in this.listBox1.Items)
            {
                var s = item.ToString();
                if (s.Contains("Chevy Bolt"))
                {
                    if (s.Contains("RENTED"))
                        rented += 50;
                }
                else if (s.Contains("Nissan Leaf"))
                {
                    if (s.Contains("RENTED"))
                        rented += 75;
                }
                else if (s.Contains("Tesla Model S"))
                {
                    if (s.Contains("RENTED"))
                        rented += 100;
                }
            }

            return rented;
        }

        private double Available()
        {
            double available = 0;

            foreach( var item in this.listBox1.Items)
            {
                var s = item.ToString();
                if (s.Contains("Chevy Bolt"))
                {
                    if(s.Contains("AVAILABLE"))
                        available -= 50;
                }
                else if (s.Contains("Nissan Leaf"))
                {
                    if (s.Contains("AVAILABLE"))
                        available -= 75;
                }
                else if (s.Contains("Tesla Model S"))
                {
                    if (s.Contains("AVAILABLE"))
                        available -= 100;
                }
            }

            return available;
        }

        private void resetCtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.UpdateValues();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show($"Contains RENTED Count={CountRented()}","Contians?",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show($"Contains AVAILABLE Count={CountAvailable()}", "Contians?", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = this.listBox1.SelectedIndex;
            
            if (index == -1) return;

            this.listBox1.Items.RemoveAt(index);

            this.UpdateValues();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Electric Vehicle (EV) Rentals Version 1.0", "About", MessageBoxButtons.OK);
        }

        private void availableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AvailableCarsListBox.Items.Clear();
            foreach(var item in this.listBox1.Items)
            {
                if (item.ToString().Contains("AVAILABLE"))
                {
                    this.AvailableCarsListBox.Items.Add(item);

                }

            }

            Form2 f = new Form2(false , AvailableCarsListBox , RentedCarsListBox);
            f.ShowDialog();

            if (!string.IsNullOrEmpty(Form1.selectedCar_rented))
            {
                for (int i = 0; i < this.listBox1.Items.Count; i++)
                {
                    if (this.listBox1.Items[i].ToString() == Form1.selectedCar_rented)
                    {
                        this.listBox1.Items[i] = this.listBox1.Items[i].ToString().Replace("AVAILABLE","RENTED");
                        break;
                    }
                }

                this.UpdateValues();
            }

            Form1.selectedCar_rented = "";

        }

        private void rentedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RentedCarsListBox.Items.Clear();
            foreach (var item in this.listBox1.Items)
            {
                if (item.ToString().Contains("RENTED"))
                {
                    this.RentedCarsListBox.Items.Add(item);

                }

            }

            Form2 f = new Form2(true, AvailableCarsListBox, RentedCarsListBox);
            f.ShowDialog();

            if (!string.IsNullOrEmpty(Form1.selectedCar_available))
            {
                for (int i = 0; i < this.listBox1.Items.Count; i++)
                {
                    if (this.listBox1.Items[i].ToString() == Form1.selectedCar_available)
                    {
                        this.listBox1.Items[i] = this.listBox1.Items[i].ToString().Replace("RENTED", "AVAILABLE");
                        break;
                    }
                }

                this.UpdateValues();
            }

            Form1.selectedCar_available = "";
        }

        private void exitCtrlQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
