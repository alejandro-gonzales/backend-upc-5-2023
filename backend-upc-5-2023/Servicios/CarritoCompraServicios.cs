using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    public static class CarritoCompraServicios
    {
        public static IEnumerable<T> Get<T>()
        {
            const string nombreProcAlmacenado = "ObtenerListaCarritoCompra";
            return DBManager.Instance.GetData<T>(nombreProcAlmacenado);
        }

        public static CarritoCompra GetById(int id)
        {
            const string nombreProcAlmacenado = "ObtenerCarritoCompraPorId";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.GetDataConParametros<CarritoCompra>(nombreProcAlmacenado, parameters);
            CarritoCompra carritoCompra = result.FirstOrDefault();
            if (carritoCompra != null)
            {
                carritoCompra.Usuarios = UsuariosServicios.GetById<Usuarios>(carritoCompra.IdUsuario);
            }
            return result.FirstOrDefault();
        }

        //public static CarritoCompra GetDetalleById(int id)
        //{
        //    const string nombreProcAlmacenado = "ObtenerCarritoCompraPorId";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("ID", id, DbType.Int64);
        //    var result = DBManager.Instance.GetDataConParametros<CarritoCompra>(nombreProcAlmacenado, parameters);
        //    CarritoCompra carritoCompra = result.FirstOrDefault();

        //    if (carritoCompra != null)
        //    {
        //        var enumerableHProducto = HProductoServicios.GetByIdCarritoCompra(carritoCompra.Id);
        //        foreach (var item in enumerableHProducto)
        //        {
        //            item.Producto = ProductoServicios.GetById(item.IdProducto);
        //        }
        //        carritoCompra.Productos = enumerableHProducto.ToList();
        //    }
        //    return result.FirstOrDefault();
        //}

        public static int AddCarritoCompra(CarritoCompra carritoCompra)
        {
            const string nombreProcAlmacenado = "InsertarCarritoCompra";
            var parameters = new DynamicParameters();
            parameters.Add("IdUsuario", carritoCompra.IdUsuario, DbType.Int64);
            parameters.Add("Fecha", DateTime.Now, DbType.DateTime);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }

        public static int UpdateCarritoCompra(CarritoCompra carritoCompra)
        {
            const string nombreProcAlmacenado = "ActualizarCarritoCompra";
            var parameters = new DynamicParameters();
            parameters.Add("Id", carritoCompra.Id, DbType.Int64);
            parameters.Add("IdUsuario", carritoCompra.IdUsuario, DbType.Int64);
            parameters.Add("Fecha", DateTime.Now, DbType.DateTime);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }

        public static int DeleteCarritoCompra(int id)
        {
            const string nombreProcAlmacenado = "EliminarCarritoCompra";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }
    }
}
