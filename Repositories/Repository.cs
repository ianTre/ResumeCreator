using System.Data.SqlClient;

namespace ResumeCreator.Repositories
{
    public class Repository
    {
        #region Propiedades
        public SqlConnection connection  ;
        string connectionString= "Server=(localdb)\\mssqllocaldb;Database=DBResumeCreator;Trusted_Connection=True;MultipleActiveResultSets=true";
        #endregion
        public Repository()
        {
            connection= new SqlConnection(connectionString);

        }

    }

}
