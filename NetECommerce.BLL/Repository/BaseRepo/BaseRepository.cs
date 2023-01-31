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
using Microsoft.EntityFrameworkCore;

namespace NetECommerce.BLL.Repository.BaseRepo
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ProjectContext _db;
        private DbSet<T> _entities;
        public BaseRepository()
        {
            _db = DbTool.DbInstance; //Singleton
            _entities = _db.Set<T>(); //Her defasında her metot içerisinde entity tipini set etmek zorunda kalmamakcin kolaylik yaptik.
        }

        //Degisiklikleri kaydetmekcin bu class icinde (private) kullanmak istedigim kaydet methodu.
        private void Save()
        {
            _db.SaveChanges();
        }

        //_db.Set<T>() diyerek ilerledim cunku farkli entitylerim icin ayni metotlarin is gorebilmesini saglamak istiyordum. Generic yapi kullanmazken _db.Products.IlgililiMethod() , _db.Orders.IlgiliMethod() seklinde ileriliyorduk.Simdi T tüm entitylerimi temsil ediyor. BaseEntity class'ından miras alan tüm classlar T yerine gecebiliyor. ("where T : BaseEntity")
        public void Add(T item)
        {
            _entities.Add(item);
            Save();
            
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _entities.Any(expression);
        }

        
        public void Delete(T item)
        {
            item.Status = Status.Deleted;
            //DeletedDate diye bir prop'umuz olsaydı burada item.DeletedDate = DateTime.Now seklinde set edebilirdik.
            Save();

        }

        public void Destroy(T item)
        {
            _entities.Remove(item);
            Save();
        }

        public List<T> GetActives()
        {
            //Status'u inserted olanları aktif kabul etmistik
            return _entities.Where(x=>x.Status == Status.Inserted).ToList();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
            
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _entities.FirstOrDefault(expression);
        }

        public List<T> GetModifieds()
        {
            return _entities.Where(x => x.Status == Status.Updated).ToList();
        }

        public IEnumerable<T> ListAll()
        {
            return _entities.ToList();
        }

        public object Select(Expression<Func<T, bool>> expression)
        {
            return _entities.Select(expression).ToList();
        }

        public void Update(T item)
        {
            T guncellenecek = _entities.Find(item.ID);
            _db.Entry(guncellenecek).CurrentValues.SetValues(item);
            item.UpdatedDate = DateTime.Now;
            item.Status = Status.Updated;
            Save();
        }

        public List<T> Where(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression).ToList();
        }
    }
}
