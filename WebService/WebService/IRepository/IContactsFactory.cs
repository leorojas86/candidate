using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IContactsFactory
    {
        #region Methods

        IContact CreateContact(string name = null, string email = null, string phone = null);

        #endregion
    }
}
