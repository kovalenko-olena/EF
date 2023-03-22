using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvtoParkCreateDB.EF;
using AvtoParkCreateDB.Models;

namespace AvtoParkTestDrive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MyDatalnitializer());
            Console.WriteLine("database creation and table filling");
            using (var context = new AvtoParkEntities())
            {
                foreach (FuelSpr c in context.FuelSprs)
                {
                    Console.WriteLine(c);
                }
            }
            Console.WriteLine("database creation and table filling completed");
            Console.ReadLine();
        }
    }
}
