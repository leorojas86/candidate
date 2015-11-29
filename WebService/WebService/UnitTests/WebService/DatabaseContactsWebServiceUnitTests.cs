using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace UnitTests
{
    [TestClass]
    public class DatabaseContactsWebServiceUnitTests : ContactsWebServiceUnitTests
    {
        #region Contructors

        public DatabaseContactsWebServiceUnitTests():base(new ContactsController(new DatabaseContactsRepository()))
        {
        }

        #endregion
    }
}
