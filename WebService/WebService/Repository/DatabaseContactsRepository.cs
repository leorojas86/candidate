using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using System.Data.Entity;

namespace Repository
{
    public class DatabaseContactsRepository : DbContext, IContactsRepository
    {
        public DbSet<IContact> Contacts { get; set; }

        public void Add(IContact contact)
        {
            Contacts.Add(contact);
            SaveChanges();
        }

        public void Update(IContact contact)
        {
            //Contact instante can be different than the coresponding instance in the DbContext
            IContact dbContact = Contacts.Find(contact.Id);
            dbContact.Name     = contact.Name;
            dbContact.Email    = contact.Email;
            dbContact.Phone    = contact.Phone;

            SaveChanges();
        }

        public void Delete(int contactId)
        {
            //Contact instante can be different than the coresponding instance in the DbContext
            IContact dbContact = Contacts.Find(contactId);
            Contacts.Remove(dbContact);
            SaveChanges();
        }

        public IList<IContact> GetContacts()
        {
            return Contacts.ToList();
        }
    }
}
