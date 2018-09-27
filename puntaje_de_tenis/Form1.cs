using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puntaje_de_tenis
{
    public partial class Form1 : Form
    {
        public string[] s_Puntaje = new string[5]; //points puede tener 5 diferentes puntajes
        public int A = 0, B = 0; // Contadores

        public struct Save { // Guardo del retroceso
            public string save1, save2, save3, save4, save5, save6;
            public bool jugador;
        }
        public Save save;//onjetos del guardado

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s_Puntaje[0] = "00"; // valores del contador points
            s_Puntaje[1] = "15";
            s_Puntaje[2] = "30";
            s_Puntaje[3] = "40";
            s_Puntaje[4] = "Ad";
            button3.Enabled = false; // inahabilitamos botn de retroceso
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save.save1 = label1.Text; save.save2 = label2.Text; save.save3 = label3.Text; //Hacemos el save del puntaje actual
            save.save4 = label4.Text; save.save5 = label5.Text; save.save6 = label6.Text;
            save.jugador = false;
            B++;
            if (A == 4 && B == 4) //si amabos llegan a estar en ventaja "Ad" los regresa a 40
            {
                A--;
                B--;
                label3.Text = s_Puntaje[3];
                label6.Text = s_Puntaje[3];
            }
            if (B == 5) { // si un jugador mete 5 equivale es un game
                label5.Text = '0' + Convert.ToString(Convert.ToInt32(label5.Text) + 1);
                B = 0;//regresamos poins a 00
                A = 0;
                if (Convert.ToInt32(label5.Text) == 6) { // si un jugador mete 5 equivale a un set
                    label4.Text = '0' + Convert.ToString(Convert.ToInt32(label4.Text) + 1);
                    label5.Text = s_Puntaje[0];//regresamos game a 00
                    label2.Text = s_Puntaje[0];
                    if (Convert.ToInt32(label4.Text) == 2) { // con 2 sets gana
                        label6.Text = s_Puntaje[B]; //cambia el la informacion de la tabla antes del messegebox
                        label4.Text = s_Puntaje[0];
                        MessageBox.Show("EL jugador A a ganado", "Ganador");//mensaje de victoria
                    }
                }
            }
            label6.Text = s_Puntaje[B]; //un jugador puede modificar al otro 
            label3.Text = s_Puntaje[A];
            button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save.save1 = label1.Text; save.save2 = label2.Text; save.save3 = label3.Text;
            save.save4 = label4.Text; save.save5 = label5.Text; save.save6 = label6.Text;
            save.jugador = true;
            A++;
            if (A == 4 && B == 4){
                A--;
                B--;
                label3.Text = s_Puntaje[3];
                label6.Text = s_Puntaje[3];
            }
            if (A == 5) {
                label2.Text = '0' + Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                A = 0;
                B = 0;
                if (Convert.ToInt32(label2.Text) == 6) {
                    label1.Text = '0' + Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                    label2.Text = s_Puntaje[0];
                    label5.Text = s_Puntaje[0];
                    if (Convert.ToInt32(label1.Text) == 2){
                        label3.Text = s_Puntaje[B];
                        MessageBox.Show("EL jugador A a ganado", "Ganador");
                        label1.Text = s_Puntaje[0];
                        button3.Enabled = false;
                    }
                }
            }
            label3.Text = s_Puntaje[A];
            label6.Text = s_Puntaje[B];
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = save.save1; label2.Text = save.save2; label3.Text = save.save3;
            label4.Text = save.save4; label5.Text = save.save5; label6.Text = save.save6;
            if (A == 0 || B == 0)
            {
                if (A == 0)
                {
                    if (save.jugador == true)
                    {
                        A = 4;
                    }
                }
                else
                {
                    if (save.jugador == false)
                    {
                        B = 4;
                    }
                }
                if (save.jugador == true) { A--; } //jugador "A" metio el ultimo punto
                else { B--; } //jugador "A" metio el ultimo punto
            }
            button3.Enabled = false;
        }
    }
}

