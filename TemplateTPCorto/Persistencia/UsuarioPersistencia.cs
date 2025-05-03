
using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UsuarioPersistencia
    {
        private DataBaseUtils dataBaseUtils = new DataBaseUtils();

        public Credencial login(String username)
        {
            try
            {
                var registros = dataBaseUtils.BuscarRegistro("credenciales.csv");

                if (registros != null && registros.Count > 0)
                {
                    foreach (var registro in registros)
                    {
                        // Dividir la línea del CSV en columnas (asumiendo que están separadas por ';')
                        var columnas = registro.Split(';');

                        // Verificar si la columna de nombreUsuario coincide con el parámetro username
                        if (columnas.Length > 1 && columnas[1].Equals(username, StringComparison.OrdinalIgnoreCase))
                        {
                            // Crear y devolver una instancia de Credencial con el registro encontrado
                            System.Diagnostics.Debug.WriteLine("Se encontro usuario");

                            return new Credencial(registro);
                        }
                    }
                }

                return null; // No se encontró ningún registro válido
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o lanzar una excepción personalizada)
                Console.WriteLine($"Error en el método login: {ex.Message}");
                return null;
            }
        }

        public Boolean ValidarUsuarioSiSeDebeBloquear(string legajo)
        {
            {
                var registros = dataBaseUtils.BuscarRegistro("login_intentos.csv");
                if (registros != null && registros.Count > 0)
                {
                    // Contar los intentos de login para el legajo especificado
                    int intentos = registros.Count(registro =>
                    {
                        var columnas = registro.Split(';');
                        return columnas.Length > 0 && columnas[0].Equals(legajo, StringComparison.OrdinalIgnoreCase);
                    });

                    // Si hay 3 o más intentos, el usuario está bloqueado

                    return intentos >= 3;
                }

                // Si no hay registros o no se alcanzaron 3 intentos, no está bloqueado
                return false;
            }
        }

        public Boolean ValidarUsuarioBloqueado(string legajo)
        {
            var registros = dataBaseUtils.BuscarRegistro("usuario_bloqueado.csv");
            if (registros != null && registros.Count > 0)
            {
                // Verificar si el legajo está en la lista de usuarios bloqueados
                return registros.Any(registro =>
                {
                    var columnas = registro.Split(';');
                    return columnas.Length > 0 && columnas[0].Equals(legajo, StringComparison.OrdinalIgnoreCase);
                });
            }

            // Si no hay registros o el legajo no está en la lista, no está bloqueado
            return false;
        }
        

        public void agregarIntentoDeLogin(string legajo)
        {
           
          DateTime fechaActual = DateTime.Now;
          string fechaFormateada = fechaActual.ToString("dd/MM/yyyy");
          dataBaseUtils.AgregarRegistro("login_intentos.csv", legajo + ";" + fechaFormateada);
            if (ValidarUsuarioSiSeDebeBloquear(legajo)){
                bloquearUsuario(legajo);
            }
            

        }
        public void bloquearUsuario (string legajo)
        {
            dataBaseUtils.AgregarRegistro("usuario_bloqueado.csv", legajo+";");

        }
        public string obtenerLegajoPorNombre(String username)
        {
            try
            {
                var registros = dataBaseUtils.BuscarRegistro("credenciales.csv");

                if (registros != null && registros.Count > 0)
                {
                    foreach (var registro in registros)
                    {
                        // Dividir la línea del CSV en columnas (asumiendo que están separadas por ';')
                        var columnas = registro.Split(';');

                        // Verificar si la columna de nombreUsuario coincide con el parámetro username
                        if (columnas.Length > 1 && columnas[1].Equals(username, StringComparison.OrdinalIgnoreCase))
                        {
                            // Devolver el número de legajo (columna 0)
                            return columnas[0];
                        }
                    }
                }

                return null; // No se encontró ningún registro válido
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o lanzar una excepción personalizada)
                Console.WriteLine($"Error en el método obtenerLegajoPorNombre: {ex.Message}");
                return null;
            }
        }
    }
}


