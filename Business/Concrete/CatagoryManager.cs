using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

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
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<PagedList<Category>> GetAllCategory(int currentPage, int pageSize)
        {
            var result = _categoryDal.GetAll().ToPagedList(currentPage,pageSize);
            return new SuccessDataResult<PagedList<Category>>((PagedList<Category>)result,Messages.CategoryListed);
        }

        public IDataResult<Category> GetCategoryById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == categoryId));
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
