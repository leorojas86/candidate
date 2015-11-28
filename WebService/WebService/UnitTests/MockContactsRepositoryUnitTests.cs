using DataProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class MockContactsRepositoryUnitTests : ContactsRepositoryUnitTests
    {
        #region Constructors

        public MockContactsRepositoryUnitTests() : base(new MockContactsRepository())
        {
        }

        #endregion
    }
}
