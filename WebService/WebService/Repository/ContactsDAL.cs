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
        public DbSet<Contact> Contacts { get; set; }
    }
}
