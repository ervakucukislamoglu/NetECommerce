using NetECommerce.BLL.Repository.IntRepo;
using NetEcommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;
using NetECommerce.BLL.SingletonDP;
using NetECommerce.DAL.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq;
using NetEcommerce.Entity.Enum;

namespace NetECommerce.BLL.Repository.BaseRepo
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ProjectContext _db;
        public BaseRepository()
        {
            _db = DbTool.DbInstance; //Singleton
        }

        //Degisiklikleri kaydetmekcin bu class icinde (private) kullanmak istedigim kaydet methodu.
        private void Save()
        {
            _db.SaveChanges();
        }

        //_db.Set<T>() diyerek ilerledim cunku farkli entitylerim icin ayni metotlarin is gorebilmesini saglamak istiyordum. Generic yapi kullanmazken _db.Products.IlgililiMethod() , _db.Orders.IlgiliMethod() seklinde ileriliyorduk.Simdi T tüm entitylerimi temsil ediyor. BaseEntity class'ından miras alan tüm classlar T yerine gecebiliyor. ("where T : BaseEntity")
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
            
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Any(expression);
        }

        
        public void Delete(T item)
        {
            item.Status = Status.Deleted;
            //DeletedDate diye bir prop'umuz olsaydı burada item.DeletedDate = DateTime.Now seklinde set edebilirdik.
            Save();

        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public List<T> GetActives()
        {
            //Status'u inserted olanları aktif kabul etmistik
            return _db.Set<T>().Where(x=>x.Status == Status.Inserted).ToList();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
            
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().FirstOrDefault(expression);
        }

        public List<T> GetModifieds()
        {
            return _db.Set<T>().Where(x => x.Status == Status.Updated).ToList();
        }

        public List<T> ListAll()
        {
            return _db.Set<T>().ToList();
        }

        public object Select(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Select(expression).ToList();
        }

        public void Update(T item)
        {
            T guncellenecek = _db.Set<T>().Find(item.ID);
            _db.Entry(guncellenecek).CurrentValues.SetValues(item);
            item.UpdatedDate = DateTime.Now;
            item.Status = Status.Updated;
            Save();
        }

        public List<T> Where(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression).ToList();
        }
    }
}
