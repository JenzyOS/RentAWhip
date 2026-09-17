// Created by Ege Duyar - RentAWhip
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Core.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDailyPriceInvalid = "Araç günlük fiyatý 0 olamaz";
        public static string MaintenanceTime = "Bakým saatleri arasýndasýnýz";
        public static string CarsListed = " Tüm araçlar getirildi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarDeleted = "Araç Silindi";
        public static string BrandInvalidError = "Araç markasý 2 karakterden fazla olmalýdýr";
        public static string BrandAdded = "Araç markasý eklendi";
        public static string BrandUpdated = "Araç markasý Güncellendi";
        public static string BrandDeleted = "Araç markasý silindi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string UserAdded = "Kullanýcý eklendi";
        public static string UserUpdated = "Kullsnýcý güncellendi";
        public static string UserDeleted = "Kullanýcý silindi";
        public static string CustomerAdded = "Müþteri eklendi";
        public static string CustomerUpdated = "Müþteri güncellendi";
        public static string CustomerDeleted = "Müþteri silindi";
        public static string RentalAdded = "Müþteri eklendi";
        public static string RentalUpdated = "Müþteri güncellendi";
        public static string RentalDeleted = "Müþteri silindi";
        public static string RentalReturnDateInvalidError = "Teslim edilmemiþ araç kiralanamaz";
        public static string CarCountOfBrandError = "Yeterli sayýda marka araca sahibiz. Yenisi eklenemez";
        public static string BrandNameAlreadyExists = "Bu isimde bþaka bir Marka var";
        public static string CarImageUpdated ="Araç Resmi Güncellendi";
        public static string CarImageDeleted="Araç resmi silindi";
        public static string CarImageAdd = "Araç resmi eklendi";
        public static string CarImageCountOfImageError="Araç resmi 5 adetten fazla olamaz!";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered="Kayýt edildi";
        public static string UserNotFound="Kullanýcý bulunamadý";
        public static string PasswordError="Þifre hatalý";
        public static string SuccessfulLogin="Giriþ baþarýlý";
        public static string UserAlreadyExists="Kullanýcý Mevcut";
        public static string AccessTokenCreated="Geçerli Token oluþturuldu";
    }
}
