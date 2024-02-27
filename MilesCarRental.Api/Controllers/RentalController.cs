using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.DTO.Request;
using MilesCarRental.Application.DTO.Response;
using MilesCarRental.Application.Services;
using MilesCarRental.Application.Services.Interfaces;
using MilesCarRental.Domain.Exceptions;

namespace MilesCarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RentalController : ControllerBase
    {
        private readonly IAlquilerServices _alquilerServices;

        public RentalController(IAlquilerServices alquilerServices)
        {
            this._alquilerServices = alquilerServices;
        }

        /// <summary>
        /// Se encarga de asignar el alquiler de los vehículos al cliente según disponibilidad.
        /// </summary>
        /// <param name="alquilerRequestDTO">El modelo que se usa para crear el alquiler del vehículo.</param>
        /// <returns></returns>
        /// <response code="201">Devuelve indicando que fue creado el Alquiler correctamente</response>
        /// <response code="400">Indica error con los datos o alerta.</response>
        /// <response code="500">Devuelve alguna excepción controlada.</response>
        [HttpPost("CreateRental")]
        public async Task<IActionResult> CreateRental([FromBody] AlquilerRequestDTO alquilerRequestDTO)
        {
            try
            {
                await _alquilerServices.CreateRental(alquilerRequestDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (DomainValidateException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseError
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = $"Errors: {ex.Message}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Se presento un error al registrar el alquiler del vehículo." + ex.Message
                });
            }
        }
    }
}
