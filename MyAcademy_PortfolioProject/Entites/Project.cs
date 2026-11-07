namespace MyAcademy_PortfolioProject.Entites
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public  Category Category{ get; set; }
        public string? ImageUrl { get; set; }
        public string? Technologies { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
