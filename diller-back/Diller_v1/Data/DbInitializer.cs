﻿using Diller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext appContext)
        {
//            appContext.Database.EnsureCreated();
//            if (appContext.Manager.Any())
//            {
//                return;
//            }
//            var managers = new Manager[]
//            {
//                new Manager{ Email = "qwe@q.com", Name= "test tester", Phone="+3809313911" },
//                new Manager{ Email = "zzz@.z.zzz", Name = "test zeer", Phone="+3903003003" },
//                new Manager{ Email = "xxx@x.x", Name = "ooo qwewqe", Phone="+2132133333"}
//            };

//            foreach (var m in managers)
//            {
//                appContext.Manager.Add(m);
//            }
//            appContext.SaveChanges();

//            var autobrands = new AutoBrand[]
//            {
//                new AutoBrand{Name="Mazda" },
//                new AutoBrand{Name="Toyota" },
//                new AutoBrand{Name="Honda" },
//                new AutoBrand{Name="Infinity" }
//            };

//            foreach (var brand in autobrands)
//            {
//                appContext.AutoBrand.Add(brand);
//            }
//            appContext.SaveChanges();

//            var autoCategory = new AutoCategory[]
//            {
//                new AutoCategory{Name="Sidan"},
//                new AutoCategory{Name="Jip"},
//                new AutoCategory{ Name = "PickUp"}
//            };

//            foreach (var category in autoCategory)
//            {
//                appContext.AutoCategory.Add(category);
//            }
//            appContext.SaveChanges();

//            var clients = new Client[]
//{
//                new Client{ Email = "cqwe@q.com", Name= "ctest tester", Phone="+3809313911" },
//                new Client{ Email = "czzz@.z.zzz", Name = "ctest zeer", Phone="+3903003003" },
//                new Client{ Email = "cxxx@x.x", Name = "cooo qwewqe", Phone="+2132133333"}
//        };

//            foreach (var c in clients)
//            {
//                appContext.Client.Add(c);
//            }
//            appContext.SaveChanges();

//            var order = new Order
//            {
//                CarId = 1,
//                client = new Client { Email = "qwe@q.com", Name = "test tester", Phone = "+3809313911" },
//                CreateDate = new DateTime(),
//                manager = new Manager { Email = "qwe@q.com", Name = "test tester", Phone = "+3809313911" },
//                Sum = 1123
//            };
//            appContext.SaveChanges();
        }
    }
}
