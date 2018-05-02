
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diller.DAO.Interfaces;
using Diller.Data;
using Diller.Models;

namespace Diller.DAO.Implementations
{
    public class ClientDAO : IClientDAO
    {
        private readonly ApplicationDbContext _context;

        public ClientDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save(Person client)
        {
            _context.Persons.Add(client);
            _context.SaveChanges();

        }

        public void Update(Person client)
        {
            _context.SaveChanges();
        }

        public void Delete(Person client)
        {
            _context.Persons.Remove(client);
            _context.SaveChanges();

        }

        public Person GetById(int id)
        {
            return _context.Persons.SingleOrDefault(e => e.Id == id);
        }

        public int GetAllCount()
        {
            return _context.Persons.Count();
        }

        public ICollection<Person> GetAll()
        {
            return _context.Persons.ToList();
        }
    }
}
