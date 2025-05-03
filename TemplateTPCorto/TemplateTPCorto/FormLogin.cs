using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            txtUsuario.Text = "zachary.mills";
            txtPassword.Text = "+OEDT#4j97";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;

            LoginNegocio loginNegocio = new LoginNegocio();
            Credencial credencial = loginNegocio.login(usuario, password);

            if (credencial != null)
            {
                MessageBox.Show("¡Inicio de sesión exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
