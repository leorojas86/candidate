﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IContactsRepository
    {
        void Add(IContact newContact);

        void Update(IContact contact);

        void Delete(IContact contact);

        IList<IContact> GetContacts();
    }
}
