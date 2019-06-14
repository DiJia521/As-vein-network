using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using Model;
using Dapper;
namespace BLL
{
    public class AsvienNetworkBll
    {
        AsveinNetworkDal dal = new AsveinNetworkDal();        
        //显示
        public List<AsveinNetwork> GetAsvein()
        {
           return dal.GetAsvein();
        }      
    }
}
