﻿using Business.Abstract;
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

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("deleted.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(c => c.BrandId == id);
        }

        public void Update(Brand brand)
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
        }   }
    }
}