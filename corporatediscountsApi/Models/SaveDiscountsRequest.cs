namespace corporatediscountsApi.Models
{
    public class SaveDiscountsRequest
    {

        public int DiscountId { get; set; }
        public string DiscountInfo { get; set; }
        public int DiscountScopeId { get; set; }
        public string ValidCities { get; set; }
    }
}
    