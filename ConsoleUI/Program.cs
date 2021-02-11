using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName +"|" + car.ColorName +"|"+ car.Description +"|"+ car.DailyPrice);
            }
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("---------- Rent A Car ----------");
                Console.WriteLine(car.ModelYear);
                Console.WriteLine("----");
                Console.WriteLine(car.Description);
                Console.WriteLine("----");
                Console.WriteLine(car.DailyPrice);

            }
        }
    }
}
