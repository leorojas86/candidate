using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    /// <summary>
    /// Mock class to emulate a contacts repository, it updates a dictionary and a list of contacts to 
    /// make sure all the opperations on the list and dictionary work as expected during unit tests
    /// </summary>
    public class MockContactsRepository : IContactsRepository
    {
        #region Variables

        private Dictionary<int, IContact> _contacts = new Dictionary<int, IContact>();
        private List<IContact> _contactsList        = new List<IContact>();
        private int _newContactId                   = 0;

        #endregion

        #region Methods

        public void Add(IContact contact)
        {
            contact.Id = _newContactId;
            _newContactId++;

            _contacts.Add(contact.Id, contact);
            _contactsList.Add(contact);
        }

        public void Update(IContact contact)
        {
            IContact existentContact                = _contacts[contact.Id];
            _contacts[contact.Id]                   = contact;
            int indexOfExistentContact              = _contactsList.IndexOf(existentContact);
            _contactsList[indexOfExistentContact]   = contact;
        }

        public void Delete(int contactId)
        {
            IContact existentContact = _contacts[contactId];
            _contacts.Remove(contactId);
            int indexOfExistentContact = _contactsList.IndexOf(existentContact);
            _contactsList.RemoveAt(indexOfExistentContact);
        }

        public IList<IContact> GetContacts()
        {
            return _contactsList;
        }

        #endregion
    }
}
