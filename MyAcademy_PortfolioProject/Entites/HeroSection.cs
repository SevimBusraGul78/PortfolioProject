namespace MyAcademy_PortfolioProject.Entites
{
    public class HeroSection
    {

        public int HeroSectionId { get; set; } 
        public string Greeting { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string MainImageUrl { get; set; }

        // Öne çıkan bilgiler (fotoğrafın üzerindeki rozetler)
        public string? HighlightValue1 { get; set; }   // Örn: "2+ Yıllık"
        public string? HighlightLabel1 { get; set; }   // Örn: "Yazılım Deneyimi"
        public string? HighlightValue2 { get; set; }   // Örn: "15+ Proje"
        public string? HighlightLabel2 { get; set; }   // Örn: "Tamamlanan İş"

    }
}
