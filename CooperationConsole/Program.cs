using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateDb();
            Console.WriteLine("Algus on võimas");
            Console.ReadLine();
        }

        static void GenerateDb()
        {
            using (CooperationContext coopDb = new CooperationContext())
            {
                var newHouse = new Domain.House()
                {
                    County = "Harjumaa",
                    City = "Tallinn",
                    Street = "Sytiste tee",
                    HouseNo = 41,
                    ZipCode = 13414
                };
                coopDb.Houses.Add(newHouse);
                coopDb.SaveChanges();
            }
        }
    }
}
