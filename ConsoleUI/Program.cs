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

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.CarId} {car.BrandId} {car.ColorId} {car.ModelYear} {car.DailyPrice} {car.Description}");
            }

            Console.WriteLine(carManager.GetById(1).CarId);
            Car car1 = carManager.GetById(1);
            carManager.Delete(car1);
            Console.WriteLine();
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.CarId} {car.BrandId} {car.ColorId} {car.ModelYear} {car.DailyPrice} {car.Description}");
            }
            Console.WriteLine(carManager);

        }
    }
}
