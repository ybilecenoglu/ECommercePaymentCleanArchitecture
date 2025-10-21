using OdemeSistemi.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdemeSistemi.Data.Concrate
{
    public class EftOdeme : IOdemeStratejisi
    {
        public bool OdemeYap(decimal tutar)
        {
            Console.WriteLine("Eft ödemesi yapıldı.");
            return true;
        }
    }
}
