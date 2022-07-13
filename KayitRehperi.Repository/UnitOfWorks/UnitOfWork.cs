using KayitRehperi.Core.UnitOfWorks;

namespace KayitRehperi.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIdentityDbContext _context;

        public UnitOfWork(AppIdentityDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
