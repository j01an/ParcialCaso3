using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcialCaso3.DOMAIN.Core.Entities;
using ParcialCaso3.DOMAIN.Core.Interfaces;

namespace ParcialCaso3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        // Para Listar todos los jugadores - CASO 03: Player + Web API + Controller con endpoint
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _playerRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _playerRepository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // Para agregar nuevos jugadores - CASO 03: Player + Web API + Controller con endpoint
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Player player)
        {
            var result = await _playerRepository.Insert(player);
            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Player player)
        {
            var result = await _playerRepository.Update(player);
            if (!result)
                return BadRequest(result);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _playerRepository.Delete(id);
            if (!result)
                return NotFound(result);

            return Ok(result);
        }

    }
}
