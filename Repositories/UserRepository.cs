using ResumeCreator.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ResumeCreator.Repositories
{
    public class UserRepository : Repository
    {
        public UserRepository() 
        {
            
        }

        public int Save(User entry)

        {
            try
            {
                var connection = this.masterConnection;

                SqlCommand command = new SqlCommand("dbo.UserSave", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entry.UserName;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = entry.Email == null ? DBNull.Value : entry.Email;
                command.Parameters.Add("@DNI", SqlDbType.VarChar).Value = entry.DNI;
                command.Parameters.Add("@UserAddress", SqlDbType.VarChar).Value = entry.UserAddress == null ? DBNull.Value : entry.UserAddress;
                command.Parameters.Add("@Age", SqlDbType.Int).Value = entry.Age;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = entry.Password == null ? DBNull.Value : entry.Password;


                connection.Open();
                command.ExecuteNonQuery();
                string Id = command.Parameters["@id"].Value.ToString();
                connection.Close();
                return int.Parse(Id);
                

            }
            catch (Exception ex)
            {

                throw ex;
            }

             
        }
    }
}
