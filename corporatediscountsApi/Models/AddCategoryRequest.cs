using System.Reflection.Metadata.Ecma335;

namespace corporatediscountsApi.Models
{
    public class AddCategoryRequest
    {

        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    
    }
}
