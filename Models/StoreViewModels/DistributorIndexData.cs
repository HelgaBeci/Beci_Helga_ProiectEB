using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beci_Helga_Proiect.Models.StoreViewModels
{
    public class DistributorIndexData
    {
        public IEnumerable<Distributor> Distributors { get; set; }
        public IEnumerable<Laptop> Laptops { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
