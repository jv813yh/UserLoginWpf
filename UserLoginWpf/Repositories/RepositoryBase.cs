using System.Data.SqlClient;

namespace UserLoginWpf.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;

        protected RepositoryBase()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LoginDbMVVM;";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
