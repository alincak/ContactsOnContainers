# Kişi Rehberi ve Raporlama
Birbirleri ile haberleşen minimum iki microservice'in olduğu bir yapıdır. Basit bir telefon rehberi ve konuma göre raporlanma uygulaması oluşturulması hedeflenmiştir. 


## Teknik Tasarım
#### Kişiler
Sistemde teorik anlamda sınırsız sayıda kişi kaydı yapılabilmektedir. Her kişiye bağlı iletişim bilgileri de yine sınırsız bir biçimde eklenebilmektedir.

Veri yapısındaki alanlar aşağıdaki gibidir:
- UUID
- Ad
- Soyad
- Firma
- İletişim Bilgisi
  - Bilgi Tipi: Telefon Numarası, E-mail Adresi, Konum
  - Bilgi İçeriği

#### Rapor
Rapor talepleri asenkron çalışmaktadır. Kullanıcı bir rapor talep ettiğinde, sistem arkaplanda bu çalışmayı darboğaz yaratmadan sıralı bir biçimde ele alacak; rapor tamamlandığında ise kullanıcının "raporların listelendiği" endpoint üzerinden raporun durumunu "tamamlandı" olarak gözlemleyebilmektedir.

Rapor basitçe aşağıdaki bilgileri içermektedir:

- Konum Bilgisi
- konumda yer alan rehbere kayıtlı kişi sayısı
- konumda yer alan rehbere kayıtlı telefon numarası sayısı


## Teknik Detaylar
- Kullanılan teknolojiler:
   - .NET Core
   - MongoDB
   - RabbitMQ (Message Broker)
   - Ocelot
   - Docker compose

## Mimari Yapı
![contact_containers_draw_io drawio (1)](https://user-images.githubusercontent.com/13946186/152122108-281108be-2d17-4bbc-bbd3-10b20298ed4b.png)
