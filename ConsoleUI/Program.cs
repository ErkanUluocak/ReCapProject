using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            List(carManager); //Listeyi yazdırma
            Console.WriteLine();

            Console.WriteLine($"Seçilen Id:{carManager.GetById(1).CarId}"); //GetById Test
            Console.WriteLine();

            Car car1 = carManager.GetById(1);
            carManager.Delete(car1);   //Delete Test
            Console.WriteLine("Listeden araba silindi...");
            List(carManager);
            Console.WriteLine();


            Car car = new Car
            {
                CarId = 7,
                ColorId = 2,
                BrandId = 1,
                Description = "Sahibinden temiz",
                DailyPrice = 180000,
                ModelYear = 2021
            };

            carManager.Add(car); //Add Test
            Console.WriteLine("Listeye araba eklendi...");
            List(carManager);
            Console.WriteLine();



            Car car2 = carManager.GetById(2);

            car2.BrandId = 1;
            car2.ColorId = 4;
            car2.Description = "Yeni güncelleme";
            car2.ModelYear = 2022;
            car2.DailyPrice = 500000;

            Console.WriteLine();

            carManager.Update(car2);  //Update Test
            Console.WriteLine("Araba güncellendi...");
            List(carManager);
        }

        private static void List(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())  //GetAll Test
            {
                Console.WriteLine($"CarId: {car.CarId} BrandId: {car.BrandId} ColorId: {car.ColorId} Model Year: {car.ModelYear} Dail Price: {car.DailyPrice} Description: {car.Description}");
            }
        }
    }
}
