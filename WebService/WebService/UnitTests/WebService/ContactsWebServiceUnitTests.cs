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
            JsonResult addActionResult               = _controller.Add("TestAdd", "TestAdd", "TestAdd");
            ServiceResultBase addServiceResult = addActionResult.Data as ServiceResultBase;

            Assert.IsTrue(addServiceResult.Success);
        }

        [TestMethod]
        public void TestWebServiceUpdate()
        {
            JsonResult addActionResult          = _controller.Add("TestUpdate", "TestUpdate", "TestUpdate");
            ServiceResult<int> addServiceResult = addActionResult.Data as ServiceResult<int>;

            Assert.IsTrue(addServiceResult.Success);

            JsonResult updateActionResult         = _controller.Update(addServiceResult.Data, "Updated", "Updated", "Updated");
            ServiceResultBase updateServiceResult = updateActionResult.Data as ServiceResultBase;

            Assert.IsTrue(updateServiceResult.Success);
        }

        [TestMethod]
        public void TestWebServiceDelete()
        {
            JsonResult addActionResult          = _controller.Add("TestDelete", "TestDelete", "TestDelete");
            ServiceResult<int> addServiceResult = addActionResult.Data as ServiceResult<int>;

            Assert.IsTrue(addServiceResult.Success);

            JsonResult updateActionResult         = _controller.Delete(addServiceResult.Data);
            ServiceResultBase updateServiceResult = updateActionResult.Data as ServiceResultBase;

            Assert.IsTrue(updateServiceResult.Success);
        }

        [TestMethod]
        public void TestWebServiceGet()
        {
            JsonResult addActionResult          = _controller.Get();
            ServiceResultBase addServiceResult  = addActionResult.Data as ServiceResultBase;

            Assert.IsTrue(addServiceResult.Success);
        }

        #endregion

    }
}
