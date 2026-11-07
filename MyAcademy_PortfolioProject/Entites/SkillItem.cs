using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entites
{
    public class SkillItem
    {
        public int SkillItemId { get; set; }

        [Required(ErrorMessage = "Yetenek adı zorunludur")]
        [StringLength(50)]
        public string SkillItemTitle { get; set; }

        [Range(0, 100, ErrorMessage = "Seviye 0 ile 100 arasında olmalı")]
        public int Level { get; set; }

        public int SkillId { get; set; }
        public Skill? Skill { get; set; }


    }
}
