using ResumeCreator.Models;
using ResumeCreator.Repositories;

namespace ResumeCreator.Manager
{
    public class EducationManager // FUNCIONA USUALMENTE DE PASAMANOS ENTRE EL REPOSITORIO Y CONTROLLER
    {

        private EducationRepository _repository; // PUNTERO; ESPACIO DE MEMORIA RESERVADO PARA UN USO EN PARTICULAR


        public EducationManager() // EL CONSTRUCTOR DEFINE LO QUE VA A SUCEDER AL LLAMAR A LA CLASE
        {
            _repository = new EducationRepository();
        }
        public List<Education> GetAll()
        {
            
            var list = _repository.GetAll();
            foreach (var item in list)
            {
                
                //formatear los datos que vienen de BD uno por uno 
                item.StartMonth = Education.DateTimeToMonthsName(item.StartDate);
                item.EndMonth = Education.DateTimeToMonthsName(item.EndDate);
                item.StartYear = item.StartDate.Year;
                item.EndYear = item.EndDate.Year;
            }
            return list;
        }


        public void Save(Education model)
        {
            try
            {
                int month;
                month = int.Parse(model.StartMonth);
                model.StartDate = Education.MonthAndYearToDatetime(month, model.StartYear);
                model.EndDate = Education.MonthAndYearToDatetime(month, model.EndYear);
                _repository.Save(model);
                return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

           

        }
        //    {
        //        _repository.Save(model);
        //    }

        //    public ProfileData Get(int userId)
        //    {
        //        return _repository.Get(userId);
        //    }

        //    internal void Update(ProfileData profileData)
        //    {
        //        _repository.Update(profileData);
        //        return;
        //    }

        //    internal void Delete(int id)
        //    {
        //        _repository.Delete(id);
        //        return;
        //    }
    }
}
