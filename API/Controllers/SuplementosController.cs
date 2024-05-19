using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuplementosController : ControllerBase
    {
        private readonly ISuplementos _suplementos;

        public SuplementosController(ISuplementos suplementos)
        {
            _suplementos = suplementos;
        }
    
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Suplementos suplementos)
        {
            var result = await this._suplementos.GuardarSuplementos(suplementos);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await this._suplementos.ListarSuplementos();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Suplementos suplementos)
        {
            var result = await this._suplementos.ActualizarSuplementos(suplementos);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] Suplementos suplementos)
        {
            var result = await this._suplementos.EliminarSuplementos(suplementos);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}