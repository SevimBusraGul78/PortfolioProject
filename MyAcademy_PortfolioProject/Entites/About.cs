using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entites
{
    public class About
    {
        public int AboutId { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur")]
        [StringLength(150)]
        public string Heading { get; set; }          // "Teknolojiye Tutkuyla Bağlı Bir Yolculuk."

        [Required(ErrorMessage = "Hakkımda metni zorunludur")]
        [StringLength(2000)]
        public string Content { get; set; }          // Paragraflar (Enter ile ayrılır)

        public string? ImageUrl { get; set; }

        [StringLength(100)]
        public string? Caption { get; set; }         // "Büşra Gül, İstanbul"

        [StringLength(50)]
        public string? JobTitle { get; set; }        // "Junior Developer"

        // 3 istatistik
        [StringLength(20)] public string? Stat1Value { get; set; }
        [StringLength(50)] public string? Stat1Label { get; set; }
        [StringLength(20)] public string? Stat2Value { get; set; }
        [StringLength(50)] public string? Stat2Label { get; set; }
        [StringLength(20)] public string? Stat3Value { get; set; }
        [StringLength(50)] public string? Stat3Label { get; set; }

        [Url(ErrorMessage = "Geçerli bir bağlantı giriniz")]
        public string? CvUrl { get; set; }           // Özgeçmiş linki (Google Drive vb.)
    }
}