using Microsoft.EntityFrameworkCore;
using SalasDeEnsayo.Entidades;
using SalasDeEnsayo.Interfaces;

namespace SalasDeEnsayo.Infraestructura;
public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext()
    {

    }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<saladeensayo> saladeensayo { get; set; }
    public DbSet<tipodesala> tipodesala { get; set; }
<<<<<<< HEAD
    public DbSet<listadeprecio> listadeprecio { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(" Server=172.0.0.14;Database=SEAA;user=TestUser;Password=Test2023!;Encrypt=true;TrustServerCertificate=True");
=======
    public DbSet<reserva> reserva { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(" Server=172.0.0.14;Database=SEMR;user=TestUser;Password=Test2023!;Encrypt=true;TrustServerCertificate=True");
>>>>>>> 0425b26e3dbd324ba73832f131ec632d3399901a

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<saladeensayo>()
            .Property(p => p.descripcion)
            .HasColumnType("Varchar")
            .HasMaxLength(50)
            .HasColumnName("descripcion_sala");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(100).HaveColumnType("Varchar");

    }


    public virtual int SaveChanges()
    {
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);

    }

    public string GetVersion()
    {
        throw new NotImplementedException();
    }

    public string GetVersion2()
    {
        throw new NotImplementedException();
    }
}
