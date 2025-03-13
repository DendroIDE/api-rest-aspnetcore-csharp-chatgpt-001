using System;

namespace LearningRestApiNet8.Models;

public class Empleado
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Cargo { get; set; }
    public decimal Salario { get; set; }  // Usamos decimal para valores monetarios

}
