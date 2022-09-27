namespace corporatediscountsApi.Models
{
    public class DiscountSearchRequest
    {
        public int FirmId { get; set; }
        public int DiscountScopeId { get; set; }
        public int DiscountCategoryId { get; set; }
    }
}
