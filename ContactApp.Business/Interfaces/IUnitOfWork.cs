namespace ContactApp.Business.Interfaces
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
