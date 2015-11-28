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

        // GET: GetContacts
        [HttpGet]
        public ActionResult GetContacts()
        {
            return GetContactsJSONResult();
        }

        private JsonResult GetContactsJSONResult()
        {
            try
            {
                return Json(new ServiceResult<IList<IContact>>(true, _repository.GetContacts()), JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new ServiceResult<String>(false, e.Message), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        // GET: Contacts/Delete/5
        //[HttpDelete], TODO: should this be delete????
        //[HttpPost]
        [HttpGet]
        public ActionResult DeleteContact(int id)
        {
            return GetDeleteContactJSONResult(id);
        }

        private JsonResult GetDeleteContactJSONResult(int id)
        {
            try
            {
                _repository.Delete(id);
                return Json(new ServiceResult<IList<IContact>>(true, _repository.GetContacts()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new ServiceResult<String>(false, e.Message), JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
