public class Registro
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Registro(int id, string nombre, int edad)
    {
        Id = id;
        Nombre = nombre;
        Edad = edad;
    }
    