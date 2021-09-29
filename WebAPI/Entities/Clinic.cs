using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Clinic
    {
       
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Equipments")]
        public virtual List<Equipment> Equipments { get; set; }
    }
}
