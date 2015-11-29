using DataProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace UnitTests
{
    [TestClass]
    public class MockContactsWebServiceUnitTests : ContactsWebServiceUnitTests
    {
        #region Contructors

        public MockContactsWebServiceUnitTests() : base(new ContactsController(new MockContactsRepository()))
        {
        }

        #endregion
    }
}
