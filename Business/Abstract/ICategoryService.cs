using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
        IDataResult<Category> GetCategoryById(int categoryId);
        IDataResult<PagedList<Category>> GetAllCategory(int currentPage, int pageSize);


    }
}
