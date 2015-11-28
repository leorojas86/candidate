using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class DatabaseContactsRepositoryUnitTests : RepositoryUnitTests
    {
        #region Constructors

        public DatabaseContactsRepositoryUnitTests():base(new DatabaseContactsRepository())
        {
        }

        #endregion
    }
}
