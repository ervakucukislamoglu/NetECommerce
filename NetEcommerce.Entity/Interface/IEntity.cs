using NetEcommerce.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetEcommerce.Entity.Interface
{
    internal interface IEntity<T>
    {
        public T MasterID { get; set; } //veritabanındaki islemler icin yarattigimiz id. T istersek Guid, istersek string, istersek int olacak.
        public int ID { get; set; } //client icin yarattigimiz id
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedComputerName { get; set; }
        public string UpdatedComputerName { get; set; }
        public string UpdatedIpAddress { get; set; }
        public string CreatedIpAddress { get; set; }
        public Status Status { get; set; }
    }
}
