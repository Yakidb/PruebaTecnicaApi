using Microsoft.EntityFrameworkCore;
using PruebaTecnicaApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PruebaTecnicaApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<HostentHostEntity> Hosts { get; set; }
        public DbSet<HabentHabitacionEntity> Habitaciones { get; set; }
        public DbSet<TiphabentTipoHabitacionEntity> TiposHabitacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HostentHostEntity>()
                .HasMany(h => h.HabitacionesEntity)
                .WithOne(h => h.HostEntity)
                .HasForeignKey(h => h.host_id);

            modelBuilder.Entity<TiphabentTipoHabitacionEntity>()
                .HasMany(t => t.HabitacionesEntity)
                .WithOne(h => h.TipoHabitacionEntity)
                .HasForeignKey(h => h.tipo_habitacion_id);
        }
    }
}
