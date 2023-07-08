using ResumeCreator.Models;
using System.Data;
using System.Data.SqlClient;

namespace ResumeCreator.Repositories
{
    public class EducationRepository : Repository
    {
        public  EducationRepository() // paso n°1=Declaración de un constructor; una función con el mismo nombre que la clase
        {

        }
        public List<Education> GetAll() 
        {
            var list = new List<Education>();
            var connection = this.masterConnection;

            SqlCommand command = new SqlCommand("dbo.EducationGetAll", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;


            connection.Open();
            var reader = command.ExecuteReader();
            bool isStillData = reader.Read();
            while (isStillData == true) 
            { Education education = new Education(1);
      

                education.Id = Convert.ToInt32(reader.GetValue(0).ToString());
                education.UserId = Convert.ToInt32(reader.GetValue(1).ToString());
                education.EducationLevelId = Convert.ToInt32(reader.GetValue(2).ToString());
                education.Institution = reader.GetValue(3)== DBNull.Value ? string.Empty : reader.GetValue(3).ToString();
                education.FieldOfStudyId = Convert.ToInt32(reader.GetValue(4).ToString());
                education.StartDate = reader.GetValue(5) == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime (reader.GetValue(5).ToString());
                education.EndDate = reader.GetValue(6) == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader.GetValue(6).ToString());
                education.AttendingCheck = Convert.ToBoolean(reader.GetValue(7).ToString());
                education.Description = reader.GetValue(8) == DBNull.Value ? string.Empty : reader.GetValue(8).ToString();

                list.Add(education);
                isStillData= reader.Read();

            }
            reader.Close();
            return list;


        }

        public void Save( Education entry)

        {
            try
            {
                var connection = this.masterConnection;

                SqlCommand command = new SqlCommand("dbo.EducationSave", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@UserId", SqlDbType.Int).Value = entry.UserId;
                command.Parameters.Add("@EducationLevelId", SqlDbType.Int).Value = entry.EducationLevelId;
                command.Parameters.Add("@Institution", SqlDbType.VarChar).Value = entry.Institution == null ? DBNull.Value : entry.Institution;
                command.Parameters.Add("@FieldOfStudyId", SqlDbType.Int).Value = entry.FieldOfStudyId;
                command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = entry.StartDate == DateTime.MinValue ? DBNull.Value : entry.StartDate;
                command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = entry.EndDate == DateTime.MinValue ? DBNull.Value : entry.EndDate;
                command.Parameters.Add("@AttendingCheck", SqlDbType.Bit).Value = entry.AttendingCheck;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = entry.Description == null ? DBNull.Value : entry.Description;


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }








    }
}
