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
        private IGenericDAO<Client> _clientDao;
        public ClientDI(IGenericDAO<Client> clientDao)
        {
            _clientDao = clientDao;
        }

        public void Save(Client client)
        {
            _clientDao.Save(client);
        }

        public void Update(Client client)
        {
            _clientDao.Update(client);
        }

        public void Delete(Client client)
        {
            _clientDao.Delete(client);
        }

        public Client GetById(int id)
        {
            return new Client();
        }

        public int GetAllCount()
        {
            return 1;
        }

        public ICollection<Client> GetAll()
        {
            return new List<Client>();
        }
    }
}
