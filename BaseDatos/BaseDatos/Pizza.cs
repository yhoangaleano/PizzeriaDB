using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BaseDatos
{
    class Pizza
    {

        public Pizza()
        {
            this._idPizza = 0;
            this._nombrePizza = "";
            this._estado = true;
        }

        private SqlConnection connection;

        private SqlCommand command;

        private string connectionString = ConfigurationManager.ConnectionStrings["pizzeriaDB"].ConnectionString;

        public int _idPizza { get; set; }

        public string _nombrePizza { get; set; }

        public bool _estado { get; set; }

        public int guardarPizza() {

            int filasAfectadas = 0;

            using(this.connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    this.connection.Open();
                    string querySql = "INSERT_PIZZA";

                    this.command = new SqlCommand(querySql, this.connection);
                    this.command.CommandType = CommandType.StoredProcedure;
                    this.command.Parameters.AddWithValue("@nombrePizza", this._nombrePizza);

                    filasAfectadas = this.command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al intentar conectarse a la base de datos");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.connection.Close();
                }
            }

            return filasAfectadas;
        }

        public int actualizarPizza()
        {

            int filasAfectadas = 0;

            using (this.connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    this.connection.Open();
                    string querySql = "UPDATE_PIZZA";

                    this.command = new SqlCommand(querySql, this.connection);
                    this.command.CommandType = CommandType.StoredProcedure;
                    this.command.Parameters.AddWithValue("@idPizza", this._idPizza);
                    this.command.Parameters.AddWithValue("@nombrePizza", this._nombrePizza);
                    this.command.Parameters.AddWithValue("@estado", this._estado);
                    filasAfectadas = this.command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al intentar conectarse a la base de datos");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.connection.Close();
                }
            }

            return filasAfectadas;
        }

        public int eliminarPizza()
        {

            int filasAfectadas = 0;

            using (this.connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    this.connection.Open();
                    string querySql = "DELETE_PIZZA";

                    this.command = new SqlCommand(querySql, this.connection);
                    this.command.CommandType = CommandType.StoredProcedure;
                    this.command.Parameters.AddWithValue("@idPizza", this._idPizza);

                    filasAfectadas = this.command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al intentar conectarse a la base de datos");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.connection.Close();
                }
            }

            return filasAfectadas;
        }

        public int activarPizza()
        {

            int filasAfectadas = 0;

            using (this.connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    this.connection.Open();
                    string querySql = "ACTIVE_PIZZA";

                    this.command = new SqlCommand(querySql, this.connection);
                    this.command.CommandType = CommandType.StoredProcedure;
                    this.command.Parameters.AddWithValue("@idPizza", this._idPizza);

                    filasAfectadas = this.command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al intentar conectarse a la base de datos");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.connection.Close();
                }
            }

            return filasAfectadas;
        }

        public int inactivarPizza()
        {

            int filasAfectadas = 0;

            using (this.connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    this.connection.Open();
                    string querySql = "INACTIVE_PIZZA";

                    this.command = new SqlCommand(querySql, this.connection);
                    this.command.CommandType = CommandType.StoredProcedure;
                    this.command.Parameters.AddWithValue("@idPizza", this._idPizza);

                    filasAfectadas = this.command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al intentar conectarse a la base de datos");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.connection.Close();
                }
            }

            return filasAfectadas;
        }

        public void ListarPizzaReader()
        {

            using (this.connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    this.connection.Open();
                    string querySql = "LIST_PIZZA";

                    this.command = new SqlCommand(querySql, this.connection);
                    this.command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = this.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("Código de Pizza: {0}", reader["idPizza"]);
                        Console.WriteLine("Nombre de Pizza: {0}", reader["nombrePizza"]);
                        Console.WriteLine("Estado de la Pizza: {0}", reader["estado"]);
                        Console.WriteLine("-----------------------------------------------");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al intentar conectarse a la base de datos");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.connection.Close();
                }
            }
        }

        public DataTable ListarPizzaDataTable()
        {
            DataTable resultado = new DataTable();

            using (this.connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    this.connection.Open();
                    string querySql = "LIST_PIZZA";

                    this.command = new SqlCommand(querySql, this.connection);
                    this.command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adaptador = new SqlDataAdapter(this.command);
                    adaptador.Fill(resultado);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al intentar conectarse a la base de datos");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.connection.Close();
                }
            }

            return resultado;
        }

        public DataTable BuscarPizza(int p_opcion)
        {
            DataTable resultado = new DataTable();

            using (this.connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    this.connection.Open();
                    string querySql = "SEARCH_PIZZA";

                    this.command = new SqlCommand(querySql, this.connection);
                    this.command.CommandType = CommandType.StoredProcedure;

                    this.command.Parameters.AddWithValue("@idPizza", this._idPizza);
                    this.command.Parameters.AddWithValue("@nombrePizza", this._nombrePizza);
                    this.command.Parameters.AddWithValue("@estado", this._estado);
                    this.command.Parameters.AddWithValue("@opcion", p_opcion);

                    SqlDataAdapter adaptador = new SqlDataAdapter(this.command);
                    adaptador.Fill(resultado);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al intentar conectarse a la base de datos");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.connection.Close();
                }
            }

            return resultado;
        }
    }
}
