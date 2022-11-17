using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Mvc;
using RpgMaker.DTOs;

namespace RpgMaker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly DataContext _context;
        public EquipmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Equipment>>> Get()
        {
            return Ok(await _context.Equipment.ToListAsync());
        }

        [HttpGet("byMaterial")]
        public async Task<ActionResult<List<Equipment>>> GetName(string material)
        {
            var ematerial = await _context.Equipment
            .Where(e => e.Material == material)
            .ToListAsync();
            
            return ematerial; 
        }
        [HttpGet("byType")]
        public async Task<ActionResult<List<Equipment>>> GetType(string type)
        {
            var etype = await _context.Equipment
            .Where(e => e.Type == type)
            .ToListAsync();
            
            return etype;
            
        }
        [HttpPost("newEquipment")]
        public async Task<ActionResult<Equipment>> AddEquipment(Equipment request)
        {
            var newEquipment = new Equipment 
            {
                Type = request.Type,
                Material = request.Material,
                Armor = request.Armor,
                Durability = request.Durability
            };

            _context.Equipment.Add(newEquipment);
            return Ok(await _context.SaveChangesAsync());
        }
        [HttpPut("updateEquipment")]
        public async Task<ActionResult<List<Equipment>>> UpdateEquipment(EquipmentDto request)
        {
            var equipment = await _context.Equipment.FindAsync(request.Id);
            if(equipment == null) return BadRequest("Equipment not found");

            //equipment.Type = request.Type;
            //equipment.Material = request.Material;
            //equipment.Armor = request.Armor;
            equipment.Durability = request.Durability;
            

            await _context.SaveChangesAsync();
            return Ok(await _context.Equipment.ToListAsync());
        }
    }
}