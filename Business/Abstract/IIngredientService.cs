using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IIngredientService
    {
        IResult Add(Ingredient ingredient);
        IResult Update(Ingredient ingredient);
        IResult Delete(Ingredient ingredient);
        IDataResult<List<Ingredient>> GetAllIngredientsByRecipeId(int reciepeId);
    }
}
