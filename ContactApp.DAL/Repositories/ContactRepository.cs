using ContactApp.Core.Entities;
using ContactApp.Core.Exceptions;
using ContactApp.DAL.Context;
using ContactApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.DAL.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Contact contact)
        {
            await _context.AddAsync(contact);

            return contact.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (_context.Contacts is null) throw new ContactDbSetNullException();

            var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (contact is not null)
            {
                _context.Remove(contact);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            if (_context.Contacts is null) throw new ContactDbSetNullException();

            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetByIdAsync(Guid id)
        {
            if (_context.Contacts is null) throw new ContactDbSetNullException();

            return await _context.Contacts.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<bool> UpdateAsync(Contact contact)
        {
            if (_context.Contacts is null) throw new ContactDbSetNullException();

            var contactToUpdate = await _context.Contacts.FirstOrDefaultAsync(n => n.Id == contact.Id);

            if (contactToUpdate is not null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.MobilePhone = contact.MobilePhone;
                contactToUpdate.JobTitle = contact.JobTitle;
                contactToUpdate.BirthDate = contact.BirthDate;

                return true;
            }

            return false;
        }
    }
}
