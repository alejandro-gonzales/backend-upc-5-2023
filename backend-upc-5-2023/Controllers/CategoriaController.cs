using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        public CategoriaController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = CategoriaServicios.Get<Categoria>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCategoriaById")]
        public IActionResult GetCategoriaById(int id)
        {
            try
            {
                var result = CategoriaServicios.GetById<Categoria>(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddCategoria")]
        public IActionResult AddCategoria(Categoria categoria)
        {
            try
            {
                var result = CategoriaServicios.AddCategoria(categoria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateCategoria")]
        public IActionResult UpdateCategoria(Categoria categoria)
        {
            try
            {
                var result = CategoriaServicios.UpdateCategoria(categoria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCategoria")]
        public IActionResult DeleteCategoria(int id)
        {
            try
            {
                var result = CategoriaServicios.DeleteCategoria(id);
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
