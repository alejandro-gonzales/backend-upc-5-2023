using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        public IActionResult GetProducto()
        {
            try
            {
                var result = ProductoServicios.Get<Producto>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetProductoById")]
        public IActionResult GetProductoById(int id)
        {
            try
            {
                var result = ProductoServicios.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProducto")]
        public IActionResult AddProducto(Producto producto)
        {
            try
            {
                var result = ProductoServicios.AddProducto(producto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateProducto")]
        public IActionResult UpdateProducto(Producto producto)
        {
            try
            {
                var result = ProductoServicios.UpdateProducto(producto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProducto")]
        public IActionResult DeleteProducto(int id)
        {
            try
            {
                var result = ProductoServicios.DeleteProducto(id);
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