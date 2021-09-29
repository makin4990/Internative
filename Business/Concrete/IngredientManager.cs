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
    public class IngredientManager : IIngredientService
    {
        IIngredientDal _ingredientDal;
        public IResult Add(Ingredient ingredient)
        {
            _ingredientDal.Add(ingredient);
            return new SuccessResult(Messages.IngredientAdded);
        }

        public IResult Delete(Ingredient ingredient)
        {
            _ingredientDal.Delete(ingredient);
            return new SuccessResult(Messages.IngredientDeleted);
        }

        public IDataResult<List<Ingredient>> GetAllIngredientsByRecipeId(int recipeId)
        {
            return new SuccessDataResult<List<Ingredient>>(_ingredientDal.GetAll(i => i.ReciepeId == recipeId), Messages.IngredientListed);
        }

        public IResult Update(Ingredient ingredient)
        {
            _ingredientDal.Update(ingredient);
            return new SuccessResult(Messages.IngredientUpdated);
        }
    }
}
