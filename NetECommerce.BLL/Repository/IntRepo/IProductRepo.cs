using NetEcommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NetECommerce.BLL.Repository.IntRepo
{
    public interface IProductRepo<T> //where T: Product
    {
        //Varsayalım ki indirimdeki urunler, ocak ayinda satilmis urunler, stogu tukenmis urunler seklinde sorgulamalarla veri cekmek istiyoruz yani sadece product entity'miz uzerinde yapmak istedigimiz custom islemler var.
        //Iste yeni bir interface, bu islemleri barindirmak icin mukemmel bir secenek.

        //IProductRepo ile ConcreteRepo'larimdan ProductRepo'yu beslerim ve o entity'ye ait custom yetenekler kazanilmis olur.

        //SOLID'in I'sini hatirla!! INTERFACE SEGREGATION :)

        //ornegin stogu bitmis urunleri cekelim
        List<T> GetProductsOutOfStock();

        
    }
}
