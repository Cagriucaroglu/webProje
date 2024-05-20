Server=YourServerName;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;Encrypt=True;TrustServerCertificate=True; appsettings.json'daki ConnectionString'i kendi Sql server authanticatiounınıza göre ayarlayın:
"Server=YourServerName;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;Encrypt=True;TrustServerCertificate=True;"
ardından ![resim](https://github.com/Cagriucaroglu/webProje/assets/95860565/b5a256bd-a0c2-4c65-acd5-501d5d636a3a) visual studio'da bu şekilde package manager console'unu açarak "Update-Database" komutunu çalıştırın. Bunu derken sql serverınız açık olmalı.
Bu komut ile database ve table code first ile sql'e kaydedilecektir.Ardından uygulamayı çalıştırın. Artık api routelara erişebilirsiniz
