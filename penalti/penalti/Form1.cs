using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace penalti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Graphics g;
        Pen kalem_kale = new Pen(Color.Black, 5);
        Pen kalem_kaleci = new Pen(Color.Blue, 5);
        Brush firca_top = new SolidBrush(Color.Red);

        bool sol = true;
        int kaleci_x = 270, kaleci_y = 35, topx = 275, topy = 235;

        private void timerSut_Tick(object sender, EventArgs e)
        {
            Brush firca_top_sil = new SolidBrush(this.BackColor);
            g.FillEllipse(firca_top_sil, topx, topy, 10, 10);

            if (Math.Abs(kaleci_x - topx) <= 20 && Math.Abs(kaleci_y - topy) <= 10)
            {
                timerKaleci.Enabled = false;
                timerSut.Enabled = false;
                button1.Enabled = true;

                MessageBox.Show("KALECİ DUTTU ;)");
            }
            else if (topy < kaleci_y)
            {
                timerKaleci.Enabled = false;
                timerSut.Enabled = false;
                button1.Enabled = true;

                MessageBox.Show("GOOOOOLLLLLLLLLLLL!!!!!!");
            }
          else
            topy = topy - 5;


            g.FillEllipse(firca_top, topx, topy, 10, 10);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen kalem_kaleci_sil = new Pen(this.BackColor, 5);
            g.DrawRectangle(kalem_kaleci_sil, kaleci_x, kaleci_y, 20, 5);
            Brush firca_top_sil = new SolidBrush(this.BackColor);            
            g.FillEllipse(firca_top_sil, topx, topy, 10, 10);
            sol = true;
            kaleci_x = 270;
            kaleci_y = 35;
            topx = 275;
            topy = 235;

            g.DrawRectangle(kalem_kaleci, kaleci_x, kaleci_y, 20, 5);
            g.FillEllipse(firca_top, topx, topy, 10, 10);

            timerKaleci.Enabled = true;
            timerSut.Enabled = false;
            button1.Enabled = false;
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                timerSut.Enabled = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = this.CreateGraphics();
            g.DrawRectangle(kalem_kale, 200, 10, 5, 20); // Sol Direk
            g.DrawRectangle(kalem_kale, 210, 10, 150, 5); // Üst Direk
            g.DrawRectangle(kalem_kale, 360, 10, 5, 20); // Sağ Direk
            g.DrawRectangle(kalem_kaleci, kaleci_x, kaleci_y, 20,5); //Kaleci
            g.FillEllipse(firca_top, topx, topy, 10, 10); //Top



        }

        private void timerKaleci_Tick(object sender, EventArgs e)
        {
            Pen kalem_kaleci_sil = new Pen(this.BackColor, 5);
            Brush firca_top_sil = new SolidBrush(this.BackColor);

            g.DrawRectangle(kalem_kaleci_sil, kaleci_x, kaleci_y, 20, 5);
            g.FillEllipse(firca_top_sil, topx, topy, 10, 10);
           

            if(timerSut.Enabled==false)
            { 

            Random r = new Random();
            topx = r.Next(210, 345);

            }
            if (sol == true)
                kaleci_x = kaleci_x - 5;
            else
                kaleci_x = kaleci_x + 5;

            if (kaleci_x <= 210) sol = false;
            if (kaleci_x >= 335) sol = true;

            g.DrawRectangle(kalem_kaleci, kaleci_x, kaleci_y, 20, 5);
            g.FillEllipse(firca_top, topx, topy, 10, 10);
        }
    }
}
