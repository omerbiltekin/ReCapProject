using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandMaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand> (_brandDal.Get(c => c.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            {
                if (brand.BrandName.Length >= 2)
                {
                    _brandDal.Update(brand);
                    Console.WriteLine("updated.");
                }
                else
                {
                    Console.WriteLine($"Please " +
                    $" Enter the length of the brand name more than 1 character. Brand name :  {brand.BrandName}");
                }
              
                return new SuccessResult(Messages.ColorUpdated);
            }
        }
    }
}
