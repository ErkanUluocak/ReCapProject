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

            foreach (var item in carManager.GetById(1))
            {
                Console.WriteLine(item.CarId);
            }
        }
    }
}
