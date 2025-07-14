# Günün Sözü+ (GununSozu)

Günün Sözü+ projesi, günlük ilham verici sözleri kullanıcılarla paylaşmak için geliştirilmiş bir ASP.NET Core tabanlı web ve API uygulamasıdır. Proje, yönetim paneli üzerinden içeriklerin (söz, yazar, kategori vs.) düzenlenebilmesini sağlar.

## 🛠️ Teknolojiler

- ASP.NET Core Web API
- ASP.NET Core MVC (Razor Pages)
- Entity Framework Core
- MSSQL
- Swagger UI
- Bootstrap 5

## 🔧 Kurulum

1. Projeyi klonlayın:
   ```bash
   git clone https://github.com/kullaniciadi/gununs-sozu.git
   ```

2. Veritabanını yapılandırın:
   - `appsettings.json` veya `Program.cs` içindeki connection string'i güncelleyin.
   - Package Manager Console üzerinden migration'ı uygulayın:
     ```bash
     dotnet ef database update --project GununSozu.Data --startup-project GununSozu.Api
     ```

3. Uygulamayı başlatın:
   ```bash
   dotnet run --project GununSozu.Api
   ```

4. Swagger arayüzüne gidin:  
   [https://localhost:7284/swagger](https://localhost:7284/swagger)

5. Admin paneli için:  
   [https://localhost:7114/Admin/Quote](https://localhost:7114/Admin/Quote)

## 📂 Proje Yapısı

- `GununSozu.Api` — REST API projesi
- `GununSozu.Web` — Admin paneli (Razor Pages)
- `GununSozu.Data` — Entity katmanı ve DbContext
- `GununSozu.Business` — Servis katmanı ve DTO'lar

## 👨‍💻 Katkı

Pull request'ler, hata bildirimleri ve öneriler her zaman memnuniyetle karşılanır.
