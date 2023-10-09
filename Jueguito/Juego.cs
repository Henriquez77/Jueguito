using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jueguito
{
    public partial class Juego : Form
    {
        Random rnd = new Random();
        int puntaje = 0, tiempo = 30, jugador = 1;
        public Juego()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Cambiar(PictureBox pic, List<PictureBox> pictureBoxes, int margenIzquierdo, int margenDerecho, int margenArriba, int margenAbajo)
        {
            int contenedorAncho = pic.Parent.Width;
            int contenedorAlto = pic.Parent.Height;

            int maxX = contenedorAncho - pic.Width - margenDerecho;
            int minX = margenIzquierdo;

            int maxY = contenedorAlto - pic.Height - margenAbajo;
            int minY = margenArriba;

            int posX = rnd.Next(minX, maxX);
            int posY = rnd.Next(minY, maxY);

            //bool posicionValida = false;
            //int posX = 0, posY = 0;

            //while (!posicionValida)
            //{
            //    posX = rnd.Next(minX, maxX);
            //    posY = rnd.Next(minY, maxY);
            //    bool colision = false;
            //    foreach (PictureBox pb in pictureBoxes)
            //    {
            //        if (pb != pic && pic.Bounds.IntersectsWith(pb.Bounds))
            //        {
            //            colision = true;
            //            break;
            //        }
            //    }
            //    if (!colision)
            //    {
            //        posicionValida = true;
            //    }
            //}

            pic.Location = new Point(posX, posY);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            OcultarPictureBoxes();
            //List<PictureBox> pictureBoxesAMostrar = new List<PictureBox>();
            List<PictureBox> pictureBoxes = new List<PictureBox>
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6
            };

            int numPictureBoxAMostrar = rnd.Next(2, 4);

            for (int i = 0; i < numPictureBoxAMostrar; i++)
            {
                if (pictureBoxes.Count > 0)
                {
                    int index = rnd.Next(pictureBoxes.Count);
                    PictureBox pb = pictureBoxes[index];
                    //pictureBoxesAMostrar.Add(pb);
                    pictureBoxes.RemoveAt(index);
                    pb.Visible = true;
                }
            }

            //foreach (PictureBox pb in pictureBoxesAMostrar)
            //{
            //    Cambiar(pb, pictureBoxesAMostrar, 170, 20, 40, 40);
            //}
            foreach (PictureBox pb in pictureBoxes)
            {
                Cambiar(pb, pictureBoxes, 170, 20, 40, 70);
            }
            Tiempo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        public void TimesUp(int puntuacion, int numerojugador)
        {
            MessageBox.Show($"¡El tiempo se ha acabado! Jugador{numerojugador} su puntuacion es: {puntuacion}");
            jugador += 1;
        }
        private void Tiempo()
        {
            tiempo -= 1;
            label4.Text = tiempo.ToString();
            if(tiempo == 0)
            {
                timer1.Stop();
                OcultarPictureBoxes();
                TimesUp(puntaje,jugador);
            }
        }
        private void OcultarPictureBoxes()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            OcultarPictureBoxes();
            label4.Text = tiempo.ToString();
        }
        private void SumarPuntaje()
        {
            puntaje += 1;
            label5.Text = puntaje.ToString();
         
        }

        private void Juego_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SumarPuntaje();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SumarPuntaje();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SumarPuntaje();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SumarPuntaje();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SumarPuntaje();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SumarPuntaje();
        }
    }
}
