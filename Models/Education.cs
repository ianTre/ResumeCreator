namespace ResumeCreator.Models
{
    public class Education

    {
        public Education( int userId ) // el contructor es el método que va a crear la instancia de la clase
        {
            this.Id = 0;

        }
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }
        public int UserId { get; set; }
        public int EducationLevelId { get; set; }
        public string Institution { get; set; }
        public int FieldOfStudyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AttendingCheck { get; set; }
        public string Description { get; set; }

        private static List<string> GetMonthNames()
        {
            List<string> listOfStrings = new List<string>();
            listOfStrings.Add("Enero");
            listOfStrings.Add("Febrero");
            listOfStrings.Add("Marzo");
            listOfStrings.Add("Abril");
            listOfStrings.Add("Mayo");
            listOfStrings.Add("Junio");
            listOfStrings.Add("Julio");
            listOfStrings.Add("Agosto");
            listOfStrings.Add("Septiembre");
            listOfStrings.Add("Octubre");
            listOfStrings.Add("Noviembre");
            listOfStrings.Add("Diciembre");

            return listOfStrings;
        }

        public static DateTime MonthStringAndYearToDatetime(string month ,int year)
        {
            DateTime returner;
            var listOfMonths = GetMonthNames();
            var monthIndex = listOfMonths.FindIndex(x => x == month);
            returner = new DateTime(year, ++monthIndex,1);
            return returner;
        }


        public static DateTime MonthAndYearToDatetime(int month, int year)
        {
            DateTime returner;
            returner = new DateTime(year, month, 1);
            return returner;
        }

        public static string DateTimeToMonthsName(DateTime startDate)
        {
            int monthToNumber = startDate.Month;
            var listOfMonths = GetMonthNames();
            monthToNumber = monthToNumber - 1;

            string monthToReturn = listOfMonths[monthToNumber];
            return monthToReturn;
        }
        public static bool ValueIsAMonth(string value)
        {
            bool isCorrect = false;
            var listOfMonths = GetMonthNames();
            isCorrect = listOfMonths.Contains(value);
            return isCorrect;
        }

        public  bool CheckTime()
        {
            if (this.StartYear>this.EndYear )
            {
                return false;
            }
            else
            {
                return true;      
            }

        }



    }
}
