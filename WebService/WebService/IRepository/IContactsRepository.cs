using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IContactsRepository<T> where T : IContact
    {
        #region Methods

        void Add(T contact);

        void Update(T contact);

        void Delete(int contactId);

        IList<T> GetContacts();

        //TODO: This functions can be implemented to provide functionality to handle pages when there is 
        //a big number of contacts and also to make requests faster by retrieving only a fixed amount of contacts
        //int GetContactsPages(int pageSize);
        //IList<IContact> GetContacts(int pageIndex);

        #endregion
    }
}
