using DataProject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactsDAL : DbContext
    {
        #region Properties

        public DbSet<Contact> Contacts { get; set; }

        #endregion

        #region Constructors

        public ContactsDAL()
            : base(@"Data Source=LEO_0399\SQLEXPRESS;Initial Catalog=Contacts;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")//base("name=SQLExpress")
        {
        }

        #endregion

        #region Methods

        public void Add(Contact contact)
        {
            Contacts.Add(contact);
            SaveChanges();
        }

        public void Update(Contact contact)
        {
            //Contact instante can be different than the coresponding instance in the DbContext
            Contact dbContact   = Contacts.Find(contact.Id);
            dbContact.Name      = contact.Name;
            dbContact.Email     = contact.Email;
            dbContact.Phone     = contact.Phone;

            SaveChanges();
        }

        public void Delete(int contactId)
        {
            //Contact instante can be different than the coresponding instance in the DbContext
            Contact dbContact = Contacts.Find(contactId);
            Contacts.Remove(dbContact);
            SaveChanges();
        }

        public List<Contact> GetContacts()
        {
            return Contacts.ToList();
        }

        #endregion
    }
}
