using Business.Abstract;
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

        public void Add(Brand brand)
        {
            if (CheckIfNameIsLongEnough(brand.BrandName))
            {
                _brandDal.Add(brand);
            }
            else
            {
                throw new Exception("Araba ismi 2 karakterden uzun olmalıdır.");
            }
        }


        //public int Add2(Brand brand)
        //{
        //    if (CheckIfNameIsLongEnough(brand.BrandName))
        //    {
        //        _brandDal.Add(brand);
        //        return 1;
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}

        public bool CheckIfNameIsLongEnough(string brandName)
        {
            return brandName.Length >= 2;
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(b => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }


    }
}
