E-Ticaret Ödeme Sistemi (Katmanlı Mimari ve Tasarım Desenleri Uygulaması)
Bu proje, bir e-ticaret platformunun ödeme işleme akışını simüle eden, ASP.NET Core tabanlı bir Web API uygulamasıdır. Temel amaç, bir iş problemini çözerken Clean/Onion Architecture ve SOLID prensiplerini uygulamaktır.

Bu proje, mimari tasarım desenleri (Strategy, Factory) ve Bağımlılık Enjeksiyonu (DI) konularındaki yetkinliği göstermektedir.

🏗 Mimari Yapı ve Katmanlar
[OdemeSistemi].Api	HTTP isteklerini yönetir (Controller).	Tüm katmanlara erişir.	Presentation (Sunum)
[OdemeSistemi].Business	Uygulamanın İş Akışını (Business Logic) içerir.	Domain katmanına.	Business/Service
[OdemeSistemi].Data	Domain'deki arayüzlerin somut uygulamalarını içerir (Veritabanı, Dış Servisler).	Domain katmanına.	Implementation
[OdemeSistemi].Core	Uygulamanın en temel iş nesneleri (Entities) ve arayüzler (Interfaces).	Hiçbir şeye bağımlı değildir.	Core (Çekirdek)

🎯 Uygulanan Temel Prensipler ve Desenler
Projenin temel gücü, kullanılan mimari yaklaşımlardan gelmektedir:

1. SOLID Prensibi ve Bağımlılık Enjeksiyonu (DI)
Dependency Inversion Principle (DIP): Yüksek seviyeli modüller (SiparisService), düşük seviyeli modüllere (KrediKartiOdeme) değil, Soyutlamalara (IOdemeStratejisi) bağımlıdır.

Bağımlılık Enjeksiyonu (DI): Tüm bağımlılıklar (SiparisService ve IOdemeStratejisi) ASP.NET Core'un yerleşik DI konteyneri aracılığıyla, Program.cs'te (Composition Root) yapılandırılmıştır. Bu, Controller'ın somut sınıfları bilmeden çalışmasını sağlar.

2. Strategy Deseni
Amaç: Farklı ödeme yöntemlerini (Kredi Kartı, EFT vb.) birbirinden izole etmek ve dinamik olarak değiştirebilmek.

IOdemeStratejisi arayüzü, tüm ödeme tiplerinin ortak sözleşmesidir. SiparisService, hangi stratejinin kullanıldığına bakılmaksızın OdemeYap() metodunu çağırır.

3. Builder Deseni (Önceki Pratikten)
Amaç: Karmaşık nesne oluşturma süreçlerini (örneğin bir Rapor veya Email nesnesi) adım adım yönetmek ve nesnenin tutarlılığını garantilemek.

🚀 Başlangıç ve Test Etme
Bu API, yerel bir geliştirme ortamında Swagger UI ile test edilebilir.

Gerekli Adımlar
Proje klasörüne gidin ve dotnet run komutunu çalıştırın.

Konsolda çıkan HTTPS adresini (https://localhost:XXXX) tarayıcınızda açın.

Swagger UI Adresi: Tarayıcıda https://localhost:XXXX/swagger adresini ziyaret edin.

Test: Siparis Controller'ı altında bulunan POST /api/Siparis uç noktasını kullanarak bir istek gönderin.

Beklenen Sonuç: Konsolda Infrastructure: Kredi Kartı ödemesi yapıldı. mesajını görmeli ve API'den 200 OK cevabını almalısınız.