namespace Core.EF
{
    public interface IUnitOfWork
    {
        public int SaveChanges();

        public Task<int> SaveChangesAsync();
    }
}