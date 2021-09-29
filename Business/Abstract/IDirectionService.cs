using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDirectionService
    {
        IResult Add(Direction direction);
        IResult Update(Direction direction);
        IResult Delete(Direction direction);
        IDataResult<List<Direction>> GetDirectionByRecipeId(int reciepeId);

    }
}
