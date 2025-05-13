using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var equipments = await _equipmentService.GetAll();
                return Ok(equipments);
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
                var equipmentById = await _equipmentService.GetById(id);
                return Ok(equipmentById);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EquipmentDTO equipmentDTO)
        {
            try
            {
                if (equipmentDTO is null)
                    return BadRequest("El equipo no puede ser nula.");

                await _equipmentService.CreateEquipment(equipmentDTO);
                return Ok();
            }catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EquipmentDTO equipmentDTO, int id)
        {
            try
            {
                if (equipmentDTO is null)
                    return BadRequest("El equipo no puede ser nulo.");

                await _equipmentService.UpdateEquipment(equipmentDTO);
                return Ok();
            }catch(ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(EquipmentDTO equipmentDTO)
        {
            try
            {
                await _equipmentService.RemoveEquipment(equipmentDTO);
                return NoContent();
            }catch(ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message } );
            }
        }
    }
}
