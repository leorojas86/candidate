using DataProject;
using IRepository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class RepositoryServiceLocator
    {
        #region Variables

        private Dictionary<Type, IContactsRepository> _repositories = new Dictionary<Type, IContactsRepository>();

        private static RepositoryServiceLocator _instance = null;

        #endregion

        #region Properties

        public static RepositoryServiceLocator Instance
        {
            get
            {
                if(_instance != null)
                    return _instance;

                _instance = new RepositoryServiceLocator();
                return _instance;
            }
        }

        #endregion

        #region Constructors

        private RepositoryServiceLocator()
        {
            _repositories.Add(typeof(MockContactsRepository), new MockContactsRepository());
            _repositories.Add(typeof(DatabaseContactsRepository), new DatabaseContactsRepository());
        }

        #endregion

        #region Methods

        public IContactsRepository GetRepository<T>() where T : IContactsRepository
        {
            return _repositories[typeof(T)];
        }

        #endregion
    }
}
