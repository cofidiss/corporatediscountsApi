namespace corporatediscountsApi.Models
{
    public class SaveDiscountsRequest
    {
        public InsertedDiscountRow[] InsertedDiscountRows { get; set; }
        public UpdatedDiscountRow[] UpdatedDiscountRows { get; set; }

        public int[] DeletedDiscountRows { get; set; }
    }
}
    