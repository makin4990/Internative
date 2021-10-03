using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class IngredientManager : IIngredientService
    {
        IIngredientDal _ingredientDal;

        public IngredientManager(IIngredientDal ingredientDal)
        {
            _ingredientDal = ingredientDal;
        }

        [SecuredOperation("recipe.add,moderator,admin")]
        public IResult Add(Ingredient ingredient)
        {
            _ingredientDal.Add(ingredient);
            return new SuccessResult(Messages.IngredientAdded);
        }


        [SecuredOperation("recipe.add,moderator,admin")]
        public IResult Delete(Ingredient ingredient)
        {
            _ingredientDal.Delete(ingredient);
            return new SuccessResult(Messages.IngredientDeleted);
        }

        public IDataResult<List<Ingredient>> GetAllIngredientsByRecipeId(int recipeId)
        {
            return new SuccessDataResult<List<Ingredient>>(_ingredientDal.GetAll(i => i.RecipeId == recipeId), Messages.IngredientListed);
        }


        [SecuredOperation("recipe.add,moderator,admin")]
        public IResult Update(Ingredient ingredient)
        {
            _ingredientDal.Update(ingredient);
            return new SuccessResult(Messages.IngredientUpdated);
        }
    }
}
