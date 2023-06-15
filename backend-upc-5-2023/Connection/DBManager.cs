using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Connection
{
    public sealed class DBManager
    {
        #region Fields
        private static readonly object lockObj = new();
        private static DBManager? instance;
        #endregion Fields

        #region Constructors
        private DBManager() { }

        #endregion Constructors

        #region Methods

        public static DBManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new DBManager();
                    }
                }
                return instance;
            }
        }

        public string? ConnectionString { get; set; }

        public IEnumerable<T> GetData<T>(string nombreProcAlmacenado)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return connection.Query<T>(nombreProcAlmacenado, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<T> GetDataConParametros<T>(string nombreProcAlmacenado, object parameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return connection.Query<T>(nombreProcAlmacenado, parameters, commandType: CommandType.StoredProcedure);
        }

        public int SetData(string nombreProcAlmacenado, DynamicParameters dynamicParameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return connection.Execute(nombreProcAlmacenado, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        #endregion Methods
    }
}
