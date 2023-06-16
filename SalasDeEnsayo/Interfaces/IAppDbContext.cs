using Microsoft.EntityFrameworkCore;

namespace SalasDeEnsayo.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<saladeensayo> saladeensayo { get; set; }
        DbSet<tipodesala> tipodesala { get; set; }
<<<<<<< HEAD
        DbSet<listadeprecio> listadeprecio { get; set; }

=======
        DbSet<reserva> reserva { get; set; }
>>>>>>> 0425b26e3dbd324ba73832f131ec632d3399901a

        public string GetVersion();
        public int SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}