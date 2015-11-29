using IRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication.Controllers;
using WebApplication.Models;

namespace UnitTests
{
    [TestClass]
    public abstract class ContactsWebServiceUnitTests
    {
        #region Variables

        public ContactsController _controller = null;

        #endregion

        #region Constructors

        public ContactsWebServiceUnitTests(ContactsController controller)
        {
            _controller = controller;
        }

        #endregion

        #region Methods

        [TestMethod]
        public void TestWebServiceAdd()
        {
            JsonResult addActionResult               = _controller.Add("TestAdd", "TestAdd", "TestAdd") as JsonResult;
            ServiceResult<IContact> addServiceResult = addActionResult.Data as ServiceResult<IContact>;

            Assert.IsTrue(addServiceResult.Success);

            /*int initialContactsCount = _controller.Get();
            IContact newContact = _repository.Factory.CreateContact();
            int addCount = 4;

            for (int i = 0; i < addCount; i++)
                _repository.Add(newContact);

            Assert.AreEqual(_repository.GetContacts().Count - initialContactsCount, addCount);*/
        }

        [TestMethod]
        public void TestWebServiceUpdate()
        {
            JsonResult addActionResult               = _controller.Add("TestUpdate", "TestUpdate", "TestUpdate") as JsonResult;
            ServiceResult<IContact> addServiceResult = addActionResult.Data as ServiceResult<IContact>;

            Assert.IsTrue(addServiceResult.Success);

            JsonResult updateActionResult               = _controller.Update(addServiceResult.Data.Id, "Updated", "Updated", "Updated") as JsonResult;
            ServiceResult<string> updateServiceResult   = updateActionResult.Data as ServiceResult<string>;

            Assert.IsTrue(updateServiceResult.Success);
        }

        [TestMethod]
        public void TestWebServiceDelete()
        {
            JsonResult addActionResult = _controller.Add("TestDelete", "TestDelete", "TestDelete") as JsonResult;
            ServiceResult<IContact> addServiceResult = addActionResult.Data as ServiceResult<IContact>;

            Assert.IsTrue(addServiceResult.Success);

            JsonResult updateActionResult = _controller.Delete(addServiceResult.Data.Id) as JsonResult;
            ServiceResult<string> updateServiceResult = updateActionResult.Data as ServiceResult<string>;

            Assert.IsTrue(updateServiceResult.Success);
        }

        #endregion

    }
}
