using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{

    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            BrandManager brandManager = new BrandManager(new EfBrandDal());


            //List(carManager); //Listeyi yazdırma
            //Console.WriteLine();

            //Console.WriteLine($"Seçilen Id:{carManager.GetById(1).CarId}"); //GetById Test
            //Console.WriteLine();

            //Car car1 = carManager.GetById(1);
            //carManager.Delete(car1);   //Delete Test
            //Console.WriteLine("Listeden araba silindi...");
            //List(carManager);
            //Console.WriteLine();


            //Car car = new Car
            //{
            //    CarId = 7,
            //    ColorId = 2,
            //    BrandId = 1,
            //    Description = "Sahibinden temiz",
            //    DailyPrice = 180000,
            //    ModelYear = 2021
            //};

            //carManager.Add(car); //Add Test
            //Console.WriteLine("Listeye araba eklendi...");
            //List(carManager);
            //Console.WriteLine();



            //Car car2 = carManager.GetById(2);

            //car2.BrandId = 1;
            //car2.ColorId = 4;
            //car2.Description = "Yeni güncelleme";
            //car2.ModelYear = 2022;
            //car2.DailyPrice = 500000;

            //Console.WriteLine();

            //carManager.Update(car2);  //Update Test
            //Console.WriteLine("Araba güncellendi...");
            //List(carManager);


            //List(carManager);





            //Araba ismi minimum 2 karakter testi

            Brand brand = new Brand { BrandName = "Yy" };

            //try
            //{
            //    brandManager.Add(brand);
            //    Console.WriteLine("Marka başarılı bir şekilde eklendi.");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            int sonuc = brandManager.Add2(brand);

            if (sonuc >= 1)
            {
                  Console.WriteLine("Marka başarılı bir şekilde eklendi.");
            }
            else
            {
                Console.WriteLine("Araba ismi 2 karakterden uzun olmalıdır........  yeni");
            }





            //if (brandManager.CheckIfNameIsLongEnough(brand.BrandName))
            //{
            //    brandManager.Add(brand);
            //    Console.WriteLine("Marka başarıyla kayıt edilmiştir");
            //}
            //else
            //{
            //    Console.WriteLine("Araba ismi 2 karakterden uzun olmalıdır.");
            //}





            //Araba günlük fiyatı 0'dan büyük olmalıdır testi.

            //Car car = new Car
            //{
            //    BrandId = 5,
            //    ColorId = 6,
            //    ModelYear = 2022,
            //    DailyPrice = 100,
            //    Description = "yeni deneme"
            //};


            //try
            //{
            //    carManager.Add(car);
            //    Console.WriteLine("Araç başarılı bir şekilde eklendi.");


            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);

            //}

            //if (carManager.CheckIfPriceHigherThanZero(car.DailyPrice)) 
            //{
            //    carManager.Add(car);
            //    Console.WriteLine("Araba başarılı şekilde sisteme kayıt edilmiştir.");
            //}
            //else
            //{
            //    Console.WriteLine("Arabanın günlük fiyatı 0'dan büyük olmalıdır.");
            //}




            //Console.WriteLine("--- GetCarsByBrandId ---");

            //foreach (var car in carManager.GetCarsByBrandId(18))
            //{
            //    Console.WriteLine($"Brand : {car.BrandId} - Color : {car.ColorId} - Model Year : {car.ModelYear} - Description : {car.Description}");
            //}
            //Console.WriteLine();
            //Console.WriteLine("--- GetCarsByColorId ---");

            //foreach (var car in carManager.GetCarsByColorId(6))
            //{
            //    Console.WriteLine($"Brand : {car.BrandId} - Color : {car.ColorId} - Model Year : {car.ModelYear} - Description : {car.Description}");
            //}


        }

        private static void List(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())  //GetAll Test
            {
                //Console.WriteLine($"CarId: {car.CarId.ToString()} BrandId: {car.BrandId.ToString()} ColorId: {car.ColorId.ToString()} Model Year: {car.ModelYear.ToString()} Dail Price: {car.DailyPrice.ToString()} Description: {car.Description}");
                Console.WriteLine(car.CarId);
            }
        }
    }
}
