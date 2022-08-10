namespace MockProject.WebApp.ModelAPI
{
    public class PromotionModel
    {
        public int PromotionId { get; set; }
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public float? DiscountPercent { get; set; }
        public float? DiscountMoney { get; set; }
        public string? Discription { get; set; }
        public string? Image { get; set; }
        public int ParentServiceId { get; set; }
    }
}
