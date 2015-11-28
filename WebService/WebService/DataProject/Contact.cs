using IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject
{
    public class Contact : IContact
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        #endregion

        #region Constructors

        public Contact()
        {

        }

        public Contact(string name, string email, string phone)
        {
            Name    = name;
            Email   = email;
            Phone   = phone;
        }

        public Contact(int id, string name, string email, string phone) : this(name, email, phone)
        {
            Id = id;
        }

        #endregion
    }
}
