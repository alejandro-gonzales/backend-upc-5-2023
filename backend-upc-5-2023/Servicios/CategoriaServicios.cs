using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    public static class CategoriaServicios
    {
        public static IEnumerable<T> Get<T>()
        {
            const string nombreProcAlmacenado = "ObtenerListaCategoria";
            return DBManager.Instance.GetData<T>(nombreProcAlmacenado);
        }

        public static T GetById<T>(int id)
        {
            const string nombreProcAlmacenado = "ObtenerCategoriaPorId";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.GetDataConParametros<T>(nombreProcAlmacenado, parameters);
            return result.FirstOrDefault();
        }

        public static int AddCategoria(Categoria categoria)
        {
            const string nombreProcAlmacenado = "InsertarCategoria";
            var parameters = new DynamicParameters();
            parameters.Add("Nombre", categoria.Nombre, DbType.String);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }

        public static int UpdateCategoria(Categoria categoria)
        {
            const string nombreProcAlmacenado = "ActualizarCategoria";
            var parameters = new DynamicParameters();
            parameters.Add("ID", categoria.Id, DbType.Int64);
            parameters.Add("NOMBRE", categoria.Nombre, DbType.String);
            return DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
        }

        public static int DeleteCategoria(int id)
        {
            const string nombreProcAlmacenado = "EliminarCategoria";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            return DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
        }
    }
}
