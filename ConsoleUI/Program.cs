using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
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
