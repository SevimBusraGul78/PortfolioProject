namespace MyAcademy_PortfolioProject.Entites
{
    public class Experience
    {
        //propery,filed ile değişken arasında fark ne 

        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; } 
        public string CategoryName { get; set; }    
        public bool IsActive {  get; set; }
    }
}
