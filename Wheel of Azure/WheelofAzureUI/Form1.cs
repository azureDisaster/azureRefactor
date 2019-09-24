using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheelofAzureUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TextBox nameBox = new TextBox();
        Button button2 = new Button();

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Hide();
            Debug.WriteLine("ayyyye");
            Label enterNameLabel = new Label();
            enterNameLabel.Text = "Please enter your name: ";

            nameBox.AutoSize = true;
            nameBox.Top = 32;
            enterNameLabel.AutoSize = true;
            this.Controls.Add(enterNameLabel);
            this.Controls.Add(nameBox);
            button1.Hide();
            button2.Text = "Click me bruh";
            button2.Top = 64;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            this.Controls.Add(button2);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("ayyyye");
            string nameText = nameBox.Text;
            Label whatsGoodLabel = new Label();
            whatsGoodLabel.Top = 108;
            whatsGoodLabel.Text = "Whats good " + nameText;
            this.Controls.Add(whatsGoodLabel);
        }

    }
}
