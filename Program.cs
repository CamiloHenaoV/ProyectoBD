using System;
using ProyectoBD.Services;
using ProyectoBD.Models;


class Program
{
    static void Main(string[] args)
    {
        string rutaArchivo = "personas.txt";
        Tabla tabla = new Tabla(rutaArchivo);

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Agregar Registro");
            Console.WriteLine("2. Eliminar Registro");
            Console.WriteLine("3. Buscar por Cédula");
            Console.WriteLine("4. Listar Registros");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la Cédula: ");
                    string cedula = Console.ReadLine();
                    Console.Write("Ingrese el Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la Fecha de Nacimiento (dd/MM/yyyy): ");
                    DateTime fechaNacimiento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    Console.Write("Ingrese el Celular: ");
                    string celular = Console.ReadLine();
                    Console.Write("Ingrese el Correo: ");
                    string correo = Console.ReadLine();
                    Console.Write("Ingrese el Salario: ");
                    decimal salario = decimal.Parse(Console.ReadLine());
                    Console.Write("Ingrese la Facultad: ");
                    string facultad = Console.ReadLine();
                    tabla.AgregarRegistro(new Registro(cedula, nombre, fechaNacimiento, celular, correo, salario, facultad));
                    break;

                case "2":
                    Console.Write("Ingrese la Cédula del registro a eliminar: ");
                    string cedulaEliminar = Console.ReadLine();
                    tabla.EliminarRegistro(cedulaEliminar);
                    break;

                case "3":
                    Console.Write("Ingrese la Cédula del registro a buscar: ");
                    string cedulaBuscar = Console.ReadLine();
                    Registro registro = tabla.BuscarRegistro(cedulaBuscar);
                    if (registro != null)
                    {
                        Console.WriteLine(registro.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Registro no encontrado.");
                    }
                    break;

                case "4":
                    var registros = tabla.ListarRegistros();
                    foreach (var r in registros)
                    {
                        Console.WriteLine(r.ToString());
                    }
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}