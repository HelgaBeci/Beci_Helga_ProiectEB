using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Beci_Helga_Proiect.Models
{
    public class Distributor
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Distributor Name")]
        [StringLength(50)]
        public string DistributorName { get; set; }
        [StringLength(70)]
        public string Adress { get; set; }
        public ICollection<DistributedLaptop> DistributedLaptops { get; set; }
    }
}
