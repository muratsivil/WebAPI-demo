*********Core Katman� di�er katmanlar� referans almaz*********
Core'daki her�ey evrensel olmal� 

DataAccess -> Business -> **Web API** -> Angular, React, IOS, Android, vs

Web API sayesinde araya k�r� kuruyoruz. Buna Restful deniyyor JSON format� ile �al���yor. Angular(Client) bize request yap�cak, biz ise Response yap�caz. Bu i�lemler Web API Restful ile olucak. 

15.08.2021 Ne yapt�m?

1. Web Ap� olu�turduk
2. Core katman�nda Utilities klas�r� alt�nda Result kals�r�n�n alt�nda data, success, message gibi i�lemler geli�tirdik
3. ASP.NET'in kendi IoC container� yerine Bussiness katman�n da DepandencyResolves klas�r� alt�nda Autofac yap�s�n� kurduk.
	3.1. Business katman�na y�klenen paketler: Autofac ve Autofac.Extras.DynamicProxy
	3.2. WebAPI katman�na y�klenen paket: Autofac.Extension.DependencyInjection 
	3.3. WebAPI katman�nda Program.cs class�nda IHostBuilder fonksiyonun i�ine kendi olu�turdu�umuz Service Provider Factory'yi verdik yani Autofac.
		3.3.1
			.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder => 
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
	3.4. Bu sayede Startup.cs class�nda fazladan koddan ka�m�� olduk.
4. Autofac kulland���m�z i�in ProductsController.cs de constructor verirken ba��ml�l�klar� Program.cs'de yazd���m�z kod sayesinde Host edilirken bellekte bir alan olu�turup. ordan kullanmas� gerekti�ini s�ylemi� olduk.


Cross Cutting Concerns
	Log 
	Cache
	Transaction
	Authorization


	�rne�in loglamak istiyorusunuz, uygulama hata verdi�inde �al��mas�n� istedi�in kodlar varsa onu AOP sayesinde yap�yoruz bu y�nteme interceptors deniyor.


	�� kurallar�n�