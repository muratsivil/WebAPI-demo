*********Core Katmaný diðer katmanlarý referans almaz*********
Core'daki herþey evrensel olmalý 

DataAccess -> Business -> **Web API** -> Angular, React, IOS, Android, vs

Web API sayesinde araya körü kuruyoruz. Buna Restful deniyyor JSON formatý ile çalýþýyor. Angular(Client) bize request yapýcak, biz ise Response yapýcaz. Bu iþlemler Web API Restful ile olucak. 

15.08.2021 Ne yaptým?

1. Web Apý oluþturduk
2. Core katmanýnda Utilities klasörü altýnda Result kalsörünün altýnda data, success, message gibi iþlemler geliþtirdik
3. ASP.NET'in kendi IoC containerý yerine Bussiness katmanýn da DepandencyResolves klasörü altýnda Autofac yapýsýný kurduk.
	3.1. Business katmanýna yüklenen paketler: Autofac ve Autofac.Extras.DynamicProxy
	3.2. WebAPI katmanýna yüklenen paket: Autofac.Extension.DependencyInjection 
	3.3. WebAPI katmanýnda Program.cs classýnda IHostBuilder fonksiyonun içine kendi oluþturduðumuz Service Provider Factory'yi verdik yani Autofac.
		3.3.1
			.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder => 
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
	3.4. Bu sayede Startup.cs classýnda fazladan koddan kaçmýþ olduk.
4. Autofac kullandýðýmýz için ProductsController.cs de constructor verirken baðýmlýlýklarý Program.cs'de yazdýðýmýz kod sayesinde Host edilirken bellekte bir alan oluþturup. ordan kullanmasý gerektiðini söylemiþ olduk.


Cross Cutting Concerns
	Log 
	Cache
	Transaction
	Authorization


	Örneðin loglamak istiyorusunuz, uygulama hata verdiðinde çalýþmasýný istediðin kodlar varsa onu AOP sayesinde yapýyoruz bu yönteme interceptors deniyor.


	Ýþ kurallarýný