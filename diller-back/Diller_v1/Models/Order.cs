using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Manager manager { get; set; }
        public Client client { get; set; }
        public int CarId { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Sum { get; set; }
    }
}
