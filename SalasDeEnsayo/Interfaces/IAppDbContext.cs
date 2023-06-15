using Microsoft.EntityFrameworkCore;

namespace SalasDeEnsayo.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<saladeensayo> saladeensayo { get; set; }
        DbSet<tipodesala> tipodesala { get; set; }


        public string GetVersion();
        public int SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}