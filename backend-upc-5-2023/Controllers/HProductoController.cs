﻿using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="HProducto"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class HProductoController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HProductoController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public HProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SqlException"></exception>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                const string sql = "select * from H_PRODUCTO  WHERE ESTADO_REGISTRO = 1";

                var result = DBManager.Instance.GetData<HProducto>(sql);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetHProductoById")]
        public IActionResult GetHProductoById(int Id)
        {
            try
            {
                const string sql = "SELECT * FROM H_PRODUCTO WHERE ID = @Id AND ESTADO_REGISTRO = 1";

                var parameters = new DynamicParameters();
                parameters.Add("ID", Id, DbType.Int64);

                var result = DBManager.Instance.GetDataConParametros<HProducto>(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddHProducto")]
        public IActionResult Insert(HProducto hProducto)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[H_PRODUCTO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (@Cantidad, @IdProducto, @IdCarritoCompra) ";

                var parameters = new DynamicParameters();
                parameters.Add("Cantidad", hProducto.Cantidad, DbType.Int64);
                parameters.Add("IdProducto", hProducto.IdProducto, DbType.Int64);
                parameters.Add("IdCarritoCompra", hProducto.IdCarritoCompra, DbType.Int64);

                var result = DBManager.Instance.SetData(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateHProducto")]
        public IActionResult Update(HProducto hProducto)
        {
            try
            {
                const string sql = "UPDATE [dbo].[H_PRODUCTO] SET CANTIDAD = @Cantidad, ID_PRODUCTO = @IdProducto, ID_CARRITO_COMPRA = @IdCarritoCompra WHERE ID = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("ID", hProducto.Id, DbType.Int64);
                parameters.Add("Cantidad", hProducto.Cantidad, DbType.Int64);
                parameters.Add("IdProducto", hProducto.IdProducto, DbType.Int64);
                parameters.Add("IdCarritoCompra", hProducto.IdCarritoCompra, DbType.Int64);

                var result = DBManager.Instance.SetData(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("DeleteHProducto")]
        public IActionResult Delete(int id)
        {
            try
            {
                const string sql = "UPDATE [dbo].[H_PRODUCTO] SET ESTADO_REGISTRO = 0 WHERE ID = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("ID", id, DbType.Int64);

                var result = DBManager.Instance.SetData(sql, parameters);
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
