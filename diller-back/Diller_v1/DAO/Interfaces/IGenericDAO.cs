using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.DAO.Interfaces
{
    public interface IGenericDAO<T>
    {
        void Save(T employer);

        void Update(T employer);

        void Delete(T employer);

        T GetById(int id);

        int GetAllCount();

        ICollection<T> GetAll();

    }
}
