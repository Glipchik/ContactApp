using ContactApp.Business.Interfaces;
using ContactApp.Core.Entities;
using ContactApp.DAL.Interfaces;

namespace ContactApp.Business.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateContactAsync(Contact contact)
        {
            var contactId = await _contactRepository.CreateAsync(contact);

            await _unitOfWork.SaveChangesAsync();

            return contactId;
        }

        public async Task<bool> DeleteContactAsync(Guid id)
        {
            var result = await _contactRepository.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync() => await _contactRepository.GetAllAsync();

        public async Task<Contact?> GetContactAsync(Guid id) => await _contactRepository.GetByIdAsync(id);

        public async Task<bool> UpdateContactAsync(Contact contact)
        {
            var contactIsUpdated = await _contactRepository.UpdateAsync(contact);

            if (contactIsUpdated)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return contactIsUpdated;
        }
    }
}
