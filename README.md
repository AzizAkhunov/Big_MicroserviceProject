[# Big_MicroserviceProject] 
                  Dastur Haqida!!
Dastur Project DotNet 6 ASP.NET Api WebApplication

Installing Packages:
EntityFrameWork.SqlServer = Database Ulash uchun
EntityFrameWork.Core = Funksiyalarni ishlatish uchun 
EntityFrameWork.Core.Tools = Migration uchun 
EntityFrameWork.Core.Design = Bu database da table lar chalkash bulmasligi uchun 


                Database 


1.YPX
https://drawsql.app/teams/azizs-team-2/diagrams/gai

1) Yo'l Patrul xizmatchilari uchun Planshet dasturi
Bo'ni maqsadi qoida buzarliklarni oldini olish shu blan
qoida buzulganda tartibli saqlash va jarima chiqarib berish uchun ishlaydi.
Bizda 3 ta table mavjud:
            YPX => Yo'l patrul xizmatchilari
            Drivers => Haydovchilar
            Punishments => Jarimalar Ro'yhati
Relations:
          YPX (One to Many) Punishments => YPX chiqargan jarimalarni saqlash uchun
          Drivers (One to Many) Punishments => Fuqaro olgan jarimalarni saqlash uchun
2.OLX
https://drawsql.app/teams/azizs-team-2/diagrams/olx

2)OLX => yani onlayn magazin Hamma uz mahsulotini sotsa buladi dasturimda malumot soni va miqdori cheklanmagan 
va 1 dona bulsaham sotuvga quysa buladi dasturdan maqsad odamlarni ish bilan band qilish va qulaylik yaratish!
Bizda 5 ta Table mavjud:
            User => Foydalanuvchi
            Card => Foydalanuchi plastik kartasi
            Product => Foydalanuvchi Maxsuloti
            Buy => Sotilgan narsalar ro'xati uchun
            Sell => Sotib yuborilgan narsalar ro'yxati
Relations:
            User (One to Many) Card => Userni Plastik kartalarini saqlash uchun
            User (One to Many) Buy => Userni sotib oladigan narsalari uchun
            User (One to Many) Product => Foydalanuvchini bir nechta maxsulotlarini saqlash uchun
            Product (One to One) Sell => 1 ta product 1 martta sotilishi mumkin 
            
3.YandexTaxi
https://drawsql.app/teams/azizs-team-2/diagrams/yandex-taxi

2) Yandex Taxi => Yandex Taxidi tushuntirib chuqurlashi yotmiman bilganilade taxi
Bizda 6 ta Table mavjud:
         Drivers => Xaydovchi
         Cars => Haydovchi mashinasi
         Scrins => yani telefonda kursatib turadigon malumotlar
         Orders => Taxi Zakaz berish
         Clients => Client
         Cards => client cards
Relations:
          Driver (One to Many) Order => Driverni oladigan zakazlari
          Driver (One to One) Car => Haydovchi mashinasi uchun
          Car (Many to Many) Scrin => Car bir nechta Scrinlarda bulishi mumkin Scrinlar bir nechta carlarda
          Client (One To Many) Order => 1 ta Client ni bir nechta Orderlari bulishi mumkin
          Client (One to Many) Card => Student Cartalari uchuns


                      Usings
      MemoryCache,FluentAPI,DependencyInjection
