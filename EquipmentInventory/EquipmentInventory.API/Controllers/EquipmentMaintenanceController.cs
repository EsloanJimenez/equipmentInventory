using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentMaintenanceController : ControllerBase
    {
        private readonly IEquipmentMaintenanceService _equipmentMaintenanceService;
        public EquipmentMaintenanceController(IEquipmentMaintenanceService equipmentMaintenanceService)
        {
            _equipmentMaintenanceService = equipmentMaintenanceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var equipmentMaintenance = await _equipmentMaintenanceService.GetAll();
                return Ok(equipmentMaintenance);
            }catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var equipmentMaintenance = await _equipmentMaintenanceService.GetById(id);
                return Ok(equipmentMaintenance);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("task/{taskId}/equipments")]
        public async Task<IActionResult> GetEquipments(int taskId)
        {
            try
            {
                var equipments = await _equipmentMaintenanceService.GetEquimentsIdsByTaskId(taskId);
                return Ok(equipments);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(EquipmentMaintenanceDTO equipmentMaintenanceDTO)
        {
            try
            {
                await _equipmentMaintenanceService.CreateEquipmentMaintenance(equipmentMaintenanceDTO);
                return Ok();
            }catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EquipmentMaintenanceDTO equipmentMaintenanceDTO)
        {
            try
            {
                await _equipmentMaintenanceService.UpdateEquipmentMaintenance(equipmentMaintenanceDTO);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(EquipmentMaintenanceDTO equipmentMaintenanceDTO)
        {
            try
            {
                await _equipmentMaintenanceService.RemoveEquipmentMaintenance(equipmentMaintenanceDTO);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
