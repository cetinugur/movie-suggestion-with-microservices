# Film Tavsiye Mikroservis Uygulaması

## Servisler
    -Authentication
    -Movie
    -Email
	-Scheduled

Veritabanı olarak Postgresql, ORM olarak Entity framework, message queue olarak RabbitMQ ve zamanlanmış görevler için Quartz kullandım. Oturum açma özelliği kazandırmak için .Net core identity altyapısı
ile JWT token kullanan authentication servisini hazırladım.

## Kurulum
Bilgisayarınızda docker ve docker-compose kurulu ise docker-compose.yml dosyası ile servisleri çalıştırabilirsiniz.
Docker Desktop ve Visual studio 2022 kurulu ise doğrudan VS 2022 içerisinden docker-compose projesini çalıştırabilirsiniz. 
Veritabanları development ortamında otomatik migrate edilmektedir.