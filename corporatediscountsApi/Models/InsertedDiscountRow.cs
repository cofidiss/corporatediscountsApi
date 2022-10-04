namespace corporatediscountsApi.Models
{
    public class InsertedDiscountRow
    {
        public int FirmId { get; set; }
        public string DiscountInfo { get; set; }
        public int DiscountCategoryId { get; set; }
        public int DiscountScopeId { get; set; }
    }
}
