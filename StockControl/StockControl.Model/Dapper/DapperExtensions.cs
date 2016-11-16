using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Dao
{
    public static class DapperExtensions
    {
        public static int Insert<T>(this IDbConnection cnn, string tableName, dynamic param)
        {
            List<long> result = SqlMapper.Query<long>(cnn, DynamicQuery.GetInsertQuery(tableName, param), param);

            return (int)result.FirstOrDefault();
        }

        public static void Modify(this IDbConnection cnn, string tableName, dynamic param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, param), param);
        }
       
    }
}
