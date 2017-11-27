using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace ColorPicker
{
    public partial class Form1 : Form
    {
        //Binding list to display the colors in the data grid view.
        BindingList<ChoosenColors> colorSelected = new BindingList<ChoosenColors>();

        //Color object
        Color currentColor;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button event to handle the showing of the color dialog as well as sending the chosen color to the color object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pictureBox1.BackColor = colorDialog1.Color;

            currentColor = colorDialog1.Color;
        }

        /// <summary>
        /// Adds the current color to the data binding list so that it can show it in the data grid view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            colorSelected.Add(new ChoosenColors(currentColor));

            dataGridView1.DataSource = colorSelected;
        }

        /// <summary>
        /// Serializes object to json then prints it the text file in json format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(colorSelected, Formatting.Indented);

            File.WriteAllText(@"E:\ColorPicker\ColorPicker\ColorsChosen.txt", json); //If file is not there it will create it.
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Q:
                        Close();
                        break;
                }
            }

        }

      
    }
}
