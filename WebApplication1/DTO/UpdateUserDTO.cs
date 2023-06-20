using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class UpdateUserDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Must be between 8  and 60 charaters")]
        public string? UserName { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}
