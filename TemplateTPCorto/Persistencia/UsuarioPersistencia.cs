
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
        public Credencial login(String username)
        {
            try
            {
                var dataBaseUtils = new DataBaseUtils();
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
    }
}


