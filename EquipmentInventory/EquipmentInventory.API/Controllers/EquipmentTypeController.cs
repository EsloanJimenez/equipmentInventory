using EquipmentInventory.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTypeController : ControllerBase
    {
        private readonly IEquipmentTypeService _equipmentTypeService;
        public EquipmentTypeController(IEquipmentTypeService equipmentService)
        {
            _equipmentTypeService = equipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var equipmentType = await _equipmentTypeService.GetAll();
                return Ok(equipmentType);
            } catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }
    }
}
