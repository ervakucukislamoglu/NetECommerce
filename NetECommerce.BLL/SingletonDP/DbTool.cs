using NetECommerce.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.BLL.SingletonDP
{
    public class DbTool
    {
        private static ProjectContext _dbInstance;
        public static ProjectContext DbInstance
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new ProjectContext();
                return _dbInstance;
            }
        }
    }
}
