using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        public UsuariosController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            try
            {
                var result = UsuariosServicios.Get<Usuarios>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUsuariosById")]
        public IActionResult GetUsuariosById(int id)
        {
            try
            {
                var result = UsuariosServicios.GetById<Usuarios>(id);
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
        [Route("AddUsuario")]
        public IActionResult AddUsuario(Usuarios usuario)
        {
            try
            {
                var result = UsuariosServicios.AddUsuario(usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateUsuario")]
        public IActionResult UpdateUsuario(Usuarios usuario)
        {
            try
            {
                var result = UsuariosServicios.UpdateUsuario(usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUsuario")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                var result = UsuariosServicios.DeleteUsuario(id);
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
