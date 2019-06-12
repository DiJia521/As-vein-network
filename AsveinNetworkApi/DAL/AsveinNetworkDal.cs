using System;
using Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace DAL
{
    public class AsveinNetworkDal
    {
        //使用连接字符串
        private string ConnectionString;
        public AsveinNetworkDal()
        {
            ConnectionString = @"Server=DESKTOP-65JEFQR;Database=Recruitment;Trusted_Connection=true;";
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
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = " insert into JoinUs values(@Join_Recruitment,@join_Seeker)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, network);
            }
        }
        //显示
        public IEnumerable<AsveinNetwork> GetAll()
        {
            using (IDbConnection dbConnection = connection)
            {
                dbConnection.Open();
                return dbConnection.Query<AsveinNetwork>("SELECT * FROM JoinUs");
            }
        }
        //反填
        public AsveinNetwork GetByID(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = "SELECT * FROM JoinUs"
                                + " WHERE Join_Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<AsveinNetwork>(sQuery, new
                {
                    Id = id
                }).FirstOrDefault();
            }
        }
        //修改
        public void Update(AsveinNetwork network)
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
        //删除
        public void Delete(int id)
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
    }
}
