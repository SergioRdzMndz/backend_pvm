using Back.Models; //Alan y Cami:)
using Microsoft.EntityFrameworkCore;

namespace Back.Data
{
    public class PvmContext:DbContext
    {
        public PvmContext(DbContextOptions<PvmContext> options) : base(options)
        {
        }
        public DbSet<Clientes> clientes { get; set; }   
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<DetalleVenta> Detalle { get; set; }
        public DbSet<Empleados> empleados { get; set; }
        public DbSet<Inventario> inventario { get; set; }
        public DbSet<Pagos> pagos { get; set; }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Proveedores> proveedores { get; set; }
        public DbSet<Ventas> ventas { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=DESKTOP-EL6M7BM\\SQLEXPRESS; Database= Base_de_datos; Trusted_Connection = True; User= sa; Password=Pejetronix420$; TrustServerCertificate= True ");

        //Sergio Rodríguez Mendoza
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().HasOne(p => p.Categoria).WithMany(c=>c.productos).HasForeignKey(p => p.IdCategoria);
            modelBuilder.Entity<Productos>().HasOne(p => p.Proveedor).WithMany(pr=>pr.productos).HasForeignKey(p=> p.IdCategoria);

            modelBuilder.Entity<Ventas>().HasOne(v=> v.Cliente).WithMany(cl=> cl.Ventas).HasForeignKey(v=> v.IdCliente);
            modelBuilder.Entity<Ventas>().HasOne(v=> v.Empleado).WithMany(em=> em.Ventas).HasForeignKey(v=> v.IdEmpleado);

            modelBuilder.Entity<DetalleVenta>().HasOne(dv => dv.Venta).WithMany(v => v.DetallesVentas).HasForeignKey(dv => dv.IdVenta);
            modelBuilder.Entity<DetalleVenta>().HasOne(dv => dv.Producto).WithMany(p => p.DetallesVenta).HasForeignKey(dv => dv.IdProducto);

            modelBuilder.Entity<Inventario>().HasOne(i => i.Producto).WithMany(p => p.Inventarios).HasForeignKey(i => i.IdProducto);

            modelBuilder.Entity<Pagos>().HasOne(p => p.Venta).WithMany(v => v.Pago).HasForeignKey(p => p.IdVenta);

            //modelBuilder.Entity<Usuarios>().HasOne(u => u.Empleado).WithMany(e => e.Usuarios).HasForeignKey(u => u.IdEmpleado);
        }
      
    }
}
