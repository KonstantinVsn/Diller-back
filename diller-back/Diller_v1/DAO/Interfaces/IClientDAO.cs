using Diller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.DAO.Interfaces
{
    public interface IClientDAO
    {
        void Save(Person client);

        void Update(Person client);

        void Delete(Person client);

        Person GetById(int id);

        int GetAllCount();

        ICollection<Person> GetAll();
    }
}
