using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoCompraController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        public CarritoCompraController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        public IActionResult GetCarritoCompra()
        {
            try
            {
                var result = CarritoCompraServicios.Get<CarritoCompra>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCarritoCompraById")]
        public IActionResult GetCarritoCompraById(int id)
        {
            try
            {
                var result = CarritoCompraServicios.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet]
        //[Route("GetDetalleById")]
        //public IActionResult GetDetalleById(int id)
        //{
        //    try
        //    {
        //        var result = CarritoCompraServicios.GetDetalleById(id);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpPost]
        [Route("AddCarritoCompra")]
        public IActionResult AddCarritoCompra(CarritoCompra carritoCompra)
        {
            try
            {
                var result = CarritoCompraServicios.AddCarritoCompra(carritoCompra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateCarritoCompra")]
        public IActionResult UpdateCarritoCompra(CarritoCompra carritoCompra)
        {
            try
            {
                var result = CarritoCompraServicios.UpdateCarritoCompra(carritoCompra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCarritoCompra")]
        public IActionResult DeleteCarritoCompra(int id)
        {
            try
            {
                var result = CarritoCompraServicios.DeleteCarritoCompra(id);
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
