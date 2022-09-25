namespace corporatediscountsApi.Entities
{
    public class CorporateDiscountEntity
    {

        public int Id { get; set; }
        public int FirmId { get; set; }
        public string Description { get; set; }

        public int ScopeId { get; set; }
        public int CategoryId { get; set; }

    }
}    
