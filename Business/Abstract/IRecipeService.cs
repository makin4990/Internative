﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Business.Abstract
{
    public interface IRecipeService
    {
        IResult Add(Recipe recipe);
        IResult Update(Recipe recipe);
        IResult Delete(Recipe recipe);
        IDataResult<PagedList<Recipe>> GetAllRecips(string search, int currentPage, int pageSize);
        IDataResult<PagedList<Recipe>> GetAllRecipsByCategoryId(int categoryId, int currentPage, int pageSize);
        IDataResult<List<Recipe>> GetLastRecipes();
       


    }
}
