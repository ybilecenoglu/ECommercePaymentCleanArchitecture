using OdemeSistemi.Core.Abstract;
namespace OdemeSistemi.Data.Concrate
{
    public class KrediKartiOdeme : IOdemeStratejisi
    {
        public bool OdemeYap(decimal tutar)
        {
            System.Console.WriteLine($"Infrastructure: Kredi Kartı ile {tutar} TL ödeme yapıldı.");
            return true;
        }
    }
}