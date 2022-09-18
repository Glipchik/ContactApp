using ContactApp.Core.Entities;

namespace ContactApp.DAL.Interfaces
{
    public interface IContactRepository
    {
        public Task<Guid> CreateAsync(Contact contact);

        public Task<bool> DeleteAsync(Guid id);

        public Task<IEnumerable<Contact>> GetAllAsync();

        public Task<Contact?> GetByIdAsync(Guid id);

        public Task<bool> UpdateAsync(Contact contact);
    }
}
