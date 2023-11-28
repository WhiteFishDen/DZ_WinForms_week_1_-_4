using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_WinForms_week_1_задание_4
{
    public partial class Form1 : Form
    {
        public int X { get; set; }
        public int Y { get; set; }
        private int _idStatic;
        private Label _static;
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            Text = "Рисуем Статики";
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                if(Math.Abs(e.X - X)<10|| Math.Abs(e.Y - Y)<10)
                {
                    MessageBox.Show("Размер статика должен быть не меньше, чем 10Х10",
                        "Некорректный размер статика!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(e.X > X && e.Y > Y)
                    {
                        _static.Location = new Point(X, Y);
                    }
                    else if(e.X > X && e.Y < Y)
                    {
                        _static.Location = new Point(X, e.Y);
                    }
                    else if(e.X < X && e.Y > Y)
                    {
                        _static.Location = new Point(e.X, Y);
                    }
                    else
                    {
                        _static.Location = new Point(e.X, e.Y);
                    }
                    _idStatic++;
                    _static.Size = new Size(Math.Abs(e.X - X), Math.Abs(e.Y - Y));
                    _static.BorderStyle = BorderStyle.Fixed3D;
                    _static.Text = Convert.ToString(_idStatic);
                    _static.BackColor = Color.DeepSkyBlue;
                    _static.ForeColor = Color.Red;
                    Controls.Add(_static);
                }


            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                _static = new Label();
                X = e.X;
                Y=e.Y;  
            }
        }

    }
}
