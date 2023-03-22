using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvtoParkCreateDB.Models;

namespace AvtoParkCreateDB.EF
{
    public class MyDatalnitializer : DropCreateDatabaseAlways<AvtoParkEntities>
    {
        protected override void Seed(AvtoParkEntities context)
        {
            base.Seed(context);
            var fuel = new List<FuelSpr>
            {
                new FuelSpr{Id=1, Cd=1, CdNm="A92"},
                new FuelSpr{Id=2, Cd=2, CdNm="A95"},
            };


            fuel.ForEach(x => context.FuelSprs.AddOrUpdate(c => new { c.Id, c.Cd, c.CdNm }, x));
        }
    }
}
