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
    public DbSet<instrumento> instrumento { get; set; }
    public DbSet<saladeensayoequipamiento> saladeensayoequipamiento { get; set; }
    public DbSet<listadeprecio> listadeprecio { get; set; }
    public DbSet<reserva> reserva { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(" Server=172.0.0.14;Database=SEMB;user=TestUser;Password=Test2023!;Encrypt=true;TrustServerCertificate=True");

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
