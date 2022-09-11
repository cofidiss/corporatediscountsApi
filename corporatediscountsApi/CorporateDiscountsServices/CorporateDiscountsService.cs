using corporatediscountsApi.Repositories;
using corporatediscountsApi.Entities;
using corporatediscountsApi.DbContexts;
using System.Linq.Expressions;
using corporatediscountsApi.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace corporatediscountsApi.CorporateDiscountsServices
{
    public class CorporateDiscountsService
    {
        public IRepository<CorporateDiscountEntity,PostgreDbContext> _repository { get; set; }
        public CorporateDiscountsService(IRepository<CorporateDiscountEntity, PostgreDbContext> repository)
        {
            _repository = repository;


        }

    


        public string GetDiscountsByFilter(DiscountSearchRequest filter)
        {
            var query = from corporateDiscount in _repository.DbContext.Set<CorporateDiscountEntity>()
                        join firm in _repository.DbContext.Set<FirmEntity>() on corporateDiscount.FirmId  equals firm.Id
                        join discountScope in _repository.DbContext.Set<DiscountScopeEntity>() on corporateDiscount.ScopeId equals discountScope.Id
                        where ((filter.DiscountScopeId == null ? true: (corporateDiscount.ScopeId == filter.DiscountScopeId))  &&( filter.FirmName == null ? true : (firm.Name == filter.FirmName)))
                        select new { discountId= corporateDiscount.DiscountId, firmName= firm.Name, discountInfo= corporateDiscount.Description, discountScopeId = discountScope.Id, 
                            discountScope = discountScope.Name,validCities= corporateDiscount.ValidCities ,firmContact=firm.ContactInfo};
            var searchResult = query.ToList();        
            string jsonString = JsonSerializer.Serialize(searchResult);
            return jsonString;
        }

        public  string GetDiscountScopeLov()
        {

            //throw new Exception("sd");
            var query = from discountScope in _repository.DbContext.Set<DiscountScopeEntity>()
                        select new { discountScopeId = discountScope.Id, discountScopeName = discountScope.Name };
            var searchResult = query.ToList();
            string jsonString = JsonSerializer.Serialize(searchResult);
            return jsonString;

        }
    }
}
