using System.ComponentModel.DataAnnotations;

namespace CursoASPNET.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public int PersonId { get; set; }
     
        public string? UserName { get; set; }

        public string? Password { get; set; }   
        
        public string? Email { get; set; }

    }
}
