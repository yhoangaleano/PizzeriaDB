using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    class Program
    {
        static void Main(string[] args)
        {

            string opcion = "0";

            do
            {
                Console.WriteLine("Bienvenido a las pizzas de Harrison");
                Console.WriteLine("Ingrese 1. Para Insertar");
                Console.WriteLine("Ingrese 2. Para Actualizar");
                Console.WriteLine("Ingrese 3. Para Eliminar");
                Console.WriteLine("Ingrese 4. Para Inactivar");
                Console.WriteLine("Ingrese 5. Para Activar");
                Console.WriteLine("Ingrese 6. Para Listar Reader");
                Console.WriteLine("Ingrese 7. Para Listar DataTable");

                Console.WriteLine("Ingrese 8. Para Buscar por nombre");
                Console.WriteLine("Ingrese 9. Para Buscar por id");
                Console.WriteLine("Ingrese 10. Para Buscar por estado");
                Console.WriteLine("Ingrese 0. Para Salir");
                Console.WriteLine("¿Que deseas hacer?");
                opcion = Console.ReadLine();

                Pizza pizza = new Pizza();


                switch (opcion)
                {
                    case "1":

                        Console.WriteLine("Ingrese el nombre de la pizza:");
                        string nombrePizza = Console.ReadLine();

                        pizza._nombrePizza = nombrePizza;

                        if (pizza.guardarPizza() > 0)
                        {
                            Console.WriteLine("Pizza insertada correctamente");
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al guardar la pizza");
                        }

                        break;

                    case "2":

                        Console.WriteLine("Ingrese el id de la pizza a actualizar:");
                        int idPizzaActualizar = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el nombre de la pizza:");
                        string nombrePizzaActualizar = Console.ReadLine();

                        Console.WriteLine("Ingrese el estado de la pizza (1 para activo, 0 para inactivo):");
                        bool estadoActualizar = Console.ReadLine() == "1" ? true : false;

                        pizza._idPizza = idPizzaActualizar;
                        pizza._nombrePizza = nombrePizzaActualizar;
                        pizza._estado = estadoActualizar;
                        
                        if (pizza.actualizarPizza() > 0)
                        {
                            Console.WriteLine("Pizza actualizada correctamente");
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al actualizada la pizza");
                        }

                        break;

                    case "3":

                        Console.WriteLine("Ingrese el id de la pizza a eliminar:");
                        int idPizza = int.Parse(Console.ReadLine());

                        pizza._idPizza = idPizza;

                        if (pizza.eliminarPizza() > 0)
                        {
                            Console.WriteLine("Pizza eliminada correctamente");
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al eliminar la pizza");
                        }

                        break;

                    case "4":

                        Console.WriteLine("Ingrese el id de la pizza a inactivar:");
                        int idPizzaInactivar = int.Parse(Console.ReadLine());

                        pizza._idPizza = idPizzaInactivar;

                        if (pizza.inactivarPizza() > 0)
                        {
                            Console.WriteLine("Pizza inactivada correctamente");
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al inactivada la pizza");
                        }

                        break;

                    case "5":

                        Console.WriteLine("Ingrese el id de la pizza a activar:");
                        int idPizzaActivar = int.Parse(Console.ReadLine());

                        pizza._idPizza = idPizzaActivar;

                        if (pizza.activarPizza() > 0)
                        {
                            Console.WriteLine("Pizza activada correctamente");
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al activada la pizza");
                        }

                        break;

                    case "6":

                        pizza.ListarPizzaReader();

                        break;

                    case "7":

                        DataTable resultado = pizza.ListarPizzaDataTable();
                        if (resultado != null)
                        {
                            if (resultado.Rows.Count > 0)
                            {
                                foreach (DataRow item in resultado.Rows)
                                {
                                    Console.WriteLine("-----------------------------------------------");
                                    Console.WriteLine("Código de Pizza: {0}", item["idPizza"]);
                                    Console.WriteLine("Nombre de Pizza: {0}", item["nombrePizza"]);
                                    Console.WriteLine("Estado de la Pizza: {0}", item["estado"]);
                                    Console.WriteLine("-----------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No existen datos para mostrar");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error en base de datos");
                        }

                        break;

                    case "8":
                    case "9":
                    case "10":

                        int idPizzaBuscar = 0;
                        string nombrePizzaBuscar = "";
                        bool estadoPizzaBuscar = true;
                        int opcionBuscar = 0;


                        if (opcion == "8")
                        {
                            Console.WriteLine("Ingrese el nombre de la pizza a buscar:");
                            nombrePizzaBuscar = "%" + Console.ReadLine() + "%";
                            opcionBuscar = 1;
                        }
                        else if(opcion == "9")
                        {
                            Console.WriteLine("Ingrese el id de la pizza a buscar:");
                            idPizzaBuscar = int.Parse(Console.ReadLine());
                            opcionBuscar = 2;

                        }
                        else if (opcion == "10")
                        {
                            Console.WriteLine("Ingrese el estado de la pizza a buscar (1 Para Si, 2 Para No):");
                            estadoPizzaBuscar = Console.ReadLine() == "1" ? true : false;
                            opcionBuscar = 3;

                        }

                        pizza._idPizza = idPizzaBuscar;
                        pizza._nombrePizza = nombrePizzaBuscar;
                        pizza._estado = estadoPizzaBuscar;

                        DataTable resultadoBusqueda = pizza.BuscarPizza(opcionBuscar);
                        if (resultadoBusqueda != null)
                        {
                            if (resultadoBusqueda.Rows.Count > 0)
                            {
                                foreach (DataRow item in resultadoBusqueda.Rows)
                                {
                                    Console.WriteLine("-----------------------------------------------");
                                    Console.WriteLine("Código de Pizza: {0}", item["idPizza"]);
                                    Console.WriteLine("Nombre de Pizza: {0}", item["nombrePizza"]);
                                    Console.WriteLine("Estado de la Pizza: {0}", item["estado"]);
                                    Console.WriteLine("-----------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No existen datos para mostrar");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error en base de datos");
                        }
                    
                        break;
                }


            } while (opcion != "0");


            Console.WriteLine("Saliendo de la pizzeria");
            Console.ReadLine();
        }
    }
}
