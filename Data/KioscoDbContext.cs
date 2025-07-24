using Microsoft.EntityFrameworkCore;
using KioscoAPI.Models;

namespace KioscoAPI.Data
{
    public class KioscoDbContext : DbContext
    {
        public KioscoDbContext(DbContextOptions<KioscoDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedore> Proveedores { get; set; }
        public DbSet<PrecioProducto> PreciosProducto { get; set; }
        public DbSet<MovimientoStock> MovimientosStock { get; set; }
        public DbSet<MovimientoInterno> MovimientosInternos { get; set; }
        public DbSet<CajaMovimiento> CajaMovimientos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<PagoFiado> PagosFiado { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === USUARIO ===
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.usuario).IsUnique(); // Usuario único
                entity.Property(u => u.usuario).HasColumnName("usuario");
            });

            // === VENTA-TICKET: Relación 1 a 1 ===
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Ticket)
                .WithOne(t => t.Venta)
                .HasForeignKey<Ticket>(t => t.id_venta)
                .OnDelete(DeleteBehavior.Restrict); // Evita borrado en cascada

            // === PRODUCTO - CATEGORIA / PROVEEDOR ===
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Producto)
                .HasForeignKey(p => p.id_categoria)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Proveedore)
                .WithMany(pv => pv.Producto)
                .HasForeignKey(p => p.id_proveedor)
                .OnDelete(DeleteBehavior.Restrict);

            // === PERMISO: Clave compuesta ===
            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(p => new { p.id_usuario, p.acceso }); // clave compuesta
                entity.Property(p => p.acceso).HasColumnName("acceso");

                entity.HasOne(p => p.Usuario)
                      .WithMany(u => u.Permisos)
                      .HasForeignKey(p => p.id_usuario)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // === DETALLEVENTA: FK a Venta y Producto ===
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Venta)
                .WithMany(v => v.DetalleVenta)
                .HasForeignKey(dv => dv.id_venta)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Producto)
                .WithMany(p => p.DetalleVenta)
                .HasForeignKey(dv => dv.id_producto)
                .OnDelete(DeleteBehavior.Restrict);

            // === PAGO FIADO: FK a Cliente y Venta ===
            modelBuilder.Entity<PagoFiado>()
                .HasOne(pf => pf.Cliente)
                .WithMany(c => c.PagosFiado)
                .HasForeignKey(pf => pf.id_cliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PagoFiado>()
                .HasOne(pf => pf.Venta)
                .WithMany(v => v.PagosFiado)
                .HasForeignKey(pf => pf.id_venta)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cuenta>()
              .Property(c => c.Saldo)
             .HasPrecision(18, 2); 
        }

    }
    }
     
    
