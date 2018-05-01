
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
        private readonly DillerContext _context;

        public ClientDAO(DillerContext context)
        {
            _context = context;
        }
        public void Save( Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();

        }

        public void Update( Client client)
        {
            _context.SaveChanges();
        }

        public void Delete( Client client)
        {
            _context.Client.Remove(client);
            _context.SaveChanges();

        }

        public  Client GetById(int id)
        {
            return _context.Client.SingleOrDefault(e => e.Id == id);
        }

        public int GetAllCount()
        {
            return _context.Client.Count();
        }

        public ICollection< Client> GetAll()
        {
            return _context.Client.ToList();
        }
    }
}
