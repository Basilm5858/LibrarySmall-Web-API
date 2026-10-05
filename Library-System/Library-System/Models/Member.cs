using System.ComponentModel.DataAnnotations;

namespace Library_System.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    }
}
