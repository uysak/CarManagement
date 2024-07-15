Bu örnek bir API projesidir. Temel olarak, marka altına araç eklemek için oluşturulmuştur. Projeyi klonladıktan sonra, DataAccess katmanının altındaki Context klasöründe bulunan, CarsContext.cs sınıfından ConnectionString'i düzenleyip,
Package Manager Console'dan update-database komutunu vermelisiniz.

Marka altına araç eklemek için, admin rolüne sahip bir hesapla login olmanız gerekmektedir. Şu an rol atamasıyla ilgili bir yapı bulunmadığından, DB oluşturulduğu sırada db initializer ile oluşturulan default admin hesabıyla giriş yapabilirsiniz. 

Default Admin Hesabı:

email: admin@admin.com
password: admin
