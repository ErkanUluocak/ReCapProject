﻿using Business.Concrete;
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
            //Car nesnesi testleri 

            //GetCarDetailsTest();
            //CarGetAllTest();
            //GetCarByIdTest();
            //CarAddTest();
            //CarUpdateTest();
            //CarDeleteTest();
            //CheckIfPriceHigherThanZeroTest();
            //GetCarsByBrandIdTest();
            //GetCarsByColorIdTest();




            //Brand nesnesi testler

            //BrandGetAllTest();
            //BrandGetByIdTest();
            //BrandAddTest();
            //BrandUpdateTest();
            //BrandDeleteTest();
            //BrandCheckIfNameIsLongEnoughTest();





            //Color nesnesi testler

            //ColorGetAllTest();
            //ColorGetByIdTest();
            //ColorAddTest();
            //ColorUpdateTest();
            //ColorDeleteTest();




            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetailsByBrandId(18))
            {
                Console.WriteLine($"{car.CarId} - {car.BrandName} - {car.ColorName} - {car.DailyPrice}");
            }



        }

        private static void ColorDeleteTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var deletedEntity = colorManager.GetById(12);
            Console.WriteLine("Renk başarılı bir şekilde silindi.\n");
            colorManager.Delete(deletedEntity);
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var updatedEntity = colorManager.GetById(11);
            updatedEntity.ColorName = "Açık Kahverengi";
            colorManager.Update(updatedEntity);
            Console.WriteLine("Renk başarılı bir şekilde güncellendi.\n");

        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Fosfor Yeşili" });
            Console.WriteLine("Renk başarılı bir şekilde kayıt edildi.\n");
        }




        private static void ColorGetByIdTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var color = colorManager.GetById(2);
            Console.WriteLine($"{color.ColorId} - {color.ColorName}");
            Console.WriteLine();
        }

        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.ColorId} - {color.ColorName}");
            }
            Console.WriteLine();
        }


        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.CarId} - {car.BrandId} - {car.ColorId} - {car.ModelYear} - {car.DailyPrice} - {car.Description}");
            }
        }

        private static void GetCarsByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(6))
            {
                Console.WriteLine($"Brand : {car.BrandId} - Color : {car.ColorId} - Model Year : {car.ModelYear} - Description : {car.Description}");
            }
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(18))
            {
                Console.WriteLine($"Brand : {car.BrandId} - Color : {car.ColorId} - Model Year : {car.ModelYear} - Description : {car.Description}");
            }
        }

        private static void CheckIfPriceHigherThanZeroTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car
            {
                BrandId = 5,
                ColorId = 6,
                ModelYear = 2022,
                DailyPrice = 259,
                Description = "yeni deneme"
            };

            try
            {
                carManager.Add(car);
                Console.WriteLine("Araç başarılı bir şekilde eklendi.");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void BrandCheckIfNameIsLongEnoughTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand { BrandName = "C" };
            try
            {
                brandManager.Add(brand);
                Console.WriteLine("Marka başarılı bir şekilde eklendi.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = brandManager.GetById(1025);
            brandManager.Delete(brand);
            Console.WriteLine("Brand başarılı şekilde silindi.\n");
            BrandGetAllTest();
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = brandManager.GetById(1024);
            brand.BrandName = "Update Brand";
            brandManager.Update(brand);
            Console.WriteLine("Marka başarılı bir şekilde güncellendi.\n");
            BrandGetAllTest();
        }

        private static void BrandGetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = brandManager.GetById(1024);
            Console.WriteLine($"{brand.BrandId} - {brand.BrandName}");
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Yeni Marka" });
            Console.WriteLine("Marka başarılı bir şekilde eklendi.\n");
            BrandGetAllTest();
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.BrandId} - {brand.BrandName}");
            }
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = carManager.GetById(1005);
            carManager.Delete(car1);   //Delete Test
            Console.WriteLine("Listeden araba silindi...");
            GetCarDetailsTest();
            Console.WriteLine();
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car2 = carManager.GetById(2);

            car2.BrandId = 1;
            car2.ColorId = 4;
            car2.Description = "Son güncelleme";
            car2.ModelYear = 2022;
            car2.DailyPrice = 899;

            Console.WriteLine();

            carManager.Update(car2);  //Update Test
            Console.WriteLine("Araba güncellendi...");
            GetCarDetailsTest();
        }

        private static void CarAddTest()
        {
            Car car = new Car
            {
                ColorId = 2,
                BrandId = 1,
                Description = "Yeni eklenen",
                DailyPrice = 279,
                ModelYear = 2022
            };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car); //Add Test
            Console.WriteLine("Listeye araba eklendi...");
        }

        private static void GetCarByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine($"Seçilen Id:{carManager.GetById(1).CarId}");
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"{car.CarId} - {car.BrandName} - {car.ColorName} - {car.DailyPrice}");
            }
        }
    }
}
