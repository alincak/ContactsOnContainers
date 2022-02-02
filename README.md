# Kişi Rehberi ve Raporlama
Birbirleri ile haberleşen minimum iki microservice'in olduğu bir yapıdır. Basit bir telefon rehberi ve konuma göre raporlanma uygulaması oluşturulması hedeflenmiştir. 

## Çalıştırma (Running) ve Kullanımı (How to use)
`docker compose up` : Bu komutu src içerisinde çalıştırarak projeyi ayağa kaldırabilirsiniz.

`docker compose down` : container'ları silmek için kullanabilirsiniz. Image'lar silinmez.

API Base Endpoint (BASE_ENPOINT): `http://localhost:5000/`

### Contact Endpoints

`[HttpGET] [BASE_ENDPOINT]/Contacts`

`[HttpPost] [BASE_ENDPOINT]/Contacts`

`[HttpGET] [BASE_ENDPOINT]/Contacts/{id}`

`[HttpDelete] [BASE_ENDPOINT]/Contacts/{id}`

`[HttpPost] [BASE_ENDPOINT]/Contacts/info`

`[HttpDelete] [BASE_ENDPOINT]/Contacts/info/{id}`

Swagger Adresi (Swagger Endpoint): http://localhost:5001/swagger/index.html

- **Örnekler curl ile (Examples with curl)**

Kişi listeleme (Contact List): `curl -X 'GET' \ '[BASE_ENDPOINT]/Contacts' \ -H 'accept: text/plain'`

Kişi oluşturma (Create Contact): `curl -X 'POST' \
  '[BASE_ENDPOINT]/Contacts' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": "",
  "name": "NameTest",
  "lastName": "LastnameTest",
  "company": "CompanyTest"
}'`

Kişi detayları (Contact Details): `curl -X 'GET' \
  '[BASE_ENDPOINT]/Contacts/61fa5045e109d1e70738006f' \
  -H 'accept: text/plain'
`

Kişi sil (Delete Contact): `curl -X 'DELETE' \
  '[BASE_ENDPOINT]/Contacts/61fa5045e109d1e70738006f' \
  -H 'accept: */*'
`

İletişim bilgisi ekleme (Add contact info): `curl -X 'POST' \
  '[BASE_ENDPOINT]/Contacts/info' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": "",
  "contactId": "61fa5045e109d1e70738006f",
  "infoType": 0,
  "value": "5311111111"
}'`

İletişim bilgisi silme (Delete contact info): `curl -X 'DELETE' \
  '[BASE_ENDPOINT]/Contacts/info/61fa50e5e109d1e707380070' \
  -H 'accept: */*'`

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
