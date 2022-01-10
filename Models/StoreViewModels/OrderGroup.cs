using System;
using System.ComponentModel.DataAnnotations;

namespace Beci_Helga_Proiect.Models.StoreViewModels
{  
        public class OrderGroup
        {
            [DataType(DataType.Date)]
            public DateTime? OrderDate { get; set; }
            public int LaptopCount { get; set; }
        }
    }

