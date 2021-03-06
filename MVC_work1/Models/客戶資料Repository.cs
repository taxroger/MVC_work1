using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_work1.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Find(int id)
        {
            return this.All(null, null).FirstOrDefault(p => p.Id == id);
        }

        public override void Delete(客戶資料 entity)
        {
            entity.isDeleted = true;
        }

        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.isDeleted == false);
        }

        public IQueryable<客戶資料> All(string sCName, string sSortBy)
        {
            var data = this.All().AsQueryable();
            
            if (!string.IsNullOrEmpty(sCName))
            {
                data = data.Where(p => p.客戶名稱.Contains(sCName));
            }

            if (sSortBy == "Asc" || string.IsNullOrEmpty(sSortBy))
            {
                data = data.OrderBy(p => p.客戶名稱);
            }
            else if (sSortBy == "Desc")
            {
                data = data.OrderByDescending(p => p.客戶名稱);
            }

            return data.AsQueryable();
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}