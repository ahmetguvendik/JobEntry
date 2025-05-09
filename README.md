JobEntry

JobEntry, iş başvurularını ve ilanlarını yönetmek için geliştirilen bir web tabanlı uygulamadır. Proje, modern yazılım mimarileri ve teknolojileri kullanılarak yapılandırılmıştır.

Özellikler

Modüler Mimari: Core, Infrastructure ve Presentation katmanlarına ayrılmıştır.
Web API: RESTful servisler ile veri alışverişi sağlar.
Frontend: HTML, SCSS, CSS ve JavaScript kullanılarak geliştirilmiştir.
Veri Katmanı: Onion Arch.

Proje Yapısı:
JobEntry/
├── Core/
├── Infrastructure/
│   └── JobEntry.Persistance/
├── Presentation/
│   └── JobEntry.WebAPI/
├── Frontend/
├── .gitattributes
└── .DS_Store
Core: Uygulamanın temel iş mantığı ve modellerini içerir.
Infrastructure: Veri erişimi ve dış servis entegrasyonlarını barındırır.
Presentation: API katmanını ve kullanıcı arayüzünü sunar.
Frontend: Kullanıcı arayüzünün tasarlandığı ve geliştirildiği bölümdür.
Kullanılan Teknolojiler

Backend: C# (.NET)
Frontend: HTML, SCSS, CSS, JavaScript
Veri Tabanı: Henüz belirtilmemiştir.
Kurulum

Projeyi klonlayın:
git clone https://github.com/ahmetguvendik/JobEntry.git

2. Gerekli bağımlılıkları yükleyin.
3. Veri tabanını yapılandırın.
4. Uygulamayı başlatın.

Katkıda Bulunma

Katkılarınızı memnuniyetle karşılıyoruz! Lütfen önce bir "Issue" oluşturun ve değişikliklerinizi bir "Pull Request" ile gönderin.
