using System;
using Microsoft.EntityFrameworkCore;
using LearningRestApiNet8.Models;

namespace LearningRestApiNet8.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Empleado> Empleados { get; set; }
}
