namespace corporatediscountsApi.Entities
{
    public class CorporateDiscountEntity
    {

        public int DiscountId { get; set; }
        public int FirmId { get; set; }
        public string Description { get; set; }

        public int ScopeId { get; set; }
        public string ValidCities { get; set; }

    }
}    
