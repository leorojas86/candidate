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
        //Data Source=.\SQLExpress;Initial Catalog=Contacts;Integrated Security=True;   
        //Data Source=LEO_0399\SQLEXPRESS;User ID=sa;Password=pass;Initial Catalog=Contacts;Integrated Security=True
        //Data Source=.\SQLExpress;Initial Catalog=Contacts;Integrated Security=True;
        //base("name=SQLExpress")
        public ContactsDAL()
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
