using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        // İstatistik kartları
        public int TotalProjectCount { get; set; }
        public int ActiveProjectCount { get; set; }
        public int SkillCount { get; set; }
        public int ExperienceCount { get; set; }
        public int EducationCount { get; set; }
        public int TotalMessageCount { get; set; }
        public int UnreadMessageCount { get; set; }

        // Listeler
        public List<Message> LastMessages { get; set; } = new();
        public List<Project> LastProjects { get; set; } = new();
        public List<CategorySummary> CategorySummaries { get; set; } = new();
    }

    // Kategori özeti için: "Web Uygulaması → 3 proje"
    public class CategorySummary
    {
        public string CategoryName { get; set; } = "";
        public int ProjectCount { get; set; }
    }
}