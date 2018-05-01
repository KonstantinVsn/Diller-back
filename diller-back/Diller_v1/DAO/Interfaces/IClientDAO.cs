using Diller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.DAO.Interfaces
{
    public interface IClientDAO
    {
        void Save(Client client);

        void Update(Client client);

        void Delete(Client client);

        Client GetById(int id);

        int GetAllCount();

        ICollection<Client> GetAll();
    }
}
