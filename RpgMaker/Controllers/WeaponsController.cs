using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RpgMaker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponsController : ControllerBase
    {

        private readonly DataContext _context;
        public WeaponsController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<List<Weapon>>> Get()
        {
            return Ok(await _context.Weapon.ToListAsync()); 
        }

        [HttpGet("byName")]
        public async Task<ActionResult<List<Weapon>>> GetName(string name)
        {
            var wname = await _context.Weapon
            .Where(w => w.Name == name)
            .ToListAsync();
            
            return wname; 
        }
        [HttpGet("byType")]
        public async Task<ActionResult<List<Weapon>>> GetType(string type)
        {
            var wtype = await _context.Weapon
            .Where(w => w.Type == type)
            .ToListAsync();
            
            return wtype;
            
        }


        [HttpPost("weapon")]
        public async Task<ActionResult<Character>> AddWeapon(AddWeaponDto request)
        {
            var user = await _context.Character.FindAsync(request.CharacterId);
            if(user == null)
                return NotFound();
                
            var newWeapon = new Weapon {
                Type = request.Type,
                Name = request.Name,
                Damage = request.Damage,
                Character = user
            };

            _context.Weapon.Add(newWeapon);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPut]
        public async Task<ActionResult<List<Weapon>>> UpdateWeapon(Weapon request)
        {
            var weapon = await _context.Weapon.FindAsync(request.Id);
            if(weapon == null) return BadRequest("Character not found");

            weapon.Name = request.Name;
            weapon.Type = request.Type;
            weapon.Damage = request.Damage;
            weapon.CharacterId = request.CharacterId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Weapon.ToListAsync());
        }
    }
}