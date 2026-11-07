using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entites
{
    public class Skill
    {
        //Data Annotations şartına uygun yapıldı
            public int SkillId { get; set; }

            [Required(ErrorMessage = "Başlık zorunludur")]
            [StringLength(50)]
            public string Title { get; set; }

            [StringLength(250)]
            public string? Description { get; set; }

            public string? IconUrl { get; set; }

            public List<SkillItem>? SkillItems { get; set; }
        }
    }
