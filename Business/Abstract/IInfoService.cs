using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IInfoService
    {
        IResult Add(Info info);
        IResult Update(Info info);
        IResult Delete(Info info);
        IDataResult<List<Info>> GetAllInfoByByRecipeId(int recipeId);

    }
}
