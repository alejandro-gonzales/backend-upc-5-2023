using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    public static class HProductoServicios
    {
        public static IEnumerable<T> Get<T>()
        {
            const string nombreProcAlmacenado = "ObtenerListaHProducto";
            return DBManager.Instance.GetData<T>(nombreProcAlmacenado);
        }

        public static HProducto GetById(int id)
        {
            const string nombreProcAlmacenado = "ObtenerHProductoPorId";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.GetDataConParametros<HProducto>(nombreProcAlmacenado, parameters);
            HProducto hProducto = result.FirstOrDefault();
            if (hProducto != null)
            {
                hProducto.Producto = ProductoServicios.GetById(hProducto.IdProducto);
                hProducto.CarritoCompra = CarritoCompraServicios.GetById(hProducto.IdCarritoCompra);
            }
            return result.FirstOrDefault();
        }

        //public static IEnumerable<HProducto> GetByIdCarritoCompra(int idCarritoCompra)
        //{
        //    const string nombreProcAlmacenado = "ObtenerHProductoPorId";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("idCarritoCompra", idCarritoCompra, DbType.Int64);
        //    var result = DBManager.Instance.GetDataConParametros<HProducto>(nombreProcAlmacenado, parameters);
        //    return result;
        //}

        public static int AddHProducto(HProducto hProducto)
        {
            const string nombreProcAlmacenado = "InsertarHProducto";
            var parameters = new DynamicParameters();
            parameters.Add("Cantidad", hProducto.Cantidad, DbType.Int64);
            parameters.Add("IdProducto", hProducto.IdProducto, DbType.Int64);
            parameters.Add("IdCarritoCompra", hProducto.IdCarritoCompra, DbType.Int64);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }
        public static int UpdateHProducto(HProducto hProducto)
        {
            const string nombreProcAlmacenado = "ActualizarHProducto";
            var parameters = new DynamicParameters();
            parameters.Add("Id", hProducto.Id, DbType.Int64);
            parameters.Add("Cantidad", hProducto.Cantidad, DbType.Int64);
            parameters.Add("IdProducto", hProducto.IdProducto, DbType.Int64);
            parameters.Add("IdCarritoCompra", hProducto.IdCarritoCompra, DbType.Int64);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }

        public static int DeleteHProducto(int id)
        {
            const string nombreProcAlmacenado = "EliminarHProducto";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }
    }
}
