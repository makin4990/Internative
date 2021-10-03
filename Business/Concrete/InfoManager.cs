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
    public class InfoManager : IInfoService
    {
        IInfoDal _infoDal;

        public InfoManager(IInfoDal infoDal)
        {
            _infoDal = infoDal;
        }


        [SecuredOperation("recipe.add,moderator,admin")]
        public IResult Add(Info info)
        {
            _infoDal.Add(info);
            return new SuccessResult(Messages.InfoAdded);
        }




        [SecuredOperation("recipe.add,moderator,admin")]
        public IResult Delete(Info info)
        {
            _infoDal.Delete(info);
            return new SuccessResult(Messages.InfoDeleted);
        }

        public IDataResult<List<Info>> GetAllInfoByByRecipeId(int recipeId)
        {
            return new SuccessDataResult<List<Info>>(_infoDal.GetAll(i => i.RecipeId == recipeId), Messages.InfoListed);
        }


        [SecuredOperation("recipe.add,moderator,admin")]
        public IResult Update(Info info)
        {
            _infoDal.Update(info);
            return new SuccessResult(Messages.InfoUpdated);
        }
    }
}
