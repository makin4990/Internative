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
    public class RecipeManager : IRecipeService
    {
        IRecipeDal _recipeDal;

        public RecipeManager(IRecipeDal recipeDal)
        {
            _recipeDal = recipeDal;
        }

        public IResult Add(Recipe recipe)
        {
            _recipeDal.Add(recipe);
            return new SuccessResult(Messages.RecipeAdded);
        }

        public IResult Delete(Recipe recipe)
        {
            _recipeDal.Delete(recipe);
            return new SuccessResult(Messages.RecipeDeleted);
        }

        public IDataResult<PagedList<Recipe>> GetAllRecips(string search, int currentPage, int pageSize)
        {
            var result = _recipeDal.GetAll(r => r.Title.Contains(search)).ToPagedList(currentPage,pageSize);
            return new SuccessDataResult<PagedList<Recipe>>((PagedList<Recipe>)result, Messages.RecipeListed);

        }

        public IDataResult<PagedList<Recipe>> GetAllRecipsByCategoryId(int categoryId, int currentPage, int pageSize)
        {
            var result = _recipeDal.GetAll(r => r.CategoryId == categoryId).ToPagedList(currentPage,pageSize);
            return new SuccessDataResult<PagedList<Recipe>>((PagedList<Recipe>)result, Messages.RecipeListed);
        }

        public IResult Update(Recipe recipe)
        {
            _recipeDal.Update(recipe);
            return new SuccessResult(Messages.RecipeUpdated);
        }
    }
}
