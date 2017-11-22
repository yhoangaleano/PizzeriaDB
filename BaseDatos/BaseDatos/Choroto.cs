using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaseDatos
{
    class Choroto
    {
        public void Ejemplo()
        {
            string connectionString = "Data Source=DESKTOP-BEQHCIU;Initial Catalog=pizzeriaDB;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conectado a base de datos");

                    Console.WriteLine("Ingrese el nombre de la pizza");
                    string nombrePizza = Console.ReadLine();

                    string querySql = "INSERT INTO tblPizza (nombrePizza) VALUES ('" + nombrePizza + "');";

                    SqlCommand command = new SqlCommand(querySql, connection);
                    command.CommandType = CommandType.Text;

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine("Pizza insertada correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No se inserto una pizza, por favor intentelo de nuevo");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al intentar conectarse");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                    Console.WriteLine("Conexion cerrada");
                }
            }
        }

    }
}
