namespace Jueguito
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double opacidad = 1.0;
        private bool bajar = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bajar)
            {
                opacidad -= 0.2;
                if (opacidad <= 0.1)
                {
                    opacidad = 0.1;
                    bajar = false;
                }
            }
            else
            {
                opacidad += 0.2;
                if (opacidad >= 1.0)
                {
                    opacidad = 1.0;
                    bajar = true;
                }
            }
            this.Opacity = opacidad;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Juego frmjuego = new Juego();
            frmjuego.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}