İlk önce web servis yapmamız için bir web projesi açıyoruz.Bu sistem için visual stdiuo’ya ihtiyaç duyulmaktadır.Daha sonra linq kodlama sisteminde yapacağımız kodlamalar için bir model.edmx modülasyonunu yüklememiz gerekiyor.
 
![image](https://user-images.githubusercontent.com/28226570/31333050-575c1a0a-acf1-11e7-800f-349f1acf06d2.png)

Şekil-3.1
Önceki sayfada  bulunan Şekil-3.1 yeni bir Web Site projesi açmak için kullanılır.Projemizde visual studio programı kullanılmaktadır.
 
![image](https://user-images.githubusercontent.com/28226570/31333060-5fd6fe34-acf1-11e7-810d-19623d2b1a3b.png)

Şekil-3.2
Yukarıda bulunan Şekil-3.2’de ise normal bir web uygulamasını seçip ismi’nide WebService olarak değiştirip OK tuşuna basıyoruz.
 
![image](https://user-images.githubusercontent.com/28226570/31333069-65945466-acf1-11e7-800c-db96a78fa8c5.png)

Şekil-3.3
Önceki sayfa’da bulunan Şekil-3.3 ise webservice yazacağımz linq kodları için bir model entity oluşturmamız gerekmektedir.
 
![image](https://user-images.githubusercontent.com/28226570/31333077-6a7e1f66-acf1-11e7-94da-87ffb745aa83.png)

Şekil-3.4
Yukarıdaki Şekil-3.4 ise kuracağımız model entity’nin içeriğini belirliyoruz.Biz “Generate from database”  seçiyoruz.Çünkü bu sistem hazır olarak gelmektedir.
 
![image](https://user-images.githubusercontent.com/28226570/31333080-6f0930c0-acf1-11e7-9145-85306af36561.png)

Şekil-3.5
Önceki sayfada Şekil-3.5 şekilde ise oluşturacağımız model entitynin  veritabanı ile bağlantısını gerçekleştiriyoruz ve veritabanı adını seçip “OK” tuşuna basıyoruz.
 
![image](https://user-images.githubusercontent.com/28226570/31333087-73ef6d7a-acf1-11e7-9deb-f90204c900d7.png)

Şekil-3.6
Yukarıdaki Şekil-3.6 tabloda ise seçtiğimiz veritabanına ait işlem yapacağımız tabloları seçiyoruz.
 
![image](https://user-images.githubusercontent.com/28226570/31333092-7840151e-acf1-11e7-883e-771f90e74857.png)

Şekil-3.7
Önceki sayfada bulunan Şekil-3.7 resimde görüldüğü gibi seçtiğimiz tabloların model’imize kayıt edildi.Bu sayede biz bu tablolar ile ilgili her türlü veritabanı işlemlerini linq kodları sayesinde yapabiliriz.Daha sonra ise bir webService.cs dosyası ekliyoruz.
 
![image](https://user-images.githubusercontent.com/28226570/31333100-7cd4929e-acf1-11e7-9b5e-88bce6db5fcb.png)

Şekil-3.8
Şimdi kodlamaya geçelim.
[WebService(Namespace = "http://localhost:55091/WebSite1/WebService.asmx")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService {

public WebService () {

}
JavaScriptSerializer jss = new JavaScriptSerializer();
ZIYARETCITAKIPOTOMASYONModel.ZIYARETCITAKIPOTOMASYONEntities kul = new ZIYARETCITAKIPOTOMASYONModel.ZIYARETCITAKIPOTOMASYONEntities();



Önceki sayfada yaptığımız kod tanımlamaları bir json dosyası için JavaScriptSerializer class’ında faydalanacaz sonrarında ise deneme amaçlı bir veritabanını model’iminiz içine atıp çalıştırdık.Daha sonrasında yukarıdaki  ZIYARETCITAKIPOTOMASYONModel bize geldi.Bizde onu tanımladık ve sonrasında gerekli tablolara ulaşma fırsatı yakaladık.   
[WebMethod]
     public string getSelectUserItemLinq(int id)
     {
         
         string json = "";
         var gelenSorgu = kul.KULLANICIBILGILER.Where(x => x.KULLANICIID == id).Select(x=>x);
         //var gelenSorgu = kul.KULLANICIBILGILER.ToList();
         json = jss.Serialize(gelenSorgu);
         return json;
     }

Yukarıdaki method bir webService methodudur.Nereden anladık çünkü başında bulunan [WebMethod] sayesinde.Bu method’un görevi ise görüldüğü üzere KULLANICIBILGILER adlı tabloda bulunan bir kullanıcının gelen id si üzerinden gerekli tüm bilgileri json formatında döndürmeye yarıyor.Bu id değeri android sistemden giren kullanıcının id sini yakalayan gerekli bilgileri döndürmeye yarayacak.















    

    [WebMethod]
     public string getSelectUserItemIDLinq(string username,string userpass)
     {

         string json = "";
         var gelenSorgu = kul.KULLANICIBILGILER.Where(x=>x.KULLANICIEMAIL==username & x.KULLANICISIFRE==userpass).FirstOrDefault().KULLANICIID;
      
         json = jss.Serialize(gelenSorgu);
         return json;
     }

Bu method’un görevi ise görüldüğü üzere KULLANICIBILGILER adlı tabloda bulunan bir kullanıcının gelen kullanıcıadı ve şifresi üzerinden gerekli ilk bilgileri yani o kullanıcı ve şifreye doğru bulunmuş ilk kullanıcının id’sini çekmeye yarıyor.Buda json formatında döndürmeye yarıyor.

     [WebMethod]
     public string getDataAllLinq() {
         string json = "";
         var gelenSorgu = kul.KULLANICIYETKILENDIRME.ToList();
         json = jss.Serialize(gelenSorgu);
         return json;
     }

Bu method’un görevi ise görüldüğü üzere KULLANICIYETKILENDIRME adlı tabloda bulunan bütün kullanıcıların yetkilerini  json formatında çekmeye yarıyor.
 
  
 
![image](https://user-images.githubusercontent.com/28226570/31333121-8c859792-acf1-11e7-8d9b-7a5c9517b0a6.png)

Şekil-3.9

Çalıştırılan webservice modeli post ve get methodları ile çalışması için webconfig dosyasına yukarıda bulunan Şekil-3.9’daki kodu yazyoruz.Bunun sayesinde kodun çalışıp çalışmadığını kontrol edebiliyoruz.
 
![image](https://user-images.githubusercontent.com/28226570/31333128-90d84eac-acf1-11e7-84e2-c4675fa01944.png)

Şekil-3.10

Görüldüğü üzere bilgiler yukarıda bulunan Şekil-3.10’daki webconfig ayar dosyasına yazdığımız kod sayesinde geldi ve bize nasıl kullanılır onu gösteriyor.Alt tarafta bulunan adres çubuğunda bu uygulama mevcuttur.

 
![image](https://user-images.githubusercontent.com/28226570/31333135-9642e23a-acf1-11e7-95a8-b17d3b6f40d6.png)

Şekil-3.11
Yukarıda verdiğim Şekil-3.11’deki kullanıcı giriş benzeri uygulmayı bize sistem kendi oluşturdu.Bu sayede buraya veriler girilerek uygulama yapılabilir.Ama biz buradan uygulamak yerine adres çubuğunu tercih ettik hem son kolaylık açısından hem görüntü açısından.

 
![image](https://user-images.githubusercontent.com/28226570/31333140-9b81dae4-acf1-11e7-8ee2-7e29f9709ed1.png)

Şekil-3.12
Yukarı verdiğim adres çubuğu ilk çalıştırmış olduğum adres çubuğudur.Bu adres çubuğu görüldüğü üzere çeşitli parametreler almaktadır.Bu parametreleri kullanmamız gerekmektedir.

 
![image](https://user-images.githubusercontent.com/28226570/31333144-a02b0ef8-acf1-11e7-93ba-d894321dee0a.png)

Şekil-3.13
Şekil-3.13’deki adres çubuğu ise webconfig dosyasına yazmış olduğum dosya bilgileri sayesinde çalıştırmış olduğum webservis çalışma durumudur.
![image](https://user-images.githubusercontent.com/28226570/31333149-a4401bfa-acf1-11e7-9c9c-3f2787a27e35.png)
 
Şekil-3.14
Yukarıdaki Şekil-3.14’deki adres çubuğuna yazdığımız kod ise kullanıcı adı ve şifre sayesinde size bir id değeri döndürücek.Sonrasında ise bu id değerini kullanıcının işlem yaptığı yerlerde kullanılabilecek bir değerdir.
 
![image](https://user-images.githubusercontent.com/28226570/31333155-a89596e4-acf1-11e7-89ee-dda949d0c8a0.png)

Şekil-3.15
Yukarıdaki Şekil-3.15’de yazdığımız kod ise kullanıcın id değerini yazıp kullanıcıya ait tüm yetkileri getirecektir.Bu sayede kullanın sisteme girdiği zaman hangi menüler aktif hangileri pasif olacağı belirtilmiştir.
