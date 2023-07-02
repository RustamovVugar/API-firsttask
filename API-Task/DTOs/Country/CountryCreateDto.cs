using System.ComponentModel.DataAnnotations;

namespace API_Task.DTOs.Country
{
    public class CountryCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Capital { get; set; }
    }
}
