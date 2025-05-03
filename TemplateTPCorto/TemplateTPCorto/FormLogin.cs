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
                var usuarioBloqueado = loginNegocio.ValidarUsuarioBloqueado(credencial.Legajo);
                if (usuarioBloqueado) {
                    MessageBox.Show("¡El Usuario se encuentra bloqueado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {
                    MessageBox.Show("¡Inicio de sesión exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {


                var legajo = loginNegocio.obtenerLegajoPorNombre(usuario);
                var usuarioBloqueado = loginNegocio.ValidarUsuarioBloqueado(legajo);

                if (legajo != null)
                {
                    if(usuarioBloqueado)
                    {
                        MessageBox.Show("¡El Usuario se encuentra bloqueado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Si el usuario existe, registrar el intento de login fallido
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        loginNegocio.intentoLoginFallido(legajo);
                    }
                    // Si el usuario no está bloqueado, registrar el intento de login fallido
                }
                
            }

        }
    }
}
