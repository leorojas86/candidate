using IRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public abstract class ContactsRepositoryUnitTests : IDisposable
    {
        #region Variables

        private IContactsRepository _repository = null;

        #endregion

        #region Constructors

        public ContactsRepositoryUnitTests(IContactsRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        [TestMethod]
        public void TestRepositoryAdd()
        {
            int initialContactsCount    = _repository.GetContacts().Count;
            IContact newContact         = _repository.Factory.CreateContact();
            int addCount                = 4;

            for (int i = 0; i < addCount; i++)
                _repository.Add(newContact);

            Assert.AreEqual(_repository.GetContacts().Count - initialContactsCount, addCount);
        }

        [TestMethod]
        public void TestRepositoryUpdate()
        {
            int initialContactsCount = _repository.GetContacts().Count;

            IContact newContact  = _repository.Factory.CreateContact("Test", "Test", "Test");
            IContact newContact2 = _repository.Factory.CreateContact("Test", "Test", "Test");
            IContact newContact3 = _repository.Factory.CreateContact("Test", "Test", "Test");

            _repository.Add(newContact);
            _repository.Add(newContact2);
            _repository.Add(newContact3);

            IContact editedContact = _repository.Factory.CreateContact("NewName", "NewEmail", "NewPhone");
            editedContact.Id       = newContact2.Id;

            _repository.Update(editedContact);

            IList<IContact> contacts = _repository.GetContacts();

            Assert.AreEqual(contacts[initialContactsCount + 0].Name, "Test");
            Assert.AreEqual(contacts[initialContactsCount + 1].Name, "NewName");
            Assert.AreEqual(contacts[initialContactsCount + 1].Email, "NewEmail");
            Assert.AreEqual(contacts[initialContactsCount + 1].Phone, "NewPhone");
            Assert.AreEqual(contacts[initialContactsCount + 2].Phone, "Test");
        }

        [TestMethod]
        public void TestRepositoryDelete()
        {
            int initialContactsCount = _repository.GetContacts().Count;

            IContact newContact = _repository.Factory.CreateContact("Test", "Test", "Test");
            IContact newContact2 = _repository.Factory.CreateContact("TestDelete", "TestDelete", "TestDelete");
            IContact newContact3 = _repository.Factory.CreateContact("Test", "Test", "Test");

            _repository.Add(newContact);
            _repository.Add(newContact2);
            _repository.Add(newContact3);

            _repository.Delete(newContact2.Id);

            IList<IContact> contacts = _repository.GetContacts();

            Assert.AreEqual(contacts.Count - initialContactsCount, 2);

            for (int i = 0; i < contacts.Count; i++)
                Assert.AreNotEqual(contacts[i].Name, "TestDelete");
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        #endregion
    }
}
