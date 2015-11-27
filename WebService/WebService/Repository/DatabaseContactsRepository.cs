using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using System.Data.Entity;
using DataProject;

namespace Repository
{
    public class DatabaseContactsRepository : IContactsRepository<IContact>
    {
        #region Variables

        private ContactsDAL _dal = new ContactsDAL();

        #endregion

        #region Methods

        public void Add(IContact contact)
        {
            Add((Contact)contact);
        }

        public void Add(Contact contact)
        {
            _dal.Contacts.Add(contact);
            _dal.SaveChanges();
        }

        public void Update(IContact contact)
        {
            Update((Contact)contact);
        }

        public void Update(Contact contact)
        {
            //Contact instante can be different than the coresponding instance in the DbContext
            IContact dbContact = _dal.Contacts.Find(contact.Id);
            dbContact.Name     = contact.Name;
            dbContact.Email    = contact.Email;
            dbContact.Phone    = contact.Phone;

            _dal.SaveChanges();
        }

        public void Delete(int contactId)
        {
            //Contact instante can be different than the coresponding instance in the DbContext
            Contact dbContact = _dal.Contacts.Find(contactId);
            _dal.Contacts.Remove(dbContact);
            _dal.SaveChanges();
        }

        public IList<IContact> GetContacts()
        {
            return new List<IContact>(_dal.Contacts.ToList());
        }

        #endregion
    }
}
