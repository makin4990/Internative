using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  public class Info:IEntity
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public double Difficulties { get; set; }
        public string Servings { get; set; }
        public int RecipeId { get; set; }
    }
}
