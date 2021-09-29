using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Ingredient:IEntity
    {
       public int Id { get; }
        public string ReciepeIngredient { get; set; }
        public int Quantity { get; set; }
        public int ReciepeId { get; set; }

    }
}
