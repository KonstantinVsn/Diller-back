using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Sum { get; set; }
    }
}
