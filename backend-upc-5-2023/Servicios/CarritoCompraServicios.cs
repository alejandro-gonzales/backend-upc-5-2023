﻿// Ignore Spelling: Carrito

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="CarritoCompra"/>
    /// </summary>
    public static class CarritoCompraServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        //public static IEnumerable<T> Get<T>()
        //{
        //    const string sql = "SELECT * FROM CARRITO_COMPRA WHERE ESTADO_REGISTRO = 1";

        //    return DBManager.Instance.GetData<T>(sql);
        //}


        public static IEnumerable<CarritoCompra> Get()
        {
            const string sql = "SELECT * FROM CARRITO_COMPRA WHERE ESTADO_REGISTRO = 1";
            var enummerableCarritoCompra = DBManager.Instance.GetData<CarritoCompra>(sql);

            foreach (var item in enummerableCarritoCompra)
            {
                item.Usuarios = UsuariosServicios.GetById<Usuarios>(item.IdUsuario);
            }

            return enummerableCarritoCompra;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        //public static CarritoCompra GetById(int id)
        //{
        //    const string sql = "SELECT * FROM CARRITO_COMPRA WHERE ID = @Id AND ESTADO_REGISTRO = 1";

        //    var parameters = new DynamicParameters();
        //    parameters.Add("ID", id, DbType.Int64);

        //    var result = DBManager.Instance.GetDataConParametros<CarritoCompra>(sql, parameters);

        //    CarritoCompra carritoCompra = result.FirstOrDefault();

        //    if (carritoCompra != null)
        //    {
        //        carritoCompra.Usuarios = UsuariosServicios.GetById<Usuarios>(carritoCompra.IdUsuario);
        //    }

        //    return result.FirstOrDefault();
        //}


        public static T GetById<T>(int id) where T : CarritoCompra
        {
            const string sql = "SELECT * FROM CARRITO_COMPRA WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<T>(sql, parameters);

            T carritoCompra = result.FirstOrDefault();

            if (carritoCompra != null)
            {
                carritoCompra.Usuarios = UsuariosServicios.GetById<Usuarios>(carritoCompra.IdUsuario);
            }

            return carritoCompra;
        }

        /// <summary>
        /// Gets the detalle by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static CarritoCompra GetDetalleById(int id)
        {
            const string sql = "SELECT * FROM CARRITO_COMPRA WHERE ID = @Id AND ESTADO_REGISTRO = 1";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<CarritoCompra>(sql, parameters);

            CarritoCompra carritoCompra = result.FirstOrDefault();

            if (carritoCompra != null)
            {
                var enumerableHProducto = HProductoServicios.GetByIdCarritoCompra(carritoCompra.Id);

                foreach (var item in enumerableHProducto)
                {
                    item.Producto = ProductoServicios.GetById<Producto>(item.IdProducto);
                }

                carritoCompra.Productos = enumerableHProducto.ToList();
            }

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Inserts the specified carrito compra.
        /// </summary>
        /// <param name="carritoCompra">The carrito compra.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(CarritoCompra carritoCompra)
        {
            const string sql = "INSERT INTO CARRITO_COMPRA([FECHA], [ID_USUARIO]) VALUES (@Fecha, @IdUsuario)";
            var parameters = new DynamicParameters();
            parameters.Add("Fecha", DateTime.Now, DbType.DateTime);
            parameters.Add("IdUsuario", carritoCompra.IdUsuario, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        public static int Update(CarritoCompra carritoCompra)
        {
            const string sql = "UPDATE [CARRITO_COMPRA] SET ID_USUARIO = @IdUsuario WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", carritoCompra.Id, DbType.Int64);
            parameters.Add("Fecha", DateTime.Now, DbType.DateTime);
            parameters.Add("IdUsuario", carritoCompra.IdUsuario, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        public static int Delete(int id)
        {
            const string sql = "UPDATE [CARRITO_COMPRA] SET ESTADO_REGISTRO = 0 WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }


    }
}
