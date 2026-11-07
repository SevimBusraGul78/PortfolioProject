using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entites
{
    public class Contact
    {
        public int ContactId { get; set; }

        [StringLength(150)]
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string Email { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        [StringLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
