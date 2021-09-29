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
    public class DirectionManager : IDirectionService
    {
        IDirectionDal _directionDal;

        public DirectionManager(IDirectionDal directionDal)
        {
            _directionDal = directionDal;
        }

        public IResult Add(Direction direction)
        {
            _directionDal.Add(direction);
            return new SuccessResult(Messages.DirectionAdded);
        }

        public IResult Delete(Direction direction)
        {
            _directionDal.Delete(direction);
            return new SuccessResult(Messages.DirectionDeleted);
        }

        public IDataResult<List<Direction>> GetDirectionByRecipeId(int recipeId)
        {
            return new SuccessDataResult<List<Direction>>(_directionDal.GetAll(d => d.RecipeId == recipeId),Messages.DirectionListed);
        }

        public IResult Update(Direction direction)
        {
            _directionDal.Update(direction);
            return new SuccessResult(Messages.DirectionUpdated);
        }
    }
}
