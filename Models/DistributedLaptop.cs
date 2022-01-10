using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beci_Helga_Proiect.Models
{
    public class DistributedLaptop
    {
        public int DistributorID { get; set; }
        public int LaptopID { get; set; }
        public Distributor Distributor { get; set; }
        public Laptop Laptop { get; set; }
    }
}
