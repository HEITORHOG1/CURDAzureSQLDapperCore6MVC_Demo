using System.ComponentModel.DataAnnotations;

namespace CURDAzureSQLDapperCore6MVC_Demo.Models
{
    public class Company
    {
        [Display(Name ="SL No")]
        public int Id { get; set; }

        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }

        public string Country { get; set; }

        [Display(Name = "Glassdoor Rating")]
        public int GlassdoorRating { get; set; }
    }
}
