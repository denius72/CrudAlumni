using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudAlumni.Models;

namespace CrudAlumni.Data
{
    public class CrudAlumniContext : DbContext
    {
        public CrudAlumniContext (DbContextOptions<CrudAlumniContext> options)
            : base(options)
        {
        }

        public DbSet<CrudAlumni.Models.Aluno> Aluno { get; set; } = default!;
    }
}
