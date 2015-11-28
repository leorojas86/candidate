using DataProject;
using IRepository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Index()
        {
            //IContact newContact = _repository.Factory.CreateContact("Test", "Test", "Test");
            //_repository.Add(newContact);

            return Json(_repository.GetContacts(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
