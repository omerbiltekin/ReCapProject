using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cus in context.Customers
                             on r.CustomerId equals cus.UserId
                             join u in context.Users
                             on cus.UserId equals u.UserId
                             select new RentalDetailDto 
                             {
                                 RentalId=r.RentalId,
                                 CarName=b.BrandName,
                                 CustomerName=u.FirstName,
                                 CustomerLastName=u.LastName,
                                 CompanyName=cus.CompanyName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
