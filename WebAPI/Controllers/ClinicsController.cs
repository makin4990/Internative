using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        IClinicService _clinicService;
        IStringLocalizer<ClinicsController> _localizer;

        public ClinicsController(IClinicService clinicService, IStringLocalizer<ClinicsController> localizer)
        {
            _clinicService = clinicService;
            _localizer = localizer;
        }

        [HttpGet("getallclinics")]
        public IActionResult GetAllClinic()
        {
            var result = _clinicService.GetAll();
            return result.Success ? Ok(result) : BadRequest();

        }
        [HttpGet("getallclinicswithequipments")]
        public IActionResult GetAllClinicWithEquipments(string sort, int currentPage ,int pageSize)
        {
          
            if (currentPage == 0)
                currentPage = 1;
            if (pageSize == 0)
                pageSize = 5;
            if (sort == null)
                sort = "name";
            var result = _clinicService.GetAllClinicWithEquipment(sort,currentPage, pageSize);
            
            return result.Success ? Ok(result) : BadRequest();

        }



        [HttpGet("getclinicbyid")]
        public IActionResult GetClinicById(int clinicId)
        {
            var result = _clinicService.GetById(clinicId);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpGet("getclinicbyidwithequipments")]
        public IActionResult GetClinicByIdWithEquipments(int clinicId)
        {
            var result = _clinicService.GetClinicByIdWithEquipment(clinicId);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpGet("getclinicbysearch")]
        public IActionResult GetClinicBySearch(string search)
        {
            var result = _clinicService.GetAllClinicBySearchWithEquipment(search);
            return result.Success ? Ok(result) : BadRequest();
        }


        [HttpPost("create")]
        public IActionResult Create(Clinic clinic)
        {
          
            var result = _clinicService.Create(clinic);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Clinic clinic)
        {
            var result = _clinicService.Update(clinic);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int clinicId)
        {
            var result = _clinicService.Delete(clinicId);
            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
