using OdemeSistemi.Core.Abstract;
using OdemeSistemi.Core.Enum;
namespace OdemeSistemi.Business.Services
{
    public class SiparisService
    {
       
        private readonly IOdemeStratejisiFabrikasi _odemeStratejisiFabrikasi;

        public SiparisService(IOdemeStratejisiFabrikasi odemeStratejisiFabrikasi)
        {
            _odemeStratejisiFabrikasi = odemeStratejisiFabrikasi;
        }
        public IOdemeStratejisi OdemeIslemiBaslat(OdemeTipi odemeTipi)
        {
            var odeme_stratejisi_fabrikasi =  _odemeStratejisiFabrikasi.GetOdemeStratejisi(odemeTipi);
            return odeme_stratejisi_fabrikasi;
        }
    }
}