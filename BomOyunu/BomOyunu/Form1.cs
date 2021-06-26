using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomOyunu
{   
    public partial class Form1 : Form
    {
        public int number { get; set; }
        public Form1()
        {
            InitializeComponent();
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, label1.Width, label1.Height);
            this.label1.Region = new Region(path);
            leftButton.Enabled = false;
            rightButton.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        int time = 0;
        private void start_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.Green;
            number = 1;
            leftButton.Text =""+ (number + 1);
            rightButton.Text = "BOM";
            label1.Text = ""+number;
            start.Enabled = false;
            leftButton.Enabled = true;
            rightButton.Enabled = true;
            time = 5;
            progressBar1.Maximum = 5001;
            progressBar1.Value = time*1000;
            timer1.Start();
        }

        Random random = new Random();
        private void leftButton_Click(object sender, EventArgs e)
        {
            if (bomControl(Convert.ToInt32(leftButton.Text)) == 1)
                gameOver();
            else
            {
                nextStep();
                int r = random.Next(10);
                if (r % 2 == 0)
                    changeButtonsRandom();
            }
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            if (bomControl(Convert.ToInt32(leftButton.Text)) == 0)
                gameOver();
            else
            {
                nextStep();
                int r = random.Next(10);
                if (r % 2 == 0)
                    changeButtonsRandom();
            }
        }       
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            { 
                time--;
                progressBar1.Value = time * 1000;
            }
            if (time == 0)
                gameOver();           
        }

        public int bomControl(int x)
        {
            if (x % 5 == 0)
                return 1;
            else
                return 0;
        }

        public void gameOver()
        {
            label1.BackColor = Color.Red;
            timer1.Stop();
            progressBar1.Value = 0;
            MessageBox.Show("GAME OVER!");
            leftButton.Enabled = false;
            rightButton.Enabled = false;
            start.Enabled = true;
            label1.Text = "Play Again";
        }

        public void changeButtonsRandom()
        {
            Point t = rightButton.Location;
            rightButton.Location = leftButton.Location;
            leftButton.Location = t;
        }

        public void nextStep()
        {
            time = 5;
            progressBar1.Value = time * 1000;
            number += 2;
            if (bomControl(number) == 1)
            {
                label1.Text = "BOM";
                leftButton.Text = "" + (number + 1);
            }
            else
            {
                label1.Text = "" + (number);
                leftButton.Text = "" + (number + 1);
            }
        }

    }
}
