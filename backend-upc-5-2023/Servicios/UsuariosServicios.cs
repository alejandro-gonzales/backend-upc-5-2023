using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    public static class UsuariosServicios
    {
        public static IEnumerable<T> Get<T>()
        {
            const string nombreProcAlmacenado = "ObtenerListaUsuarios";
            return DBManager.Instance.GetData<T>(nombreProcAlmacenado);
        }

        public static T GetById<T>(int id)
        {
            const string nombreProcAlmacenado = "ObtenerUsuarioPorId";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.GetDataConParametros<T>(nombreProcAlmacenado, parameters);
            return result.FirstOrDefault();
        }

        public static int AddUsuario(Usuarios usuarios)
        {
            const string nombreProcAlmacenado = "InsertarUsuario";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", usuarios.UserName, DbType.String);
            parameters.Add("NombreCompleto", usuarios.NombreCompleto, DbType.String);
            parameters.Add("Password", usuarios.Password, DbType.String);
            var result = DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
            return result;
        }

        public static int UpdateUsuario(Usuarios usuarios)
        {
            const string nombreProcAlmacenado = "ActualizarUsuario";
            var parameters = new DynamicParameters();
            parameters.Add("ID", usuarios.Id, DbType.Int64);
            parameters.Add("UserName", usuarios.UserName, DbType.String);
            parameters.Add("NombreCompleto", usuarios.NombreCompleto, DbType.String);
            parameters.Add("Password", usuarios.Password, DbType.String);
            return DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
        }

        public static int DeleteUsuario(int id)
        {
            const string nombreProcAlmacenado = "EliminarUsuario";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            return DBManager.Instance.SetData(nombreProcAlmacenado, parameters);
        }
    }
}
