using System;
using System.Collections.Generic;
using System.IO;
using ProyectoBD.Models;

namespace ProyectoBD.Services
{
    public class Tabla
    {
        private List<Registro> _registros;
        private string _rutaArchivo;

        public Tabla(string rutaArchivo)
        {
            _rutaArchivo = rutaArchivo;
            _registros = new List<Registro>();
            CargarRegistros();
        }

        // Método para agregar un registro
        public void AgregarRegistro(Registro registro)
        {
            _registros.Add(registro);
            GuardarRegistros();
        }

        // Método para eliminar un registro por cédula
        public void EliminarRegistro(string cedula)
        {
            _registros.RemoveAll(r => r.Cedula == cedula);
            GuardarRegistros();
        }

        // Método para buscar un registro por cédula
        public Registro BuscarRegistro(string cedula)
        {
            return _registros.Find(r => r.Cedula == cedula);
        }

        // Método para listar todos los registros
        public List<Registro> ListarRegistros()
        {
            return _registros;
        }

        // Método para guardar registros en un archivo
        private void GuardarRegistros()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_rutaArchivo))
                {
                    foreach (var registro in _registros)
                    {
                        writer.WriteLine($"{registro.Cedula},{registro.Nombre},{registro.FechaNacimiento:dd/MM/yyyy},{registro.Celular},{registro.Correo},{registro.Salario},{registro.Facultad}");
                    }
                }
                Console.WriteLine("Registros guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los registros: {ex.Message}");
            }
        }

        // Método para cargar registros desde un archivo
       private void CargarRegistros()
{
    try
    {
        if (File.Exists(_rutaArchivo))
        {
            using (StreamReader reader = new StreamReader(_rutaArchivo))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length == 7)
                    {
                        _registros.Add(new Registro(
                            datos[0].Trim(), // Cédula
                            datos[1].Trim(), // Nombre
                            DateTime.ParseExact(datos[2].Trim(), "dd/MM/yyyy", null), // FechaNacimiento
                            datos[3].Trim(), // Celular
                            datos[4].Trim(), // Correo
                            decimal.Parse(datos[5].Trim()), // Salario
                            datos[6].Trim()  // Facultad
                        ));
                    }
                }
            }
            Console.WriteLine("Registros cargados correctamente.");
        }
        else
        {
            Console.WriteLine("El archivo no existe. Se creará uno nuevo al guardar registros.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al cargar los registros: {ex.Message}");
    }
}
    }
}