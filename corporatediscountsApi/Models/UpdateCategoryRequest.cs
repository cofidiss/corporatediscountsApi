namespace corporatediscountsApi.Models
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? CategoryName { get; set; }

    }
}
