using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        IEquipmentService _equipmentService;

        public EquipmentsController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }


        [HttpGet("getallequipment")]
        public IActionResult GetAllEquipment()
        {
            var result = _equipmentService.GetAll();
            return result.Success ? Ok(result) : BadRequest();
        }


        [HttpGet("getallequipmentbyId")]
        public IActionResult GetAllEquipmentById(int equipmentId)
        {
            var result = _equipmentService.GetById(equipmentId);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("create")]
        public IActionResult Create(Equipment equipment)
        {
            var result = _equipmentService.Create(equipment);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Equipment equipment)
        {
            var result = _equipmentService.Update(equipment);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Delete(int equipmentId)
        {
            var result = _equipmentService.Delete(equipmentId);
            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
