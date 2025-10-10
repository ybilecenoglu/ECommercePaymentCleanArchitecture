using OdemeSistemi.Core.Abstract;
using OdemeSistemi.Core.Entities;
namespace OdemeSistemi.Business.Services
{
    public class SiparisService
    {
        private readonly IOdemeStratejisi _odemeStratejisi;
        public SiparisService(IOdemeStratejisi odemeStratejisi)
        {
            _odemeStratejisi = odemeStratejisi;
        }
        public bool OdemeIslemiBaslat(Siparis siparis)
        {
           return _odemeStratejisi.OdemeYap(siparis.Tutar);
        }
    }
}