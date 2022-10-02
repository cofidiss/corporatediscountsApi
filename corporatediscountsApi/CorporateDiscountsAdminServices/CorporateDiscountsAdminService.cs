using corporatediscountsApi.Repositories;
using corporatediscountsApi.Entities;
using corporatediscountsApi.DbContexts;
using System.Linq.Expressions;
using corporatediscountsApi.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace corporatediscountsApi.CorporateDiscountsAdminServices
{
    public class CorporateDiscountsAdminService
    {

         PostgreDbContext _dbContext { get; set; }
        public CorporateDiscountsAdminService(PostgreDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        public string GetDiscountCategoryLov()
        {
            var query = from discountCategory in _dbContext.Set<DiscountCategoryEntity>()
                        orderby discountCategory.Id
                        select new
                        {
                            id = discountCategory.Id,
                            name = discountCategory.Name,
                            parentId = discountCategory.ParentId,
                            levelNo = discountCategory.ParentId == null ? 1 : 2
                        };

            var searchResult = query.ToList();
            var jsonString = JsonSerializer.Serialize(searchResult);
            return jsonString;
        }

        public string GetFirmLov()
        {

            var query = from firm in _dbContext.Set<FirmEntity>()
                        orderby firm.Id
                        select firm;
            var searchResult = query.ToList();
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(searchResult, serializeOptions);
            return jsonString;

        }

        public string GetDiscountScopeLov()
        {

            //throw new Exception("sd");
            var query = from discountScope in _dbContext.Set<DiscountScopeEntity>()
                        select new { id = discountScope.Id, name = discountScope.Name };
            var searchResult = query.ToList();
            string jsonString = JsonSerializer.Serialize(searchResult);
            return jsonString;

        }

    }
}
