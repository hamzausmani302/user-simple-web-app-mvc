

using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
   
    public class User
    {
        [Key]
        public int ID { get; set; }
        
        public string? UserName { get; set; }

        public string? Address { get; set; }

    }
}
