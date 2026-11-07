using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy_PortfolioProject.Entites
{
    public class Message
    {
        [Key]
        [Column("Id")]
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Adınızı giriniz")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "E-posta adresinizi giriniz")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "Konu giriniz")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesajınızı yazınız")]
        public string MessageDetail { get; set; }

        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }


    }
}