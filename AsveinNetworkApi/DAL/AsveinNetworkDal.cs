using System;
using Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Log;

namespace DAL
{
    public class AsveinNetworkDal
    {
        /// <summary>
        /// 显示主界面
        /// </summary>
        /// <returns></returns>
        public List<AsveinNetwork> GetAsvein()
        {
            List<AsveinNetwork> str = null;
            try
            {
                string sql = string.Format("select * from JoinUs");
                str = DapperHelper<AsveinNetwork>.Query(sql, null);
            }
            catch (Exception e)
            {
                Logger.Error("404");
            }
            return str;
        }
    }
}
