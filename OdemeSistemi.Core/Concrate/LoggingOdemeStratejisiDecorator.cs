using OdemeSistemi.Core.Abstract;

namespace OdemeSistemi.Core.Concrate
{
    public class LoggingOdemeStratejisiDecorator : IOdemeStratejisi
    {
        private readonly IOdemeStratejisi _odemeStratejisi;
        public LoggingOdemeStratejisiDecorator(IOdemeStratejisi odemeStratejisi)
        {
            _odemeStratejisi = odemeStratejisi;
        }
        public bool OdemeYap(decimal tutar)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[LOG] İşlem Başladı: {DateTime.Now} - Tutar: {tutar} TL");
            Console.ResetColor();

            var sonuc = _odemeStratejisi.OdemeYap(tutar);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[LOG] İşlem Tamamlandı: {DateTime.Now} - Sonuç: {sonuc}");
            Console.ResetColor();

            return sonuc;
        }
    }
}