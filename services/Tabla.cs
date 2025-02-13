using System;
using System.Collections.Generic;
using System.IO;
using MiProyecto.Models;

namespace MiProyecto.Services
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
                        writer.WriteLine(registro.ToString());
                    }
                }
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
                                    datos[0], // Cédula
                                    datos[1], // Nombre
                                    datos[2], // FechaNacimiento
                                    datos[3], // Celular
                                    datos[4], // Correo
                                    decimal.Parse(datos[5]), // Salario
                                    int.Parse(datos[6]) // Facultad
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los registros: {ex.Message}");
            }
        }
    }
}using System;

namespace MiProyecto.Models
{
    public class Registro
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }

        public Registro()
        {
            Id = 0;
            Descripcion = string.Empty;
            FechaHora = DateTime.Now;
        }

        public Registro(int id, string descripcion, DateTime fechaHora)
        {
            Id = id;
            Descripcion = descripcion;
            FechaHora = fechaHora;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Fecha y Hora: {FechaHora}");
        }
    }
}