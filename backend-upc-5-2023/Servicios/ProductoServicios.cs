using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    public static class ProductoServicios
    {
        public static IEnumerable<T> Get<T>()
        {
            const string nombreProcAlmacenado = "ObtenerListaProducto";
            return DBManager.Instance.GetData<T>(nombreProcAlmacenado);
        }

        public static Producto GetById(int id)
        {
            const string nombreProcAlmacenado = "ObtenerProductoPorId";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int64);
            var result = DBManager.Instance.GetDataConParametros<Producto>(nombreProcAlmacenado, parameters);
            Producto producto = result.FirstOrDefault();
            if (producto != null)
            {
                producto.Categoria = CategoriaServicios.GetById<Categoria>(producto.IdCategoria);
            }
            return result.FirstOrDefault();
        }

        public static int AddProducto(Producto producto)
        {
            const string nombreProcAlmacenado = "InsertarProducto";
            var parameters = new DynamicParameters();
            parameters.Add("Nombre", producto.Nombre, DbType.String);
            parameters.Add("IdCategoria", producto.IdCategoria, DbType.Int64);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }

        public static int UpdateProducto(Producto producto)
        {
            const string nombreProcAlmacenado = "ActualizarProducto";
            var parameters = new DynamicParameters();
            parameters.Add("Id", producto.Id, DbType.Int64);
            parameters.Add("Nombre", producto.Nombre, DbType.String);
            parameters.Add("IdCategoria", producto.IdCategoria, DbType.Int64);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }

        public static int DeleteProducto(int id)
        {
            const string nombreProcAlmacenado = "EliminarProducto";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }
    }
}
