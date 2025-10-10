using Microsoft.AspNetCore.Mvc;
using OdemeSistemi.Business.Services;
using OdemeSistemi.Core.Entities;

namespace OdemeSistemi.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiparisController : ControllerBase
    {
        private readonly SiparisService _siparisService;
        // Constructor Injection: DI konteyneri, SiparisService'i otomatik olarak sağlar.
        public SiparisController(SiparisService siparisService)
        {
            _siparisService = siparisService;
        }
        [HttpPost]
        public IActionResult Post()
        {
            //1. Domain nesnesi oluştur
            var siparis = new Siparis { Tutar = 100M };
            Console.WriteLine("API: Sipariş alma isteği geldi");

            //2. Business mantığını başlat
            bool sonuc = _siparisService.OdemeIslemiBaslat(siparis);
            if (sonuc)
            {
                Console.WriteLine("API: Sipariş başarıyla işlendi.");
                return Ok(new { Message = "Ödeme başarılı", Tutar = siparis.Tutar });
            }
            else
            {
                Console.WriteLine("API: Ödeme başarısız oldu.");
                //400 Bad request veya uygun bir hata kodu döndürülür.
                return BadRequest(new { Message = "Ödeme işlemi başarısız oldu" });
            }    
        }
    }
}
