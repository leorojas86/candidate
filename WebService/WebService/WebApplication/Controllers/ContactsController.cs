using DataProject;
using IRepository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ContactsController : Controller
    {
        #region Variables

        private IContactsRepository _repository = null;

        #endregion

        #region Constructors

        public ContactsController(IContactsRepository repository)
        {
            _repository = repository;
        }

        /*public ContactsController() : this(new MockContactsRepository())
        {
        }*/

        public ContactsController() : this(new DatabaseContactsRepository())
        {
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

        #region Actions

        // GET: Contacts/Get
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Json(new ServiceResult<IList<IContact>>(true, _repository.GetContacts()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new ServiceResult<String>(false, e.Message), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        // GET: Contacts/Delete/5
        //[HttpDelete], TODO: should this be delete????
        [HttpPost]
        //[HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Json(new ServiceResult<String>(true, "Contact has been deleted")/*, JsonRequestBehavior.AllowGet*/);
            }
            catch (Exception e)
            {
                return Json(new ServiceResult<String>(false, e.Message)/*, JsonRequestBehavior.AllowGet*/);
            }
        }

        // GET: Contacts/Add/Name/Email/Phone
        //[HttpPost]
        [HttpPost]
        //[HttpGet]
        public ActionResult Add(string name, string email, string phone)
        {
            try
            {
                IContact newContact = _repository.Factory.CreateContact(name, email, phone);
                _repository.Add(newContact);

                return Json(new ServiceResult<String>(true, "New contact has been added")/*, JsonRequestBehavior.AllowGet*/);
            }
            catch (Exception e)
            {
                return Json(new ServiceResult<String>(false, e.Message)/*, JsonRequestBehavior.AllowGet*/);
            }
        }

        // POST: Contacts/Update/Id/Name/Email/Phone
        [HttpPost]
        //[HttpGet]
        public ActionResult Update(int id, string name, string email, string phone)
        {
            try
            {
                IContact contact = _repository.Factory.CreateContact(name, email, phone);
                contact.Id = id;
                _repository.Update(contact);

                return Json(new ServiceResult<String>(true, "Contact has been updated")/*, JsonRequestBehavior.AllowGet*/);
            }
            catch (Exception e)
            {
                return Json(new ServiceResult<String>(false, e.Message)/*, JsonRequestBehavior.AllowGet*/);
            }
        }
    }
}
