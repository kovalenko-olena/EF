using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoParkEF.EF
{
    public partial class FuelSpr:IDisposable
    {
        public void Dispose()
        {
            
        }
        /*public void GetAll()
        {
           ToString();
        }*/
        public override string ToString()
        {
            return $"Id={this.Id} \t Cd={this.Cd} \t CdNm={this.CdNm}";
        }

    }
}
