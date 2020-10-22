using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venezia.Utils;

namespace Venezia.Models
{
    public class Basket
    {
        public Dictionary<int, int> Cars { get; private set; } = new Dictionary<int, int>();

        public void AddCar(int idCar)
        {
            if (Cars.ContainsKey(idCar))
            {
                Cars[idCar]++;
            }
            else
            {
                Cars.Add(idCar, 1);
            }
        }

        public string ToJson()
        {
            //var entries = Cars.Select(x => string.Format("{0}:{1}", x.Key, x.Value));
            return "{\"Cars\":"+ Cars.ToJson()  +"}";
        }
    }
}
