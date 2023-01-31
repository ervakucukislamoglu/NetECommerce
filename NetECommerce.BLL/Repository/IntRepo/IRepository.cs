using NetEcommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NetECommerce.BLL.Repository.IntRepo
{
    public interface IRepository<T> where T:BaseEntity
    {
        //Tüm datayı cek/listele.
        //List<T> ListAll();
        IEnumerable<T> ListAll();
        //ID'ye gore veri cek.
        T GetById(int id);

        //Status'u Inserted olanlar aktif olarak kabul edilmisti. Onlar cekilecek.
        List<T> GetActives();

        //Status'u updated olan veriyi cekecek.
        List<T> GetModifieds();

        //Veri ekleme/olusturma
        void Add(T item);

        //Veri gulcelleme (status updated olacak unutma)
        void Update(T item);

        //Veri silme (status deleted olacak). Veri db'den silinmeyecek aslında, pasif hale gelecek.
        void Delete(T item);

        //Veriyi yok etme
        void Destroy(T item);

        //İstenen expression'a uygun koleksiyonu/veri listesini cekme.
        List<T> Where(Expression<Func<T, bool>> expression);

        //İstenen expression'a uygun datayı cekme.
        T GetDefault(Expression<Func<T, bool>> expression);

        //Expression'a uygun bir data var mı?
        bool Any(Expression<Func<T, bool>> expression);

        //Expression'a uygun result set dondur
        object Select(Expression<Func<T, bool>> expression);

    }
}
