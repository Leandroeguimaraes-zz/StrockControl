using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Dao
{
    public class QueryResult
    {
        /// <summary>
        /// The result
        /// </summary>
        private readonly Tuple<string, dynamic> result;

        /// <summary>
        /// Gets the SQL.
        /// </summary>
        /// <value>
        /// The SQL.
        /// </value>
        public string Sql
        {
            get
            {
                return result.Item1;
            }
        }

        /// <summary>
        /// Gets the param.
        /// </summary>
        /// <value>
        /// The param.
        /// </value>
        public dynamic Param
        {
            get
            {
                return result.Item2;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryResult" /> class.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="param">The param.</param>
        public QueryResult(string sql, dynamic param)
        {
            result = new Tuple<string, dynamic>(sql, param);
        }
    }
}
