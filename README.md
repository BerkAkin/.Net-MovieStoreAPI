# Film Satış Sistemi API

Bu proje, film satışlarını yönetmek için geliştirilen bir RESTful API'dir. Sistem, kullanıcıların film satın alma, sipariş oluşturma ve favori türleri yönetme gibi işlemleri yapmalarına olanak sağlar. Veritabanı olarak SQL Server kullanılmıştır.

## Proje Yapısı

### 1. Kullanılan Teknolojiler

- **.NET Core 5**: API geliştirme için.
- **Entity Framework Core**: Veritabanı işlemleri için.
- **SQL Server**: Veritabanı yönetimi için.
- **AutoMapper**: Veritabanı varlıkları ile DTO'lar arasında dönüştürme yapmak için.
- **FluentValidation**: Varlık işlemlerinde varlıklar üzerinde kontrol mekanizması oluşturmak için.
- **JWT Authentication**: Kullanıcı doğrulaması için.

### 2. Veritabanı Yapısı

- **Customers** (Müşteriler): Müşteri bilgilerini içerir.
- **Movies** (Filmler): Film bilgilerini içerir.
- **Orders** (Siparişler): Müşterilerin satın aldığı filmler.
- **Genres** (Türler): Film türlerinin tutulduğu tablo.
- **Actors** (Türler): Aktörlerin tutulduğu tablo.
- **Producers** (Türler): Yapımcıların tutulduğu tablo.
- **CustomerMovies** (Müşteri-Film İlişkisi): Müşteriler ile filmler arasındaki çoklu ilişkiler.
- **CustomerFavoriteGenres** (Müşteri-Favori Tür İlişkisi): Müşteriler ile favori türleri arasındaki çoklu ilişkiler.
- **ActorMovie** (Aktör-Film İlişkisi): Aktörler ile filmler arasındaki çoklu ilişkiler.
- **GenreMovie** (Tür-Film Tür İlişkisi): Türler ile filmler arasındaki çoklu ilişkiler.

### 3. API Endpoint'lerinden bazıları

#### **Kullanıcı Doğrulama (Authentication)**

- **POST /auth/login**
  - Kullanıcı girişi yapar ve JWT token döner.
  - Body: `{ "email": "user@example.com", "password": "password123" }`
  - Headers: `Authorization: Bearer <token>`

#### **Sipariş Yönetimi**

- **GET /orders**
  - Tüm siparişleri getirir.
  - İlgili müşteri ve film bilgilerini de içerir.
- **POST /orders**
  - Yeni bir sipariş oluşturur.
  - Body: `{ "customerId": 1, "movieId": 2, "price": 50 }`

#### **Müşteri Yönetimi**

- **GET /customers**
  - Tüm müşterileri listeler.
- **GET /customers/{id}**
  - Belirli bir müşteriyi getirir.

#### **Film Yönetimi**

- **GET /movies**
  - Tüm filmleri listeler.
- **POST /movies**
  - Yeni bir film ekler.
  - Body: `{ "title": "Film Adı", "genre": "Tür" }`

### 4. Veri İlişkilerinden bazıları

- **Customers ve Movies**: Bir müşteri birçok film satın alabilir. Müşteriler ve filmler arasında "çoktan çoğa" bir ilişki vardır ve `CustomerMovies` ara tablosu kullanılır.
- **Customers ve Orders**: Bir müşteri birçok sipariş verebilir, ancak her sipariş bir müşteri ile ilişkilidir. "Birden çoğa" ilişkisi vardır.

### 5. Veritabanı Migrations

Projede Entity Framework Core kullanılarak SQL Server üzerinde veritabanı migrasyonları yönetilmektedir:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
