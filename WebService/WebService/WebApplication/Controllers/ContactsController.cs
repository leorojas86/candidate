﻿using DataProject;
using IRepository;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ContactsController : Controller//TODO: This can be implemented inheriting from ApiController
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

        private ActionResult GetExceptionActionResult(Exception e)
        {
            return Json(new ServiceResult<string>(false, e.ToString(), e.Message), JsonRequestBehavior.AllowGet);
        }

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
                return Json(new ServiceResult<IList<IContact>>(true, _repository.GetContacts(), null), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return GetExceptionActionResult(e);
            }
        }

        // GET: Contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Json(new ServiceResult<String>(true, "Contact has been deleted", null));
            }
            catch (Exception e)
            {
                return GetExceptionActionResult(e);
            }
        }

        // GET: Contacts/Add/Name/Email/Phone
        [HttpPost]
        public ActionResult Add(string name, string email, string phone)
        {
            try
            {
                IContact newContact = _repository.Factory.CreateContact(name, email, phone);
                _repository.Add(newContact);

                return Json(new ServiceResult<String>(true, "New contact has been added", null));
            }
            catch (Exception e)
            {
                return GetExceptionActionResult(e);
            }
        }

        // POST: Contacts/Update/Id/Name/Email/Phone
        [HttpPost]
        public ActionResult Update(int id, string name, string email, string phone)
        {
            try
            {
                IContact contact = _repository.Factory.CreateContact(name, email, phone);
                contact.Id = id;
                _repository.Update(contact);

                return Json(new ServiceResult<String>(true, "Contact has been updated", null));
            }
            catch (Exception e)
            {
                return GetExceptionActionResult(e);
            }
        }

        #endregion
    }
}
