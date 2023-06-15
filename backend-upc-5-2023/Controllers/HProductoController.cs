using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HProductoController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        public HProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        public IActionResult GetHProducto()
        {
            try
            {
                var result = HProductoServicios.Get<HProducto>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetHProductoById")]
        public IActionResult GetHProductoById(int id)
        {
            try
            {
                var result = HProductoServicios.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddHProducto")]
        public IActionResult AddHProducto(HProducto hProducto)
        {
            try
            {
                var result = HProductoServicios.AddHProducto(hProducto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        [Route("UpdateHProducto")]
        public IActionResult UpdateHProducto(HProducto hProducto)
        {
            try
            {
                var result = HProductoServicios.UpdateHProducto(hProducto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteHProducto")]
        public IActionResult DeleteHProducto(int id)
        {
            try
            {
                var result = HProductoServicios.DeleteHProducto(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion Methods
    }
}
