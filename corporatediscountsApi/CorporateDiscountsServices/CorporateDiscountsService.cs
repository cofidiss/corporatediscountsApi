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

    


        public string FilterDiscounts(DiscountSearchRequest filter)
        {
            var query = from corporateDiscount in _repository.DbContext.Set<CorporateDiscountEntity>()
                        join firm in _repository.DbContext.Set<FirmEntity>() on corporateDiscount.FirmId  equals firm.Id
                        join discountScope in _repository.DbContext.Set<DiscountScopeEntity>() on corporateDiscount.ScopeId equals discountScope.Id
                        where ((filter.DiscountScopeId == -1 ? true: (corporateDiscount.ScopeId == filter.DiscountScopeId))  &&
                        ( filter.DiscountCategoryId == -1 ? true : (corporateDiscount.CategoryId == filter.DiscountCategoryId)) &&

                        (filter.FirmId == -1 ? true : (corporateDiscount.FirmId == filter.FirmId)))
                        orderby corporateDiscount.Id ascending 
                        select new { id= corporateDiscount.Id, firmName= firm.Name, discountDescription= corporateDiscount.Description, discountScopeId = discountScope.Id, 
                            discountScopeName = discountScope.Name,firmContact=firm.ContactInfo};
            var searchResult = query.ToList();        
            string jsonString = JsonSerializer.Serialize(searchResult);
            return jsonString;
        }

        public string DiscountCategoryLov()
        {
            var query = from discountCategory in _repository.DbContext.Set<DiscountCategoryEntity>()
                        orderby discountCategory.Id
                        select new {id= discountCategory.Id,name= discountCategory.Name,parentId= discountCategory.ParentId };
        
            var searchResult = query.ToList();
            var jsonString = JsonSerializer.Serialize(searchResult);
            return jsonString;
        }

        internal string GetFirms()
        {

            var query = from firm in _repository.DbContext.Set<FirmEntity>()
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

        internal object? SaveFirms(SaveFirmRequest saveFirmRequest)
        {
            var firmDbSet = _repository.DbContext.Set<FirmEntity>();

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
                _repository.DbContext.SaveChanges();
            }


            foreach (var insertedFirmRow in saveFirmRequest.InsertedFirmRows)
            {


                FirmEntity firmEntity = new FirmEntity();
                firmEntity.Name = insertedFirmRow.FirmName;
                firmEntity.ContactInfo = insertedFirmRow.FirmContact;


                firmDbSet.Add(firmEntity);
                _repository.DbContext.SaveChanges();
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
                _repository.DbContext.SaveChanges();
            }
            return "ok";
        }

        public string FirmLov()
        {

            var query = from firm in _repository.DbContext.Set<FirmEntity>()
                        select new { id = firm.Id, name = firm.Name,contactInfo=firm.ContactInfo };
            var searchResult = query.ToList();
            string jsonString = JsonSerializer.Serialize(searchResult);
            return jsonString;

        }

        public  string GetDiscountScopeLov()
        {

            //throw new Exception("sd");
            var query = from discountScope in _repository.DbContext.Set<DiscountScopeEntity>()
                        select new { id = discountScope.Id, name = discountScope.Name };
            var searchResult = query.ToList();
            string jsonString = JsonSerializer.Serialize(searchResult);
            return jsonString;

        }

        //internal string SaveDiscounts(SaveDiscountsRequest saveDiscountsRequest)
        //{ var corporateDiscountDbSet =  _repository.DbContext.Set<CorporateDiscountEntity>();

        //    foreach (var updatedDiscountRow in saveDiscountsRequest.UpdatedDiscountRows)
        //    {
        //        var query = from corporateDiscount in corporateDiscountDbSet
        //                    where corporateDiscount.DiscountId == updatedDiscountRow.DiscountId
        //                    select corporateDiscount;
        //      var corporateDiscountList =  query.ToList();
        //        if (corporateDiscountList.Count > 1)
        //        {
        //            throw new Exception($"DiscountId: {updatedDiscountRow.DiscountId} icin birden cok satir geldi");

        //        }
        //    var corporateDiscountEntity = corporateDiscountList[0];

        //        corporateDiscountEntity.ValidCities = updatedDiscountRow.ValidCities;
        //        corporateDiscountEntity.Description = updatedDiscountRow.DiscountInfo;
        //        corporateDiscountEntity.ScopeId = updatedDiscountRow.DiscountScopeId;


        //        corporateDiscountDbSet.Update(corporateDiscountEntity);
        //        _repository.DbContext.SaveChanges();
        //    }


        //    foreach (var insertedDiscountRow in saveDiscountsRequest.InsertedDiscountRows)
        //    {


        //        CorporateDiscountEntity corporateDiscountEntity = new CorporateDiscountEntity();
        //        corporateDiscountEntity.ValidCities = insertedDiscountRow.ValidCities;
        //        corporateDiscountEntity.Description = insertedDiscountRow.DiscountInfo;
        //        corporateDiscountEntity.ScopeId = insertedDiscountRow.DiscountScopeId;
        //        corporateDiscountEntity.FirmId = insertedDiscountRow.FirmId;

        //        corporateDiscountDbSet.Add(corporateDiscountEntity);
        //        _repository.DbContext.SaveChanges();
        //    }


        //    foreach (var deletedDiscountRow in saveDiscountsRequest.DeletedDiscountRows)
        //    {

        //        var query = from corporateDiscount in corporateDiscountDbSet
        //                    where corporateDiscount.DiscountId == deletedDiscountRow
        //                    select corporateDiscount;
        //        var corporateDiscountList = query.ToList();
        //        if (corporateDiscountList.Count > 1)
        //        {
        //            throw new Exception($"DiscountId: {deletedDiscountRow} icin birden cok satir geldi");

        //        }

        //        corporateDiscountDbSet.Remove(corporateDiscountList[0]);
        //        _repository.DbContext.SaveChanges();
        //    }

        //    return " ";
        //}
    }
}
