using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Venezia.Models
{
    public class BasketViewModel
    {
        public decimal Total { get; set; }
        public Dictionary<Car, int> Cars { get; set; } = new Dictionary<Car, int>();
        //public List<CarQt> Cars { get; set; } = new List<CarQt>();
    }

    public class CarQt
    {
        public Car Car { get; set; }
        public int Count { get; set; }
    }
}
