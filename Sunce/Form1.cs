using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Sunce1
        {
            #region atributi
            float x, y, a;
            #endregion

            #region metode
            public void Postavi(float x, float y, float a)
            {
                if (a >= 0)
                {
                    this.x = x;
                    this.y = y;
                    this.a = a;
                }
                else throw new Exception("Velicina<0");
            }
            public void Crtaj(Graphics g)
            {
                Pen olovka = new Pen(Color.Yellow, 3);
                SolidBrush cetka = new SolidBrush(Color.Yellow);
                g.DrawLine(olovka, x - a, y - a, x + a, y + a);
                g.DrawLine(olovka, x + a, y - a, x - a, y + a);
                g.DrawLine(olovka, x, y - a, x, y + a);
                g.DrawLine(olovka, x - a, y, x + a, y);
                g.FillEllipse(cetka, x - a / 2, y - a / 2, a, a);
            }
            public void Pomeri(float dx, float dy)
            {
                y += dx;
                y += dy;
            }
            public void Uvecaj()
            {
                a += 3;
            }
            #endregion
        }

        Sunce1 s = new Sunce1();
        float a, x, y;
        private void Form1_Load(object sender, EventArgs e)
        {
            a = 50;
            x = 30;
            y = ClientRectangle.Height;

            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            s.Postavi(x, y, a);
            s.Crtaj(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            float x1 = (float)(Math.PI / ClientRectangle.Width * x);
            float dy = (float)
                (ClientRectangle.Width / Math.PI * Math.Sin(x1));
            y = ClientRectangle.Height - dy;
            Refresh();
            s.Pomeri(x, y);
            if (x > ClientRectangle.Width)
            {
                x = 0;
            }
        }
    }
}
