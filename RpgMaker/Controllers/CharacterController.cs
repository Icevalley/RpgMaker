using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgMaker.Data;

namespace RpgMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;
        public CharacterController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var character = await _context.Character
            .Where(c => c.UserId == userId)
            .Include(c => c.Weapon)
            .ToListAsync();

            return character;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CreateCharacterDto request)
        {
            var user = await _context.User.FindAsync(request.UserId);
            if(user == null)
                return NotFound();
                
            var newCharacter = new Character {
                Name = request.Name,
                Class = request.Class,
                User = user
            };

            _context.Character.Add(newCharacter);
            await _context.SaveChangesAsync();

            return await Get(newCharacter.UserId);
        }

        [HttpPut]
        public async Task<ActionResult<List<Character>>> UpdateCharacter(CreateCharacterDto request)
        {
            var character = await _context.Character.FindAsync(request.Id);
            if(character == null) return BadRequest("Character not found");

            character.Name = request.Name;
            character.Class = request.Class;
            character.Id = request.Id;

            await _context.SaveChangesAsync();

            return Ok(await _context.Character.ToListAsync());
        }
    }
}