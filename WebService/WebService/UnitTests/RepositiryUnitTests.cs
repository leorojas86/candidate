using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IRepository;
using Repository;
using DataProject;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ContactsRepositoryUnitTests
    {
        #region Variables

        private IContactsRepository _testingRepository = RepositoryServiceLocator.Instance.GetRepository<MockContactsRepository>();

        #endregion

        [TestMethod]
        public void TestAdd()
        {
            int initialContactsCount = _testingRepository.GetContacts().Count;
            Contact newContact       = new Contact();
            int addCount             = 4;

            for(int i = 0; i < addCount; i++)
                _testingRepository.Add(newContact);

            Assert.AreEqual(_testingRepository.GetContacts().Count - initialContactsCount, addCount);
        }

        [TestMethod]
        public void TestUpdate()
        {
            int initialContactsCount = _testingRepository.GetContacts().Count;

            Contact newContact  = new Contact("Test", "Test", "Test");
            Contact newContact2 = new Contact("Test", "Test", "Test");
            Contact newContact3 = new Contact("Test", "Test", "Test");

            _testingRepository.Add(newContact);
            _testingRepository.Add(newContact2);
            _testingRepository.Add(newContact3);

            Contact editedContact = new Contact(newContact2.Id, "NewName", "NewEmail", "NewPhone");

            _testingRepository.Update(editedContact);

            IList<IContact> contacts = _testingRepository.GetContacts();

            Assert.AreEqual(contacts[initialContactsCount + 0].Name, "Test");
            Assert.AreEqual(contacts[initialContactsCount + 1].Name, "NewName");
            Assert.AreEqual(contacts[initialContactsCount + 1].Email, "NewEmail");
            Assert.AreEqual(contacts[initialContactsCount + 1].Phone, "NewPhone");
            Assert.AreEqual(contacts[initialContactsCount + 2].Phone, "Test");
        }

        [TestMethod]
        public void TestDelete()
        {
            int initialContactsCount = _testingRepository.GetContacts().Count;

            Contact newContact  = new Contact("Test", "Test", "Test");
            Contact newContact2 = new Contact("TestDelete", "TestDelete", "TestDelete");
            Contact newContact3 = new Contact("Test", "Test", "Test");

            _testingRepository.Add(newContact);
            _testingRepository.Add(newContact2);
            _testingRepository.Add(newContact3);

            _testingRepository.Delete(newContact2.Id);

            IList<IContact> contacts = _testingRepository.GetContacts();

            Assert.AreEqual(contacts.Count - initialContactsCount, 2);

            for (int i = 0; i < contacts.Count; i++)
                Assert.AreNotEqual(contacts[i].Name, "TestDelete");
        }
    }
}
