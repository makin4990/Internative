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
    public class DirectionManager : IDirectionService
    {
        IDirectionDal _directionDal;

        public DirectionManager(IDirectionDal directionDal)
        {
            _directionDal = directionDal;
        }

        [SecuredOperation("recipe.add,moderator,admin")]
        public IResult Add(Direction direction)
        {
            _directionDal.Add(direction);
            return new SuccessResult(Messages.DirectionAdded);
        }


        [SecuredOperation("recipe.add,moderator,admin")]
        public IResult Delete(Direction direction)
        {
            _directionDal.Delete(direction);
            return new SuccessResult(Messages.DirectionDeleted);
        }

        public IDataResult<List<Direction>> GetDirectionByRecipeId(int recipeId)
        {
            return new SuccessDataResult<List<Direction>>(_directionDal.GetAll(d => d.RecipeId == recipeId),Messages.DirectionListed);
        }


        [SecuredOperation("recipe.add,moderator,admin")]
        public IResult Update(Direction direction)
        {
            _directionDal.Update(direction);
            return new SuccessResult(Messages.DirectionUpdated);
        }
    }
}
