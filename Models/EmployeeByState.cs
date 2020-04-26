using System.ComponentModel.DataAnnotations;

namespace T882292.Models
{
    public class EmployeeByState
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Prefix { get; set; }

        [Display(Name = "State")]
        public int? StateID { get; set; }

        [Display(Name = "City")]
        public int? CityID { get; set; }
    }
}