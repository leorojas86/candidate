using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject
{
    public class ContactsFactory : IContactsFactory
    {
        #region Methods

        public IContact CreateContact(string name, string email, string phone)
        {
            return new Contact(name, email, phone);
        }

        #endregion
    }
}
