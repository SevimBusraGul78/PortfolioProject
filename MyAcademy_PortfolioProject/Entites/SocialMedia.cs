using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entites
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }

        [Required(ErrorMessage = "Platform adı zorunludur")]
        [StringLength(50)]
        public string Platform { get; set; }      // GitHub, LinkedIn...

        [Required(ErrorMessage = "Bağlantı zorunludur")]
        [Url(ErrorMessage = "Geçerli bir bağlantı giriniz (https:// ile başlamalı)")]
        public string Url { get; set; }

        [Required(ErrorMessage = "İkon seçiniz")]
        [StringLength(50)]
        public string Icon { get; set; }          // bi bi-github
    }
}