using Core.Entities;
using Core.Utilities.Mapping.AutoMapper;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class ReciepeDto:IDto,IMapFrom<Recipe>
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
    }
}
