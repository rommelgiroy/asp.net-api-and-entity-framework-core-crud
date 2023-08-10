using Microsoft.EntityFrameworkCore;
using StudentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions context) : base(context)
    {

    }

    public DbSet<Student> Student { get; set; }
}
