using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Ingredient:IEntity
    {
       public int Id { get; }
        public string RecipeIngredient { get; set; }
        public int Quantity { get; set; }
        public int RecipeId { get; set; }

    }
}
