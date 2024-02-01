using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using aplicacionModal.Data;
using aplicacionModal.utilities;
using aplicacionModal.utilitis;
using Microsoft.Win32;

namespace aplicacionModal
{
    public partial class Form1 : Form
    {
        private BloquearTeclas bloquearTeclas;
        private bool finalizar;
        public Form1()
        {
            Form formulario = this;
            InitializeComponent();
            bloquearTeclas = new BloquearTeclas();
           // SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            finalizar = true;
            this.Close();
        }
        // eventos
        private void Form_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            BloqueoTaksManger.BloquoTask();
        }

        private void FormCerrado(object sender, FormClosedEventArgs e)
        {
            bloquearTeclas.quitarBloqueo();
            BloqueoTaksManger.DesbloqueoTask();
        }

        private void MovimientoM(object sender, MouseEventArgs e)
        {
            MovimientoMouse.BloqueoMouse(this);
        }
        private void FormularioCerrando(object sender, FormClosingEventArgs e)
        {


            if (finalizar == false)
            {
                e.Cancel = true;
            }
        }
       /* private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            // Verifica el cambio de sesión
            if (e.Reason == SessionSwitchReason.SessionRemoteControl ||
                e.Reason == SessionSwitchReason.SessionLogon ||
                e.Reason == SessionSwitchReason.SessionLogoff ||
                e.Reason == SessionSwitchReason.SessionLock ||
                e.Reason == SessionSwitchReason.SessionUnlock)
            {
                // Realiza acciones cuando se detecta una conexión RDP
                if (e.Reason == SessionSwitchReason.SessionRemoteControl || e.Reason == SessionSwitchReason.SessionLogon)
                {
                    // Código a ejecutar cuando se inicia una conexión RDP
                    MessageBox.Show("Conexión RDP iniciada.");
                }
                else if (e.Reason == SessionSwitchReason.SessionLogoff)
                {
                    // Código a ejecutar cuando se cierra una conexión RDP
                    MessageBox.Show("Conexión RDP cerrada.");
                }
            }
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            ConexionRDP.Conexion(21,25);
        }
    }
}
