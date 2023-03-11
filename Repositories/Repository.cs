using System.Data.SqlClient;

namespace ResumeCreator.Repositories
{
    public class Repository
    {
        #region Propiedades
        public SqlConnection masterConnection  ;
        string connectionString= "Server=(localdb)\\mssqllocaldb;Database=DBResumeCreator;Trusted_Connection=True;MultipleActiveResultSets=true";
        #endregion
        public Repository()
        {
            masterConnection= new SqlConnection(connectionString);

        }

    }

}
