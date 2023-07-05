using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;

namespace HealthCareOrganization.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Patient>? Patients { get; set; }
        public DbSet<Doctor>? Doctors { get; set; }
    }
}


