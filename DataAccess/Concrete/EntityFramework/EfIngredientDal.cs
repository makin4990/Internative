﻿using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfIngredientDal:EfEntityRepositoryBase<Ingredient, RecipeBookDbContext>,IIngredientDal
    {
    }
}
