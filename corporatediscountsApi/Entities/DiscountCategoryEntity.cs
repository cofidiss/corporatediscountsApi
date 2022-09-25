namespace corporatediscountsApi.Entities
{
    public class DiscountCategoryEntity
    {

        public int Id { get; set; }

        public string  Name { get; set; }
        public int? ParentId { get; set; }
    }
}
