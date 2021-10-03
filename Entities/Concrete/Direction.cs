using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.Concrete
{
    public class Direction : IEntity 
    {
        public int Id { get; set; }
        public string RecipeDirection { get; set; }
        public int DirectionQueue { get; set; }
        public int RecipeId { get; set; }


    }
}
