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
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2018,DailyPrice=1500,Description="Black BMW |Fast car for everyone | Cheap and Easy"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=2000,Description="White BMW |Fast car for everyone | Cheap and Easy"},
                new Car{Id=3,BrandId=1,ColorId=3,ModelYear=2021,DailyPrice=2500,Description="Blue BMW  |Fast car for everyone | Cheap and Easy"},
                new Car{Id=4,BrandId=2,ColorId=1,ModelYear=2019,DailyPrice=1700,Description="Black Audi|Fast car for everyone | Cheap and Easy"},
                new Car{Id=5,BrandId=2,ColorId=1,ModelYear=2020,DailyPrice=2200,Description="Black Audi|Fast car for everyone | Cheap and Easy"},
                new Car{Id=6,BrandId=2,ColorId=2,ModelYear=2017,DailyPrice=800,Description="White Audi|Fast car for everyone | Cheap and Easy"},
                new Car{Id=7,BrandId=3,ColorId=1,ModelYear=2020,DailyPrice=1000,Description="Black Mercedes|Fast car for everyone | Cheap and Easy"},
                new Car{Id=8,BrandId=3,ColorId=3,ModelYear=2020,DailyPrice=1200,Description="Blue Mercedes |Fast car for everyone | Cheap and Easy"},
                new Car{Id=9,BrandId=4,ColorId=3,ModelYear=2019,DailyPrice=800,Description="Blue Volkswagen|Fast car for everyone | Cheap and Easy"},
                new Car{Id=10,BrandId=5,ColorId=2,ModelYear=2016,DailyPrice=650,Description="White Honda   |Fast car for everyone | Cheap and Easy"},
            };
        
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
