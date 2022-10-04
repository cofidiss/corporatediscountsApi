using corporatediscountsApi.Repositories;
using corporatediscountsApi.Entities;
using corporatediscountsApi.DbContexts;
using System.Linq.Expressions;
using corporatediscountsApi.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

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

        internal object? FilterDiscounts(DiscountSearchRequest filter)
        {

            var childCategoriesQuery = from discountCategory in _dbContext.Set<DiscountCategoryEntity>()
                                       where discountCategory.ParentId == filter.DiscountCategoryId
                                       select discountCategory.Id;

            IList<int> childCategoryIds = childCategoriesQuery.ToList();
            childCategoryIds.Add(filter.DiscountCategoryId);


            var query = from corporateDiscount in _dbContext.Set<CorporateDiscountEntity>()
                        join firm in _dbContext.Set<FirmEntity>() on corporateDiscount.FirmId equals firm.Id
                        join discountScope in _dbContext.Set<DiscountScopeEntity>() on corporateDiscount.ScopeId equals discountScope.Id
                        join discountCategory in _dbContext.Set<DiscountCategoryEntity>() on corporateDiscount.CategoryId equals discountCategory.Id
                        where ((filter.DiscountScopeId == -1 ? true : (corporateDiscount.ScopeId == filter.DiscountScopeId)) &&
                        (filter.DiscountCategoryId == -1 ? true : (childCategoryIds.Contains(corporateDiscount.CategoryId))) &&

                        (filter.FirmId == -1 ? true : (corporateDiscount.FirmId == filter.FirmId)))
                        orderby corporateDiscount.Id ascending
                        select new
                        {
                            id = corporateDiscount.Id,
                            firmName = firm.Name,
                            discountDescription = corporateDiscount.Description,
                            discountScopeId = discountScope.Id,
                            discountScopeName = discountScope.Name,
                            firmContact = firm.ContactInfo,
                            discountCategoryName = discountCategory.Name
                        };
            var searchResult = query.ToList();
            string jsonString = JsonSerializer.Serialize(searchResult);
            return jsonString;
        }

        public string SaveDiscounts(SaveDiscountsRequest saveDiscountsRequest)
        {

            {
                var corporateDiscountDbSet = _dbContext.Set<CorporateDiscountEntity>();

                foreach (var updatedDiscountRow in saveDiscountsRequest.UpdatedDiscountRows)
                {
                    var query = from corporateDiscount in corporateDiscountDbSet
                                where corporateDiscount.Id == updatedDiscountRow.DiscountId
                                select corporateDiscount;
                    var corporateDiscountList = query.ToList();
                    if (corporateDiscountList.Count > 1)
                    {
                        throw new Exception($"DiscountId: {updatedDiscountRow.DiscountId} icin birden cok satir geldi");

                    }
                    var corporateDiscountEntity = corporateDiscountList[0];

                    corporateDiscountEntity.CategoryId = updatedDiscountRow.DiscountCategoryId;
                    corporateDiscountEntity.Description = updatedDiscountRow.DiscountInfo;
                    corporateDiscountEntity.ScopeId = updatedDiscountRow.DiscountScopeId;
                    corporateDiscountEntity.FirmId = updatedDiscountRow.FirmId;


                    corporateDiscountDbSet.Update(corporateDiscountEntity);
                    _dbContext.SaveChanges();
                }


                foreach (var insertedDiscountRow in saveDiscountsRequest.InsertedDiscountRows)
                {


                    CorporateDiscountEntity corporateDiscountEntity = new CorporateDiscountEntity();

                    corporateDiscountEntity.CategoryId = insertedDiscountRow.DiscountCategoryId;
                    corporateDiscountEntity.Description = insertedDiscountRow.DiscountInfo;
                    corporateDiscountEntity.ScopeId = insertedDiscountRow.DiscountScopeId;
                    corporateDiscountEntity.FirmId = insertedDiscountRow.FirmId;

                    corporateDiscountDbSet.Add(corporateDiscountEntity);
                    _dbContext.SaveChanges();
                }


                foreach (var deletedDiscountRowId in saveDiscountsRequest.DeletedDiscountRows)
                {

                    var query = from corporateDiscount in corporateDiscountDbSet
                                where corporateDiscount.Id == deletedDiscountRowId
                                select corporateDiscount;
                    var corporateDiscountList = query.ToList();
                    if (corporateDiscountList.Count > 1)
                    {
                        throw new Exception($"DiscountId: {deletedDiscountRowId} icin birden cok satir geldi");

                    }

                    corporateDiscountDbSet.Remove(corporateDiscountList[0]);
                    _dbContext.SaveChanges();
                }

                return "Başarıyla Kaydedildi";
            }
        }

        internal string SaveFirms(SaveFirmRequest saveFirmRequest)
        {
            var firmDbSet = _dbContext.Set<FirmEntity>();

            foreach (var updatedFirmRow in saveFirmRequest.UpdatedFirmRows)
            {
                var query = from firm in firmDbSet
                            where firm.Id == updatedFirmRow.FirmId
                            select firm;
                var firmList = query.ToList();
                if (firmList.Count > 1)
                {
                    throw new Exception($"DiscountId: {updatedFirmRow.FirmId} icin birden cok satir geldi");

                }
                var firmEntity = firmList[0];

                firmEntity.Name = updatedFirmRow.FirmName;
                firmEntity.ContactInfo = updatedFirmRow.FirmContact;


                firmDbSet.Update(firmEntity);
                _dbContext.SaveChanges();
            }


            foreach (var insertedFirmRow in saveFirmRequest.InsertedFirmRows)
            {


                FirmEntity firmEntity = new FirmEntity();
                firmEntity.Name = insertedFirmRow.FirmName;
                firmEntity.ContactInfo = insertedFirmRow.FirmContact;


                firmDbSet.Add(firmEntity);
                _dbContext.SaveChanges();
            }


            foreach (var deletedFirmRow in saveFirmRequest.DeletedFirmRows)
            {

                var query = from firm in firmDbSet
                            where firm.Id == deletedFirmRow
                            select firm;
                var firmList = query.ToList();
                if (firmList.Count > 1)
                {
                    throw new Exception($"firmId: {deletedFirmRow} icin birden cok satir geldi");

                }

                firmDbSet.Remove(firmList[0]);
                _dbContext.SaveChanges();
            }
            return "Firmalar Kaydedildi";
        }
    }
}
