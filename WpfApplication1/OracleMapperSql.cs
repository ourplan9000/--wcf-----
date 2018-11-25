using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Dapper;
using System.Windows;

using System.Configuration;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace WpfApplication1
{
    public class OracleMapperSql
    {
        readonly string _url = ConfigurationManager.ConnectionStrings["orcl"].ConnectionString;
        
        private OracleConnection GetOpenConnection()
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection(_url);
            }
            catch (OracleException oex)
            {
                throw;
            }
            return connection;
        }

        public static void MapperSql()
        {

            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
            var name = stackTrace.GetFrame(2).GetMethod().Name;
            MessageBox.Show(name.ToString());
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDsQuery(string sqlString)
        {
            var ds = new DataSet();
            using (var connection = GetOpenConnection())
            {
                try
                {
                    var command = new OracleCommand(sqlString, connection);
                    connection.Open();
                    var dbReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    ds.Tables.Add(new DataTable());
                    ds.Tables[0].Load(dbReader);
                }
                catch (OracleException ex)
                {
                    throw;
                }
            }
            return ds;
        }

        /// <summary>
        /// 取得表中有多少条记录
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public int GetTableCount(string tablename)
        {
            int i = 0;
            string sql = "select count(*) from " + tablename;
            string countStr = SqlScalar<int>(sql);
            if (!int.TryParse(countStr, out i))
            {
                throw new Exception(countStr);
            }

            return i;

        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int InsertMultiple<T>(string sql, IEnumerable<T> entities) where T : class, new()
        {
            int records = 0;
            using (OracleConnection cnn = GetOpenConnection())
            {
                cnn.Open();
                using (var trans = cnn.BeginTransaction())
                {
                    try
                    {
                        records = cnn.Execute(sql, entities, trans, 300, CommandType.Text);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        cnn.Close();
                    }
                }
            }
            return records;
        }

        /// <summary>
        /// 按类型新增修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpInsert<T>(string sql, T entity) where T : class, new()
        {
            int records = 0;
            using (var cnn = GetOpenConnection())
            {
                try
                {
                    records = cnn.Execute(sql, entity);
                }
                catch (DataException ex)
                { 
                    throw;
                }
            }
            return records;
        }


        /// <summary>
        /// 按SQL语句和参数执行SQL语句
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public int InsertUpdateOrDeleteSql(string sql, dynamic parms, string connectionName = null)
        {
            int i = 0;
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Open();
                    i = connection.Execute(sql, (object)parms);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return i;
        }


        /// <summary>
        /// 按SQL查询条件返回列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parms">The parms.</param>
        /// <param name="connectionnName"></param>
        /// <returns></returns>
        public List<T> SqlWithParams<T>(string sql, dynamic parms, string connectionnName = null)
        {
            List<T> tlist;
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Open();
                    tlist = connection.QueryAsync<T>(sql, (object)parms).Result.ToList();
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return tlist;
        }

        /// <summary>
        /// 按SQL查询条件返回列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parms">The parms.</param>
        /// <param name="connectionnName"></param>
        /// <returns></returns>
        public List<dynamic> SqldynamicWithParams<dynamic>(string sql, dynamic parms)
        {
            List<dynamic> tlist;
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Open();
                    tlist = connection.QueryAsync<dynamic>(sql, (object)parms).Result.ToList();
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return tlist;
        }
        public Task<IEnumerable<dynamic>> Sqldynamic<dynamic>(string sql)
        {
            Task<IEnumerable<dynamic>> tlist;
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Open();
                    tlist = connection.QueryAsync<dynamic>(sql, null);
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return tlist;
        }
        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string SqlScalar<T>(string sql)
        {
            T strScalar;
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Open();
                    strScalar = connection.ExecuteScalar<T>(sql, null);
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return strScalar.ToString();
        }
        //public static T sqlScalar<T>(string sql)
        //{
        //    T Scalar ;
        //    using (OracleConnection connection = GetOpenConnection())
        //    {
        //        try
        //        {
        //            connection.Open();
        //             Scalar = connection.ExecuteScalar<T>(sql, null);
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return Scalar;
        //}
        /// <summary>
        /// 取得列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> SqlQuery<T>(string sql)
        {
            List<T> tlist;
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Open();
                    tlist = connection.Query<T>(sql, null).ToList();
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return tlist;
        }
    }
}
