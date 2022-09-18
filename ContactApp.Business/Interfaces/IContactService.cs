using ContactApp.Core.Entities;

namespace ContactApp.Business.Interfaces
{
    public interface IContactService
    {
        public Task<IEnumerable<Contact>> GetAllContactsAsync();

        public Task<Contact?> GetContactAsync(Guid id);

        public Task<Guid> CreateContactAsync(Contact contact);

        public Task<bool> DeleteContactAsync(Guid id);

        public Task<bool> UpdateContactAsync(Contact contact);
    }
}
