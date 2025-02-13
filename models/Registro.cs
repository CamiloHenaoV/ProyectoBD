using System;

public class Registro
{
    // Propiedades de la clase
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaHora { get; set; }

    // Constructor por defecto
    public Registro()
    {
        // Inicializar propiedades con valores por defecto
        Id = 0;
        Descripcion = string.Empty;
        FechaHora = DateTime.Now;
    }

    // Constructor con parámetros
    public Registro(int id, string descripcion, DateTime fechaHora)
    {
        Id = id;
        Descripcion = descripcion;
        FechaHora = fechaHora;
    }

    // Método para mostrar la información del registro
    public void MostrarInformacion()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Descripción: {Descripcion}");
        Console.WriteLine($"Fecha y Hora: {FechaHora}");
    }
}