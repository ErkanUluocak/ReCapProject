using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car { CarId = 1, BrandId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = 150, Description = "Çok temiz araç" },
            new Car { CarId = 2, BrandId = 6, ColorId = 5, ModelYear = 2015, DailyPrice = 200, Description = "Çok temiz araç" },
            new Car { CarId = 3, BrandId = 3, ColorId = 3, ModelYear = 2021, DailyPrice = 300, Description = "Çok temiz araç" },
            new Car { CarId = 4, BrandId = 4, ColorId = 1, ModelYear = 2017, DailyPrice = 100, Description = "Çok temiz araç" },
            new Car { CarId = 5, BrandId = 7, ColorId = 1, ModelYear = 2016, DailyPrice = 180, Description = "Çok temiz araç" }
             };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(car);
        }
        public List<Car> GetAll()
        {
            return _cars;
        }
        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
