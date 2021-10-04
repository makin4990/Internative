﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using X.PagedList;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class RecipeManager : IRecipeService
    {
        IRecipeDal _recipeDal;

        public RecipeManager(IRecipeDal recipeDal)
        {
            _recipeDal = recipeDal;
        }


        [SecuredOperation("recipe.add,moderator,admin")]
        [ValidationAspect(typeof(RecipeValidator))]
        public IResult Add(Recipe recipe)
        {
            IResult result = BusinessRules.Run(

                CheckIfRecipeNameExists(recipe.Title),
                CheckIfRecipeIdExists(recipe.Id));
            if (result != null)
                return result;
            _recipeDal.Add(recipe);
            return new SuccessResult(Messages.RecipeAdded);
        }


        [SecuredOperation("recipe.add,moderator,admin")]
        [ValidationAspect(typeof(RecipeValidator))]
        public IResult Delete(Recipe recipe)
        {
            IResult result = BusinessRules.Run(
                CheckIfRecipeIdNotExists(recipe.Id));
            if (result != null)
                return result;
            _recipeDal.Delete(recipe);
            return new SuccessResult(Messages.RecipeDeleted);
        }

        
        public IDataResult<PagedList<Recipe>> GetAllRecipes(int currentPage=1, int pageSize=5)
        {
            var result = _recipeDal.GetAll().ToPagedList(currentPage, pageSize);
            return new SuccessDataResult<PagedList<Recipe>>((PagedList<Recipe>)result, Messages.RecipeListed);

        }

        public IDataResult<PagedList<Recipe>> SearchAllRecipes(string search, int currentPage = 1, int pageSize = 5)
        {
            var result = _recipeDal.GetAll(r => r.Title.Contains(search)).ToPagedList(currentPage, pageSize);
            return new SuccessDataResult<PagedList<Recipe>>((PagedList<Recipe>)result, Messages.RecipeListed);

        }

        public IDataResult<PagedList<Recipe>> GetAllRecipesByCategoryId(int categoryId, int currentPage=1, int pageSize=5)
        {
            var result = _recipeDal.GetAll(r => r.CategoryId == categoryId).ToPagedList(currentPage, pageSize);
            return new SuccessDataResult<PagedList<Recipe>>((PagedList<Recipe>)result, Messages.RecipeListed);
        }


        public IDataResult<List<Recipe>> GetLastRecipes()
        {
            var result = _recipeDal.GetAll().OrderByDescending(r => r.Id).Take(10).ToList();
            return new SuccessDataResult<List<Recipe>>(result, Messages.RecipeListed);

        }

        public IDataResult<Recipe> GetRecipeById(int recipeId)
        {
            var result = _recipeDal.Get(r => r.Id == recipeId);
            IncreasePopularity(result);

            return new SuccessDataResult<Recipe>(result, Messages.RecipeListed);
        }

        public IDataResult<List<Recipe>> GetPopularRecipes()
        {
            var result = _recipeDal.GetAll().OrderByDescending(c => c.Popularity).Take(10).ToList();
            return new SuccessDataResult<List<Recipe>>(result, Messages.RecipeListed);
        }

        
        [SecuredOperation("recipe.add,moderator,admin")]
        [ValidationAspect(typeof(RecipeValidator))]
        public IResult Update(Recipe recipe)
        {
            _recipeDal.Update(recipe);
            return new SuccessResult(Messages.RecipeUpdated);
        }

        private IResult CheckIfRecipeNameExists(string recipeTitle)
        {
            var result = _recipeDal.GetAll(r => r.Title == recipeTitle).Any();
            if (result)
            {
                return new ErrorResult(Messages.RecipeNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfRecipeIdExists(int recipeId)
        {
            var result = _recipeDal.GetAll(r => r.Id == recipeId).Any();
            if (result)
            {
                return new ErrorResult(Messages.RecipeIdDoesntExist);
            }
            return new SuccessResult();

        }
        private IResult CheckIfRecipeIdNotExists(int recipeId)
        {
            var result = _recipeDal.GetAll(r => r.Id == recipeId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.RecipeIdDoesntExist);
            }
            return new SuccessResult();

        }

        private void IncreasePopularity(Recipe recipe)
        {
            recipe.Popularity++;
            _recipeDal.Update(recipe);
        }
    }
}