using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //RentalDto testleri

            //GetRentalDetailsTest();
            RentalAddTest();
            //RentalUpdateTest();
            //RentalDeleteTest();





            //Customer nesnesi testleri

            //CustomerAddTest();















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
            //GetCarDetailsByBrandIdTest();
            //GetCarDetailsByColorId();







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









        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { UserId = 1, CompanyName = "Sırma" });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalDeleteTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Delete(new Rental { Id = 44 });
        }

        private static void RentalUpdateTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var resultCar = rentalManager.GetById(59);

            if (resultCar.Data == null)
            {
                Console.WriteLine("Böyle bir kiralama bulunamadı!");
            }
            else
            {
                resultCar.Data.ReturnDate = new DateTime(2022, 2, 2);
                var result = rentalManager.Update(resultCar.Data);
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 5, CustomerId = 3, RentDate = new DateTime(2022, 8, 7) });
            Console.WriteLine(result.Message);
        }

        private static void GetRentalDetailsTest()
        {
            // string bos = "-";

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            foreach (var rental in result.Data)
            {
                //var result = (rental.RentDate != null) ? "-" : rental.RentDate.ToString()

                var mesaj = "Araç Teslim Edilmedi";
                if (rental.ReturnDate.HasValue && rental.ReturnDate.Value.Year > 1900)
                {
                    mesaj = rental.ReturnDate.Value.ToString();
                }
                Console.WriteLine($"{rental.UserId} - {rental.FirstName} - {rental.LastName} - {rental.CompanyName} - {rental.RentDate} - {mesaj}");

            }
        }



        private static void GetCarDetailsByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetailsByColorId(8).Data)
            {
                Console.WriteLine($"{car.CarId} - Brand Name : {car.BrandName} - {car.ColorName} - {car.DailyPrice}");
            }
        }

        //private static void GetCarDetailsByBrandIdTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarDetailsByBrandId(18))
        //    {
        //        Console.WriteLine($"{car.CarId} - Brand Name : {car.BrandName} - {car.ColorName} - {car.DailyPrice}");
        //    }
        //}

        //private static void ColorDeleteTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    var deletedEntity = colorManager.GetById(12);
        //    Console.WriteLine("Renk başarılı bir şekilde silindi.\n");
        //    colorManager.Delete(deletedEntity);
        //}

        //private static void ColorUpdateTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    var updatedEntity = colorManager.GetById(11);
        //    updatedEntity.ColorName = "Açık Kahverengi";
        //    colorManager.Update(updatedEntity);
        //    Console.WriteLine("Renk başarılı bir şekilde güncellendi.\n");

        //}

        //private static void ColorAddTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    colorManager.Add(new Color { ColorName = "Fosfor Yeşili" });
        //    Console.WriteLine("Renk başarılı bir şekilde kayıt edildi.\n");
        //}




        //private static void ColorGetByIdTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    var color = colorManager.GetById(2);
        //    Console.WriteLine($"{color.ColorId} - {color.ColorName}");
        //    Console.WriteLine();
        //}

        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine($"{color.ColorId} - {color.ColorName}");
            }
            Console.WriteLine();
        }


        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine($"{car.CarId} - {car.BrandId} - {car.ColorId} - {car.ModelYear} - {car.DailyPrice} - {car.Description}");
            }
            Console.WriteLine(result.Message);
        }

        //private static void GetCarsByColorIdTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarsByColorId(6))
        //    {
        //        Console.WriteLine($"Brand : {car.BrandId} - Color : {car.ColorId} - Model Year : {car.ModelYear} - Description : {car.Description}");
        //    }
        //}

        //private static void GetCarsByBrandIdTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarsByBrandId(18))
        //    {
        //        Console.WriteLine($"Brand : {car.BrandId} - Color : {car.ColorId} - Model Year : {car.ModelYear} - Description : {car.Description}");
        //    }
        //}

        //private static void CheckIfPriceHigherThanZeroTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Car car = new Car
        //    {
        //        BrandId = 5,
        //        ColorId = 6,
        //        ModelYear = 2022,
        //        DailyPrice = 259,
        //        Description = "yeni deneme"
        //    };

        //    try
        //    {
        //        carManager.Add(car);
        //        Console.WriteLine("Araç başarılı bir şekilde eklendi.");


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private static void BrandCheckIfNameIsLongEnoughTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    Brand brand = new Brand { BrandName = "C" };
        //    try
        //    {
        //        brandManager.Add(brand);
        //        Console.WriteLine("Marka başarılı bir şekilde eklendi.");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private static void BrandDeleteTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    var brand = brandManager.GetById(1025);
        //    brandManager.Delete(brand);
        //    Console.WriteLine("Brand başarılı şekilde silindi.\n");
        //    BrandGetAllTest();
        //}

        //private static void BrandUpdateTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    var brand = brandManager.GetById(1024);
        //    brand.BrandName = "Update Brand";
        //    brandManager.Update(brand);
        //    Console.WriteLine("Marka başarılı bir şekilde güncellendi.\n");
        //    BrandGetAllTest();
        //}

        //private static void BrandGetByIdTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    var brand = brandManager.GetById(1024);
        //    Console.WriteLine($"{brand.BrandId} - {brand.BrandName}");
        //}

        //private static void BrandAddTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    brandManager.Add(new Brand { BrandName = "Yeni Marka" });
        //    Console.WriteLine("Marka başarılı bir şekilde eklendi.\n");
        //    BrandGetAllTest();
        //}

        //private static void BrandGetAllTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    var result = brandManager.GetAll();
        //    foreach (var brand in result.Data)
        //    {
        //        Console.WriteLine($"{brand.BrandId} - {brand.BrandName}");
        //    }
        //}

        //private static void CarDeleteTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Car car1 = carManager.GetById(1005);
        //    carManager.Delete(car1);   //Delete Test
        //    Console.WriteLine("Listeden araba silindi...");
        //    GetCarDetailsTest();
        //    Console.WriteLine();
        //}

        //private static void CarUpdateTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    Car car2 = carManager.GetById(2);

        //    car2.BrandId = 1;
        //    car2.ColorId = 4;
        //    car2.Description = "Son güncelleme";
        //    car2.ModelYear = 2022;
        //    car2.DailyPrice = 899;

        //    Console.WriteLine();

        //    carManager.Update(car2);  //Update Test
        //    Console.WriteLine("Araba güncellendi...");
        //    GetCarDetailsTest();
        //}

        private static void CarAddTest()
        {
            Car car = new Car
            {
                ColorId = 2,
                BrandId = 1,
                Description = "Aile aracı. Değişen parça yok",
                DailyPrice = 279,
                ModelYear = 2022
            };

            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(car); //Add Test
            Console.WriteLine("Listeye araba eklendi...");

        }



        //private static void GetCarByIdTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Console.WriteLine($"Seçilen Id:{carManager.GetById(1).CarId}");
        //}

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();


            foreach (var car in result.Data)
            {
                Console.WriteLine($"{car.CarId} - {car.BrandName} - {car.ColorName} - {car.DailyPrice}");
            }
        }


    }
}
