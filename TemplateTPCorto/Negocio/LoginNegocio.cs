using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LoginNegocio
    {
        private UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();

        public Credencial login(String usuario, String password)
        {

            Credencial credencial = usuarioPersistencia.login(usuario);
            if (credencial != null && credencial.Contrasena.Equals(password))
            {
                return credencial;
            }
            return null;
        }
         public void intentoLoginFallido(String legajo)
        {

             usuarioPersistencia.agregarIntentoDeLogin(legajo);
            
        }
        public bool ValidarUsuarioBloqueado(string legajo)
        {
            return usuarioPersistencia.ValidarUsuarioBloqueado(legajo);
        }

        public string obtenerLegajoPorNombre(String username)
        {
            return usuarioPersistencia.obtenerLegajoPorNombre(username);
        }
    }
}
