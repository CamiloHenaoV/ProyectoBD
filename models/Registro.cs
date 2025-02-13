namespace proyectoBD.Models
{
public class Registro
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Celular { get; set; }
    public string Correo { get; set; }
    public decimal Salario { get; set; }
    public string Facultad { get; set; }

    // Constructor
    public Registro(string cedula, string nombre, DateTime fechaNacimiento, string celular, string correo, decimal salario, string facultad)
    {
        Cedula = cedula;
        Nombre = nombre;
        FechaNacimiento = fechaNacimiento;
        Celular = celular;
        Correo = correo;
        Salario = salario;
        Facultad = facultad;
    }

    //  mostrar los datos del registro
    public override string ToString()
    {
        return $"Cédula: {Cedula}, Nombre: {Nombre}, Fecha de Nacimiento: {FechaNacimiento.ToShortDateString()}, " +
               $"Celular: {Celular}, Correo: {Correo}, Salario: {Salario:C}, Facultad: {Facultad}";
    }
}




}



