using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceTaskController : ControllerBase
    {
        private readonly IMaintenanceTaskService _maintenanceTaskService;
        public MaintenanceTaskController(IMaintenanceTaskService maintenanceTaskService)
        {
            _maintenanceTaskService = maintenanceTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var maintenanceTask = await _maintenanceTaskService.GetAll();
                return Ok(maintenanceTask);
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
                var maintenanceTask = await _maintenanceTaskService.GetById(id);
                return Ok(maintenanceTask);
            }catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(MaintenanceTaskDTO maintenanceTaskDTO)
        {
            try
            {
                if (maintenanceTaskDTO is null)
                    return BadRequest("La tarea de manteniminto no puede estar nula.");

                await _maintenanceTaskService.CreateMaintenanceTask(maintenanceTaskDTO);

                return Ok();
            }catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(MaintenanceTaskDTO maintenanceTaskDTO)
        {
            try
            {
                if (maintenanceTaskDTO is null)
                    return BadRequest("La tarea de mantenimiento no puede estar nula.");

                await _maintenanceTaskService.UpdateMaintenanceTask(maintenanceTaskDTO);
                return Ok();
            }catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(MaintenanceTaskDTO maintenanceTaskDTO)
        {
            try
            {
                await _maintenanceTaskService.RemoveMaintenanceTask(maintenanceTaskDTO);
                return NoContent();
            }catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
