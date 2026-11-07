namespace MyAcademy_PortfolioProject.Entites
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }    
        public List<Project> Projects { get; set; } 
    }
}
