using OdemeSistemi.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdemeSistemi.Core.Abstract
{
    public interface IOdemeStratejisiFabrikasi
    {
        IOdemeStratejisi GetOdemeStratejisi(OdemeTipi tip);
    }
}
