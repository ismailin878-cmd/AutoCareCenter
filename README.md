# AutoCareCenter 

Merhaba! Bu proje, oto servislerin ve araç bakım merkezlerinin günlük operasyonlarını (müşteri kaydı, araç takibi ve bu ikisi arasındaki bağlantıyı) çok daha düzenli ve dijital bir şekilde yönetmesi için geliştirdiğim bir **Micro-SaaS** masaüstü uygulamasıdır.

Bu projeyi geliştirirken ana odak noktam, sadece "çalışan bir uygulama" yapmak değil; arkasında temiz, sürdürülebilir ve kurumsal standartlarda bir kod mimarisi kurmaktı.

##  Bu Projede Neler Yaptım? (Kodun Arkası)
Yazılım dünyasında işlerin karmaşıklaşmasını önlemek için projeyi **N-Tier Architecture (Çok Katmanlı Mimari)** prensiplerine uygun olarak 3 ana parçaya böldüm:
* **Presentation Layer (UI):** Kullanıcının işini zorlaştırmayan, temiz ve yormayan Windows Forms arayüzleri tasarladım. Ayrıca ekran büyütüldüğünde tablonun saçmalamaması için dinamik (`Anchor` ve `AutoSize`) görsel responsive ayarlarını yaptım.
* **Business Logic Layer (BLL):** Uygulamanın "beyni" burası. Arayüzden gelen verilerin doğruluğunu kontrol eden, iş kurallarını işleten katman.
* **Data Access Layer (DAL):** Veritabanı ile olan tüm ham sorgu ve veri trafiğini güvenli bir şekilde yöneten katman.
* **Veritabanı (MySQL):** Verileri tamamen ilişkisel tasarladım. Sistemde bir müşteri eklendiğinde veya bir araca bağlandığında, arka planda her şey ID'ler üzerinden kusursuzca senkronize çalışıyor.

##  Öne Çıkan Detaylar (Neleri Çözdüm?)
* **Canlı Veri Senkronizasyonu (Live Sync):** Müşteri ekleme ekranından yeni birini kaydettiğiniz an, programı kapatıp açmaya gerek kalmadan, Araç İşlemleri ekranındaki açılır menüye (`ComboBox`) o müşteri anında düşüyor.
* **Akıllı İsim Birleştirme:** Veritabanında ayrı ayrı duran `ad` ve `soyad` alanlarını, kullanıcıya gösterirken dinamik olarak birleştirip tek bir isim gibi listeledim.
* **Temiz Arayüz:** Kullanılmayan veya o an içi boş olan veritabanı sütunlarını (`email`, `adres` gibi) tabloda gizleyerek ekranın her zaman sade ve profesyonel kalmasını sağladım.

---

# AutoCareCenter 

Hi there! This project is a desktop **Micro-SaaS** utility application I built to digitize and optimize daily operations for automotive service centers, making customer logging and vehicle tracking smooth and interconnected.

My main focus was not just delivering a "working app," but ensuring a clean, sustainable, and enterprise-grade architecture behind the scenes.

## Architecture & Design Patterns
To keep the codebase scalable and clean, I built the entire system from scratch using a solid **N-Tier Architecture**, separating concerns beautifully:
* **Presentation Layer (UI):** Designed clean UI forms. Optimized the tables using dynamic anchoring so the layouts scale responsively when maximized without breaking.
* **Business Logic Layer (BLL):** The "brain" of the app. Handles data validation, safety checks, and logical workflows.
* **Data Access Layer (DAL):** Direct gateway to the backend, executing secure data streams and CRUD operations.
* **Database Engine (MySQL):** Designed a structured relational database where vehicles and owners are seamlessly linked via synchronized IDs.

## Key Solutions (What I Solved)
* **Live Dropdown Sync:** Fixed the frustrating sync issue. Now, the moment a new customer is added, the vehicle form's dropdown populates instantly without needing a software restart.
* **Smart String Concatenation:** Merged separate backend fields (`ad` + `soyad`) on the fly to present a clean, combined full name in the dropdown.
* **Clean UI Table:** Dynamically hid optional empty columns (`email`, `adres`) from the DataGridView to ensure the interface looks polished during review.

---

##  Tech Stack
* **Language:** C# (100%)
* **Framework:** Windows Forms (.NET Framework)
* **Database Engine:** MySQL Server
