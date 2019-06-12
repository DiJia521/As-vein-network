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
        //添加
        public void Add(AsveinNetwork network)
        {
            dal.Add(network);
        }
        //显示
        public IEnumerable<AsveinNetwork> GetAll()
        {
           return dal.GetAll();
        }
        //反填
        public AsveinNetwork GetByID(int id)
        {
            return dal.GetByID(id);
        }
        //修改
        public void Update(AsveinNetwork network)
        {
             dal.Update(network);
        }
        //删除
        public void Delete(int id)
        {
            dal.Delete(id);
        }
    }
}
