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
    public class DatabaseContactsRepository : IContactsRepository
    {
        #region Variables

        private ContactsDAL _dal                 = new ContactsDAL();
        private ContactsFactory _contactsFactory = new ContactsFactory();

        #endregion

        #region Properties

        public IContactsFactory Factory
        {
            get { return _contactsFactory; }
        }

        #endregion

        #region Methods

        public void Add(IContact contact)
        {
            _dal.Add((Contact)contact);
        }

        public void Update(IContact contact)
        {
            _dal.Update((Contact)contact);
        }

        public void Delete(int contactId)
        {
            _dal.Delete(contactId);
        }

        public IList<IContact> GetContacts()
        {
            return new List<IContact>(_dal.GetContacts());
        }

        public void Dispose()
        {
            if(_dal != null)
            { 
                _dal.Dispose();
                _dal = null;
            }

            _contactsFactory = null;
        }

        #endregion
    }
}
