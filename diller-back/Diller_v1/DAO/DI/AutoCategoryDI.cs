using Diller.DAO.Interfaces;
using Diller.Data;
using Diller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller_v1.DAO.DI
{
    public class ClientDI
    {
        private IGenericDAO<Person> _clientDao;
        public ClientDI(IGenericDAO<Person> clientDao)
        {
            _clientDao = clientDao;
        }

        public void Save(Person client)
        {
            _clientDao.Save(client);
        }

        public void Update(Person client)
        {
            _clientDao.Update(client);
        }

        public void Delete(Person client)
        {
            _clientDao.Delete(client);
        }

        public Person GetById(int id)
        {
            return new Person();
        }

        public int GetAllCount()
        {
            return 1;
        }

        public ICollection<Person> GetAll()
        {
            return new List<Person>();
        }
    }
}
