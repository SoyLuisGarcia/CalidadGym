using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembresiasController : ControllerBase
    {
        private readonly IMembresias _membresias;

        public MembresiasController(IMembresias membresias)
        {
            _membresias = membresias;
        }
    
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Membresias membresias)
        {
            var result = await this._membresias.GuardarMembresia(membresias);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await this._membresias.ListarMembresia();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Membresias membresias)
        {
            var result = await this._membresias.ActualizarMembresia(membresias);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] Membresias membresias)
        {
            var result = await this._membresias.EliminarMembresia(membresias);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}