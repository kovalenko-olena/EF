using AvtoParkEF.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoParkEF
{
    internal class Program
    {
        private static int AddNewRecord()
        {
            // Добавить запись в таблицу FuelSpr базы данных AutoPark.
            using (var context = new AvtoParkEntities())
            {
                try
                {
                    // В целях тестирования жестко закодировать данные для новой записи,
                    var fuel = new FuelSpr()
                    {
                        Id = 2,
                        Cd = 2,
                        CdNm = "A95"
                    };
                    context.FuelSprs.Add(fuel);
                    context.SaveChanges();
                    // В случае успешного сохранения EF заполняет поле идентификатора
                    // значением, сгенерированным базой данных,
                    return fuel.Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                    return 0;
                }
            }
        }
        private static void PrintAllFuel()
        {
            using (var context = new AvtoParkEntities())
            {
                foreach (FuelSpr spr in context.FuelSprs.SqlQuery(
                "Select Id,Cd,CdNm from FuelSpr where Id>=1"))
                {
                    Console.WriteLine(spr);
                }
            }
        }

        private static void RemoveRecord(int fuelid)
        {
            // Найти запись об автомобиле, подлежащую удалению, по первичному ключу,
            using (var context = new AvtoParkEntities())
            {
                // Проверить наличие записи.
                FuelSpr fuelToDelete = context.FuelSprs.Find(fuelid);
                if (fuelToDelete != null)
                {
                    context.FuelSprs.Remove(fuelToDelete);
                    // Этот код предназначен чисто для демонстрации того,
                    // что состояние сущности изменилось на Deleted,
                    if (context.Entry(fuelToDelete).State != EntityState.Deleted)
                    {
                        throw new Exception("Unable to delete the record");
                    }
                    context.SaveChanges();
                }
            }
        }
        private static void RemoveRecordUsingEntityState(int fuelid, int fuelcd, string fuelnm)
        {
            using (var context = new AvtoParkEntities())
            {
                FuelSpr fuelToDelete = new FuelSpr() { Id = fuelid, Cd = fuelcd, CdNm = fuelnm };
                context.Entry(fuelToDelete).State = EntityState.Deleted;
                try
                {
                    context.SaveChanges();
                }

                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private static void UpdateRecord(int fuelid)
        {
            // Найти запись об автомобиле, подлежащую обновлению, по первичному ключу,
            using (var context = new AvtoParkEntities())
            {
                // Получить запись об автомобиле, обновить ее и сохранить!
                FuelSpr fuelToUpdate = context.FuelSprs.Find(fuelid);
                if (fuelToUpdate != null)
                {
                    Console.WriteLine(context.Entry(fuelToUpdate).State);
                    fuelToUpdate.CdNm = "A92";
                    Console.WriteLine(context.Entry(fuelToUpdate).State);
                    context.SaveChanges();
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with ADO.NET EF * ****\n");
            // Add new record
            int fuelid = AddNewRecord();
            //Console.WriteLine(fuelid);

            // Print all records
            PrintAllFuel();

            //Remove records
            //RemoveRecord(3);
            //RemoveRecordUsingEntityState(2, 2, "A95");

            Console.WriteLine();

            // Update record
            //UpdateRecord(1);

            Console.ReadLine();
        }
    }
}