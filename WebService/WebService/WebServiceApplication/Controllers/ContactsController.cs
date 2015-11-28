using DataProject;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceApplication.Models;

namespace WebServiceApplication.Controllers
{
    public class ContactsController : ApiController
    {
        #region Variables

        private IContactsRepository _repository = null;

        #endregion

        #region Constructors

        public ContactsController(IContactsRepository repository)
        {
            _repository = repository;
        }

        public ContactsController() : this(new MockContactsRepository())
        {
        }

        /*public ContactsController() : this(new DatabaseContactsRepository())
        {
        }*/

        #endregion

        #region ApiMethods

        // GET api/contacts
        public ServiceResult<IList<IContact>> Get()
        {
            try
            {
                return new ServiceResult<IList<IContact>>(true, _repository.GetContacts());
            }
            catch (Exception e)
            {
                return new ServiceResult<IList<IContact>>(false, null, e.Message);
            }
        }

        // PUT api/values/5
        public ServiceResult<String> Put(string name, string email, string phone)
        {
            try
            {
                IContact newContact = _repository.Factory.CreateContact(name, email, phone);
                _repository.Add(newContact);

                return new ServiceResult<String>(true, "New contact has been added");
            }
            catch (Exception e)
            {
                return new ServiceResult<String>(false, null, e.Message);
            }
        }

        // POST api/contacts
        public ServiceResult<String> Post(int id, string name, string email, string phone)
        {
            try
            {
                IContact contact    = _repository.Factory.CreateContact(name, email, phone);
                contact.Id          = id;
                _repository.Update(contact);

                return new ServiceResult<String>(true, "Contact has been updated");
            }
            catch (Exception e)
            {
                return new ServiceResult<String>(false, e.Message);
            }
        }

        // DELETE api/contacts/5
        public ServiceResult<String> Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return new ServiceResult<String>(true, "Contact has been deleted");
            }
            catch (Exception e)
            {
                return new ServiceResult<String>(false, null, e.Message);
            }
        }

        #endregion

        #region Methods

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if(disposing)
            {
                if(_repository != null)
                {
                    _repository.Dispose();
                    _repository = null;
                }
            }
        }

        #endregion 
    }
}
