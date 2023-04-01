using ResumeCreator.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace ResumeCreator.Repositories
{
    public class ProfileDataRepository : Repository // VER MÉTODOS ABSTRACTOS!!!!!!!!!!
    {
        public List<ProfileData> GetAll()
        {

            List<ProfileData> list = new List<ProfileData>();
            var connection = this.masterConnection;
            SqlCommand command = new SqlCommand("dbo.ProfileDataGetAll", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;


            connection.Open();
            var reader = command.ExecuteReader();
            bool isStillData = reader.Read();
            while (isStillData == true)
            {
                //TODO check for null data incoming from DB
                ProfileData dataItem = new ProfileData();
                dataItem.Id = Convert.ToInt32(reader.GetValue(0).ToString());
                dataItem.DependentId  = Convert.ToInt32(reader.GetValue(1));
                dataItem.UserName = Convert.ToString(reader.GetValue(2));
                dataItem.Email = Convert.ToString(reader.GetValue(3));
                dataItem.DNI = Convert.ToString(reader.GetValue(4));
                dataItem.UserAddress = Convert.ToString(reader.GetValue(5));
                dataItem.IsMainProfile = Convert.ToBoolean(reader.GetValue(6));

                list.Add(dataItem);

                isStillData = reader.Read();
            }

            connection.Close();
            return list;
        }

        public ProfileData Get(int userId)
        {

            var connection = this.masterConnection;
            SqlCommand command = new SqlCommand("dbo.ProfileDataGet", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            connection.Open();
            var reader = command.ExecuteReader();
            bool isStillData = reader.Read();
            
            ProfileData dataItem = new ProfileData();
            while (isStillData == true)
            {
                //TODO check for null data incoming from DB
                
                dataItem.Id = Convert.ToInt32(reader.GetValue(0).ToString());
                dataItem.DependentId = Convert.ToInt32(reader.GetValue(1));
                dataItem.UserName = Convert.ToString(reader.GetValue(2));
                dataItem.Email = Convert.ToString(reader.GetValue(3));
                dataItem.DNI = Convert.ToString(reader.GetValue(4));
                dataItem.UserAddress = Convert.ToString(reader.GetValue(5));
                dataItem.IsMainProfile = Convert.ToBoolean(reader.GetValue(6));

                
                isStillData = reader.Read();
            }

            connection.Close();
            return dataItem;
        }


        public void Save( ProfileData entry)
        {
            var connection = this.masterConnection;
            SqlCommand command = new SqlCommand("dbo.ProfileDataSave",connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@DependentId", SqlDbType.Int).Value = entry.DependentId;
            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entry.UserName == null ? DBNull.Value : entry.UserName ;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = entry.Email == null ? DBNull.Value : entry.Email;
            command.Parameters.Add("@DNI", SqlDbType.VarChar).Value = entry.DNI == null ? DBNull.Value : entry.DNI;
            command.Parameters.Add("@UserAddress", SqlDbType.VarChar).Value = entry.UserAddress == null ? DBNull.Value : entry.UserAddress ; 
            command.Parameters.Add("@IsMainProfile", SqlDbType.Bit).Value = entry.IsMainProfile;
            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        internal void Update(ProfileData entry)
        {
            var connection = this.masterConnection;
            SqlCommand command = new SqlCommand("dbo.ProfileDataUpdate", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@UserId", SqlDbType.Int).Value = entry.Id;
            command.Parameters.Add("@DependentId", SqlDbType.Int).Value = entry.DependentId;
            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entry.UserName == null ? DBNull.Value : entry.UserName;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = entry.Email == null ? DBNull.Value : entry.Email;
            command.Parameters.Add("@DNI", SqlDbType.VarChar).Value = entry.DNI == null ? DBNull.Value : entry.DNI;
            command.Parameters.Add("@UserAddress", SqlDbType.VarChar).Value = entry.UserAddress == null ? DBNull.Value : entry.UserAddress;
            command.Parameters.Add("@IsMainProfile", SqlDbType.Bit).Value = entry.IsMainProfile;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void Delete(int id)
        {
            var connection = this.masterConnection;
            SqlCommand command = new SqlCommand("dbo.ProfileDataDelete", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
