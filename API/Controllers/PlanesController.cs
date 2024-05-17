using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanesController : ControllerBase
    {
        private readonly IPlanesEntrenamiento _planesEntrenamiento;

        public PlanesController(IPlanesEntrenamiento planesEntrenamiento)
        {
            _planesEntrenamiento = planesEntrenamiento;
        }
    
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] PlanesEntrenamiento planesEntrenamiento)
        {
            var result = await this._planesEntrenamiento.GuardarPlan(planesEntrenamiento);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await this._planesEntrenamiento.ListarPlanes();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] PlanesEntrenamiento planesEntrenamiento)
        {
            var result = await this._planesEntrenamiento.ActualizarPlan(planesEntrenamiento);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] PlanesEntrenamiento planesEntrenamiento)
        {
            var result = await this._planesEntrenamiento.EliminarPlan(planesEntrenamiento);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}