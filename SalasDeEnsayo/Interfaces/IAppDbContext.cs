using Microsoft.EntityFrameworkCore;

namespace SalasDeEnsayo.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<saladeensayo> saladeensayo { get; set; }
        DbSet<tipodesala> tipodesala { get; set; }
<<<<<<< HEAD
        DbSet<instrumento> instrumento { get; set; }
        DbSet<saladeensayoequipamiento> saladeensayoequipamiento { get; set; }
=======
        DbSet<listadeprecio> listadeprecio { get; set; }
        DbSet<reserva> reserva { get; set; }
>>>>>>> main

        public string GetVersion();
        public int SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}