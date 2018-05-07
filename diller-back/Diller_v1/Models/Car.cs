using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string EnVolume { get; set; }
        public int MaxSpeed { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public int Year { get; set; }
        public AutoBrand Brand { get; set; }
        public AutoCategory Category { get; set; }
    }
}
