using ValueOf;

namespace ValueOfAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public AgeVO Age { get; set; }
        public BirthYearVO BirthYear { get; set; }

    }

    public class BirthYearVO : ValueOf<int,BirthYearVO>
    {
        protected override bool TryValidate()
        {
            return Value > 2000 && Value < DateTime.Now.Year;
        }
    }

    public class AgeVO : ValueOf<int, AgeVO>
    {
        protected override bool TryValidate()
        {
            return Value > 18 && Value < 60;
        }
    }
}