using NetEcommerce.Entity.Entity;
using NetEcommerce.Entity.Enum;
using NetECommerce.BLL.Repository.BaseRepo;
using NetECommerce.BLL.Repository.IntRepo;
using NetECommerce.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NetECommerce.BLL.Repository.ConcRepo
{
    public class ProductRepository : BaseRepository<Product>, IProductRepo<Product>
    {
        public List<Product> GetProductsOutOfStock()
        {
            return _db.Set<Product>().Where(x=> x.UnitsInStock == 0).ToList();
        }
    }

}
