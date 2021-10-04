using Core.Utilities.Results;
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
        IDataResult<PagedList<Recipe>> GetAllRecipes(int currentPage, int pageSize);
        IDataResult<PagedList<Recipe>> GetAllRecipesByCategoryId(int categoryId, int currentPage, int pageSize);
        IDataResult<List<Recipe>> GetLastRecipes();
        IDataResult<Recipe> GetRecipeById(int recipeId);
        IDataResult<List<Recipe>> GetPopularRecipes();
        IDataResult<PagedList<Recipe>> SearchAllRecipes(string search, int currentPage = 1, int pageSize = 5);



    }
}
