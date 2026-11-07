using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entites
{
    public class Education
    {
        public int EducationId { get; set; }

        [Required(ErrorMessage = "Okul adı zorunludur")]
        [StringLength(100)]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "Bölüm zorunludur")]
        [StringLength(100)]
        public string Department { get; set; }

        [StringLength(50)]
        public string? Degree { get; set; }        // Lisans, Yüksek Lisans, Sertifika...

        [Required(ErrorMessage = "Başlangıç yılı zorunludur")]
        [Range(1950, 2100, ErrorMessage = "Geçerli bir yıl giriniz")]
        public int StartYear { get; set; }

        [Range(1950, 2100, ErrorMessage = "Geçerli bir yıl giriniz")]
        public int? EndYear { get; set; }          // Boşsa "Devam ediyor"

        [StringLength(500)]
        public string? Description { get; set; }
    }
}