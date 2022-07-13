namespace KayitRehperi.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommmitAsync();

        void Commit();

    }
}
