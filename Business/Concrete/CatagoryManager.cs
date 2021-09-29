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
    public class CatagoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CatagoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.ClinicsAdded);
        }

        public IResult Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Category> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Category> GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
