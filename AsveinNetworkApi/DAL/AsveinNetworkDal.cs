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
        //使用连接字符串
        private string ConnectionString;
        public AsveinNetworkDal()
        {
            ConnectionString = @"Server=DESKTOP-65JEFQR;Database=Recruitment;uid=sa;pwd=123456;";
        }

        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }
        //添加
        public void Add(AsveinNetwork network)
        {
            try
            {
                using (IDbConnection dbConnection = connection)
                {
                    string sQuery = " insert into JoinUs values(@Join_Recruitment,@join_Seeker)";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, network);
                }
            }
            catch (Exception)
            {

                Logger.Error("添加错误!");
            }           
        }
        //显示
        public IEnumerable<AsveinNetwork> GetAll()
        {
            IEnumerable<AsveinNetwork> list = null;
            try
            {
                string str = "select * from JoinUs ";
                list = DapperHelper<AsveinNetwork>.Query(str, null);
            }
            catch (Exception e)
            {
                Logger.Error("查询错误");
            }

            return list;
        }
        //反填
        public AsveinNetwork GetByID(int id)
        {
             AsveinNetwork list = null;
            try
            {
                string str = "select * from JoinUs  where Join_Id=@id";
                list = DapperHelper<AsveinNetwork>.QuerySingle(str, null);
            }
            catch (Exception e)
            {
                Logger.Error("查询错误");
            }
            return list;
        }
        //修改
        public void Update(AsveinNetwork network)
        {
            try
            {
                using (IDbConnection dbConnection = connection)
                {
                    string sQuery = "UPDATE JoinUs SET Join_Recruitment = @Join_Recruitment,"
                                   + " join_Seeker = @join_Seeker"
                                  + " WHERE Join_Id = @Join_Id";
                    dbConnection.Open();
                    dbConnection.Query(sQuery, network);
                }
            }
            catch (Exception)
            {

                Logger.Error("修改错误!");
            }            
        }
        //删除
        public void Delete(int id)
        {
            try
            {
                using (IDbConnection dbConnection = connection)
                {
                    string sQuery = "DELETE FROM JoinUs"
                                + " WHERE Join_Id = @Id";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new
                    {
                        Id = id
                    });
                }
            }
            catch (Exception)
            {

                Logger.Error("删除错误");
            }
        }
    }
}
