using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinarioRifeño_2020
{
    public partial class VentanaLogin : Form
    {
        Conexion conexion = new Conexion();
        public VentanaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexion.loginVeterinario(textBoxDNI.Text, textBoxpass.Text))
            {
                //Cuando ponga el usuario correcto para que se cierre la apliación.
                this.Hide();
                VentanaPrincipal v = new VentanaPrincipal();
                v.Show();
            }
            else
            {
                MessageBox.Show("EL USUARIO O LA CONTRASEÑA SON INCORRECTOS O NO ESTA REGISTRADO");
            }
           

        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conexion.Registrar(textBoxDNIregistro.Text, textBoxnombre.Text, textBoxcontraseña.Text));
        }
    }
}
