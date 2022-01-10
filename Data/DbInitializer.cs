using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beci_Helga_Proiect.Models;

namespace Beci_Helga_Proiect.Data
{
    public class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();
            if (context.Laptops.Any())
            {
                return; // BD a fost creata anterior
            }
            var laptops = new Laptop[]
            {
                new Laptop{Model="Inspiron15",Company="DELL",Price=Decimal.Parse("3902")},
                new Laptop{Model="Terbaru",Company="ASUS",Price=Decimal.Parse("2860")},
                new Laptop{Model="Radeon",Company="LENOVO",Price=Decimal.Parse("4807")},
                new Laptop{Model="Maxis",Company="LENOVO",Price=Decimal.Parse("5700")},
                new Laptop{Model="Xena",Company="MAC",Price=Decimal.Parse("8700")},
                new Laptop{Model="Jupiter",Company="ICE",Price=Decimal.Parse("4700")}
            };
            foreach (Laptop s in laptops)
            {
                context.Laptops.Add(s);
            }
            context.SaveChanges();
            var customers = new Customer[]
            {
                new Customer{CustomerID=1050,Name="Orzac Oana",BirthDate=DateTime.Parse("1979-09-01")},
                new Customer{CustomerID=1045,Name="Pop Liviu",BirthDate=DateTime.Parse("1969-07-08")},

};
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
            var orders = new Order[]
            {
                    new Order{LaptopID=31,CustomerID=1045,OrderDate=DateTime.Parse("02-25-2022")},
                    new Order{LaptopID=32,CustomerID=1050,OrderDate=DateTime.Parse("09-28-2022")},
                    new Order{LaptopID=33,CustomerID=1050,OrderDate=DateTime.Parse("10-28-2022")},
                    new Order{LaptopID=34,CustomerID=1045,OrderDate=DateTime.Parse("09-28-2022")},
                    new Order{LaptopID=35,CustomerID=1045,OrderDate=DateTime.Parse("09-28-2022")},
                    new Order{LaptopID=36,CustomerID=1050,OrderDate=DateTime.Parse("10-28-2022")},
            };
            foreach (Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();
            var distributors = new Distributor[]
     {
                new Distributor{DistributorName="Altex",Adress="Str. Aviatorilor, nr. 40, Bucuresti"},
                new Distributor{DistributorName="Media Galaxy",Adress="Str. Plopilor, nr. 35, Ploiesti"},
                new Distributor{DistributorName="Emag",Adress="Str. Cascadelor, nr. 22, Cluj-Napoca"},
             };
            foreach (Distributor d in distributors)
            {
                context.Distributors.Add(d);
            }
            context.SaveChanges();
            var distributedlaptops = new DistributedLaptop[]
            {
        new DistributedLaptop {
        LaptopID = laptops.Single(c => c.Model == "Jupiter" ).ID,
        DistributorID = distributors.Single(i => i.DistributorName == "Media Galaxy").ID
        },
        new DistributedLaptop {
        LaptopID = laptops.Single(c => c.Model == "Xena" ).ID,
        DistributorID = distributors.Single(i => i.DistributorName == "Media Galaxy").ID
        },
        new DistributedLaptop {
        LaptopID = laptops.Single(c => c.Model == "Maxis" ).ID,
        DistributorID = distributors.Single(i => i.DistributorName == "Emag").ID
        },
        new DistributedLaptop {
        LaptopID = laptops.Single(c => c.Model == "Radeon" ).ID,
        DistributorID = distributors.Single(i => i.DistributorName == "Altex").ID
        },
        new DistributedLaptop {
        LaptopID = laptops.Single(c => c.Model == "Terbaru" ).ID,
        DistributorID = distributors.Single(i => i.DistributorName == "Emag").ID
        },
        new DistributedLaptop {
        LaptopID = laptops.Single(c => c.Model == "Inspiron15" ).ID,
        DistributorID = distributors.Single(i => i.DistributorName == "Altex").ID
        },
};
            foreach (DistributedLaptop pb in distributedlaptops)
            {
                context.DistributedLaptops.Add(pb);
            }
            context.SaveChanges();
        }
    }
}