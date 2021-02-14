using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserAndCustomerTest();
            //RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            foreach (var results in result.Message)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserAndCustomerTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { FirstName = "Doğan", LastName = "Kabak", Email = "dogankabak@outlook.com", Password = "kabak12345" };
            //userManager.Add(user);

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = (userManager.Get(user).Data.UserId), CompanyName = "Kabak Holding" });
        }
    }
}
