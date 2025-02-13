using System;

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