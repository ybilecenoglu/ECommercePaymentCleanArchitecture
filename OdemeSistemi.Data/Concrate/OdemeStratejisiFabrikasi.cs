using OdemeSistemi.Core.Abstract;
using OdemeSistemi.Core.Enum;
using Microsoft.Extensions.DependencyInjection;
namespace OdemeSistemi.Data.Concrate
{
    public class OdemeStratejisiFabrikasi : IOdemeStratejisiFabrikasi
    {
        //ServiceProvider'ı cunstructor'da alarak gevşek bağlılığı koruyoruz.
        private readonly IServiceProvider  _serviceProvider;

        public OdemeStratejisiFabrikasi(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IOdemeStratejisi GetOdemeStratejisi(OdemeTipi tip)
        {
            return tip switch
            {
                OdemeTipi.KK => _serviceProvider.GetRequiredService<KrediKartiOdeme>(),
                OdemeTipi.EFT => _serviceProvider.GetRequiredService<EftOdeme>()
            };
        }
    }
}
