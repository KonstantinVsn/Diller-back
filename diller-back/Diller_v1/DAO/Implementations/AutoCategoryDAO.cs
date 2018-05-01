using Diller.DAO.Interfaces;
using Diller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.DAO.Implementations
{
    public class AutoCategoryDAO : IGenericDAO<AutoCategory>
    {
        public void Save(AutoCategory employer)
        {

        }

        public void Update(AutoCategory employer)
        {

        }

        public void Delete(AutoCategory employer)
        {

        }

        public AutoCategory GetById(int id)
        {
            return new AutoCategory();
        }

        public int GetAllCount()
        {
            return 1;
        }

        public ICollection<AutoCategory> GetAll()
        {
            return new List<AutoCategory>();
        }
    }
}
