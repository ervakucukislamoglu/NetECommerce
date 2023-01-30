
using NetEcommerce.Entity.Enum;
using NetEcommerce.Entity.Interface;
using System;

namespace NetEcommerce.Entity.Base
{
    public class BaseEntity : IEntity<Guid>
    {
        public BaseEntity()
        {
            IsActive = true;
            Status = Status.Inserted;
            CreatedDate = DateTime.Now;
        }
        public Guid MasterID { get ;  set ;  }
        public int ID { get ;  set ;  }
        public DateTime CreatedDate { get ;  set ;  }
        public DateTime UpdatedDate { get ;  set ;  }
        public bool IsActive { get ;  set ;  }
        public string CreatedComputerName { get ;  set ;  }
        public string UpdatedComputerName { get ;  set ;  }
        public string UpdatedIpAddress { get ;  set ;  }
        public string CreatedIpAddress { get ;  set ;  }
        public Status Status { get; set; }

        //TODO: bilgisayar adı ve ip adresi veri eklendiğinde veya guncellendiginde otomatik doldurulacak. updateddate de aynı şekilde otomatik doldurulacak şekilde ayarlanmalı.
        //TODO: MasterID doldurulacak
    }
}
