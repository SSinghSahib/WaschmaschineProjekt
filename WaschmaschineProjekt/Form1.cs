using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WaschmaschineProjekt
{
    public partial class Form1 : Form
    {
        public Waschprogramm aktuellesProgramm = Waschprogramm.KEIN;
        public int temperatur = 0;
        public int drehzahl = 0;
        public bool start;
        public bool stop;
        
        // Countdown-Timer
        private int seconds = 0;
        
        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
            pictureBox1.Enabled = false;
        }

        // Programmauswahl
        private void toolStripMenuItem_Programmauswahl_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            switch (item.Text)
            {
                case "Baumwolle":
                    aktuellesProgramm = Waschprogramm.BAUMWOLLE;
                    textBox_Programm.Text = "Baumwolle";
                    break;
                
                case "Synthetic":
                    aktuellesProgramm = Waschprogramm.SYNTHETIC;
                    textBox_Programm.Text = "Synthetic";
                    break;
                
                case "Kurzwäsche":
                    aktuellesProgramm = Waschprogramm.KURZWAESCHE;
                    textBox_Programm.Text = "Kurzwäsche";
                    break;

                case "Feinwäsche":
                    aktuellesProgramm = Waschprogramm.FEINWAESCHE;
                    textBox_Programm.Text = "Feinwäsche";
                    break;

                case "Schleudern":
                    aktuellesProgramm = Waschprogramm.SCHLEUDERN;
                    textBox_Programm.Text = "Schleudern";
                    DisableTemperatur(false);
                    seconds = 20;
                    break;
            }
        }
        
        // Schleudern ohne Temperaturauswahl
        void DisableTemperatur(bool aktiv)
        {
            toolStripMenuItem90Grad.Enabled = aktiv;
            toolStripMenuItem60Grad.Enabled = aktiv;
            toolStripMenuItem40Grad.Enabled = aktiv;
            toolStripMenuItem30Grad.Enabled = aktiv;
        }

        // Temperaturauswahl + Zeit
        private void toolStripMenuItem90Grad_Click(object sender, EventArgs e)
        {
            temperatur = 90;
            textBox_Temperatur.Text = temperatur.ToString();
            seconds = 60;
        }
        private void toolStripMenuItem60Grad_Click(object sender, EventArgs e)
        {
            temperatur = 60;
            textBox_Temperatur.Text = temperatur.ToString();
            seconds = 50;
        }
        private void toolStripMenuItem40Grad_Click(object sender, EventArgs e)
        {
            temperatur = 40;
            textBox_Temperatur.Text = temperatur.ToString();
            seconds = 40;
        }
        private void toolStripMenuItem30Grad_Click(object sender, EventArgs e)
        {
            temperatur = 30;
            textBox_Temperatur.Text = temperatur.ToString();
            seconds = 30;
        }

        // Drehzahlauswahl
        private void toolStripMenuItemDreh1300_Click(object sender, EventArgs e)
        {
            drehzahl = 1300;
            textBox_Drehzahl.Text = drehzahl.ToString();
        }

        private void toolStripMenuItemDreh1000_Click(object sender, EventArgs e)
        {
            drehzahl = 1000;
            textBox_Drehzahl.Text = drehzahl.ToString();
        }

        private void toolStripMenuItemDreh600_Click(object sender, EventArgs e)
        {
            drehzahl = 600;
            textBox_Drehzahl.Text = drehzahl.ToString();
        }

        // Start
        private void toolStripMenuItem_Start_Click(object sender, EventArgs e)
        {
            if(textBox_Programm.Text == "" || textBox_Programm.Text == "Stop" )
                return;
            
            start = true;
            timer1.Start();
            pictureBox1.Enabled = true;
            textBox_Ende.Text = ($"Das Programm ist gestartet !.");   
        }

        // Stop 
        private void toolStripMenuItem_Stop_Click(object sender, EventArgs e)
        {
            stop = true;
            timer1.Stop();
            pictureBox1.Enabled = false;
            textBox_Ende.Text = ($"Das Programm ist gestoppt !.");
        }
        
        // Timer
        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            textBox_VerZeit.Text = seconds--.ToString();
            textBox_VerZeit.Text = ($"{seconds} sec");
            if (seconds <= 0)
            {
                timer1.Stop();
                textBox_Ende.Text = ($"Das Programm ist fertig. Bitte Wäsche rausnehmen.");
               
                stop = true;
                timer1.Stop();
                pictureBox1.Enabled = false;
            }
        }
    }
} 
        