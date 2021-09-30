using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  public class Info:IEntity
    {
        public int Id { get;}
        public TimeSpan Time { get; set; }
        public double Difficulties { get; set; }
        public int Servings { get; set; }
        public int RecipeId { get; set; }
    }
}
