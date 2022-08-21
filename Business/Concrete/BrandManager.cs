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

        public IResult Add(Brand brand)
        {
            if (CheckIfNameIsLongEnough(brand.BrandName).Data == true)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            else
            {
                return new ErrorResult(Messages.InsufficientCharacterError);
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

        public IDataResult<bool> CheckIfNameIsLongEnough(string brandName)
        {
            if (brandName.Length >= 2)
            {
                return new SuccessDataResult<bool>(true);
            }
            else
            {
                return new ErrorDataResult<bool>(false);
            }
        }



        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}