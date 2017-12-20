using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TX.Model;
using System.Configuration;
using System.Data.SqlClient;
using TX.DB.Interface;

namespace TX.SqlDBHelper
{
    public class SqlServerDBHeler : IDBHelper
    {

        private static readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();

        /// <summary>
        /// 根据主键获取对象
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="id">主键值</param>
        /// <returns>返回对象</returns>
        public T GetT<T>(int id) where T : BaseModel, new()
        {
            Type type = typeof(T);
            T returnEntity = (T)Activator.CreateInstance(type);//创建一个实类

            string baseSql = "Select {0} from [{1}] where {2}=@id;";
            string selectField = string.Join(",", type.GetProperties().Select(p => string.Format("[{0}]", p.Name)));

            TableAttribute tbAttr = (TableAttribute)Attribute.GetCustomAttribute(type, typeof(TableAttribute));
            string tableName = tbAttr == null ? type.Name : tbAttr.TableName;

            string pkNmae = "123";
            foreach (var pop in type.GetProperties())
            {
                PrimaryKeyAttribute pkAttr = (PrimaryKeyAttribute)Attribute.GetCustomAttribute(pop, typeof(PrimaryKeyAttribute));
                if (pkAttr != null && pkAttr.IsPKValue)
                {
                    pkNmae = pop.Name;
                    break;
                }
            }

            string runSql = string.Format(baseSql, selectField, tableName, pkNmae);


            using (SqlConnection con = new SqlConnection(sqlConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(runSql, con);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    foreach (var pop in type.GetProperties())
                    {
                        object readerValue = reader[pop.Name];
                        if (readerValue is DBNull)
                        {
                            pop.SetValue(returnEntity, null);
                        }
                        else
                        {
                            pop.SetValue(returnEntity, readerValue);
                        }
                    }
                }
            }
            return returnEntity;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="model">要更新的对象</param>
        /// <returns>放回是否更新成功</returns>
        public bool UpdateT<T>(T model) where T : BaseModel
        {
            string baseSql = "Update [{0}] set {1} where {2}=@id";
            Type type = typeof(T);
            TableAttribute tabAttr = (TableAttribute)Attribute.GetCustomAttribute(type, typeof(TableAttribute));
            string tableName = tabAttr == null ? type.Name : tabAttr.TableName;

            string pkName = string.Empty;
            int pkValue = 0;
            string updateField = string.Empty;
            List<SqlParameter> sqlParameterList = new List<SqlParameter>();
            foreach (var pop in type.GetProperties())
            {
                PrimaryKeyAttribute pkAttr = (PrimaryKeyAttribute)Attribute.GetCustomAttribute(pop, typeof(PrimaryKeyAttribute));
                if (pkAttr != null && pkAttr.IsPKValue)
                {
                    pkName = pop.Name;
                    pkValue = (int)pop.GetValue(model);
                    continue;
                }
                updateField += string.Format(" [{0}]=@{0},", pop.Name);
                sqlParameterList.Add(new SqlParameter("@" + pop.Name, pop.GetValue(model) ?? DBNull.Value));
            }
            if (string.IsNullOrEmpty(pkName))
                return false;

            string runsql = string.Format(baseSql, tableName, updateField.TrimEnd(','), pkName);

            using (SqlConnection con = new SqlConnection(sqlConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(runsql, con);
                cmd.Parameters.AddRange(sqlParameterList.ToArray());
                cmd.Parameters.Add(new SqlParameter("@id", pkValue));
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="id">主键值</param>
        /// <returns>放回是否更新成功</returns>
        public bool DeleteT<T>(int id) where T : BaseModel
        {
            string basesql = "Delete [{0}] where {1}=@id";
            Type type = typeof(T);
            TableAttribute tabAttr = (TableAttribute)Attribute.GetCustomAttribute(type, typeof(TableAttribute));
            string tableName = tabAttr == null ? type.Name : tabAttr.TableName;

            string pkName = string.Empty;
            foreach (var pop in type.GetProperties())
            {
                PrimaryKeyAttribute primaryKeyAttribute = (PrimaryKeyAttribute)Attribute.GetCustomAttribute(pop, typeof(PrimaryKeyAttribute));
                if (primaryKeyAttribute != null)
                {
                    pkName = pop.Name;
                    break;
                }
            }
            if (string.IsNullOrEmpty(pkName))
                return false;
            string runsql = string.Format(basesql, tableName, pkName);
            using (SqlConnection con = new SqlConnection(sqlConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(runsql, con);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="model">要插入的实体</param>
        /// <returns></returns>
        public T InsertT<T>(T model) where T : BaseModel
        {
            string baseSql = "Insert into [{0}] ({1}) values ({2});Select SCOPE_IDENTITY() as 'Id'";
            Type type = typeof(T);

            TableAttribute tableAttribute = (TableAttribute)Attribute.GetCustomAttribute(type, typeof(TableAttribute));
            string tableName = tableAttribute == null ? type.Name : tableAttribute.TableName;
            string baseField = string.Empty;
            string valueField = string.Empty;
            List<SqlParameter> sqlParameterList = new List<SqlParameter>();
            foreach (var pop in type.GetProperties())
            {
                PrimaryKeyAttribute primaryKeyAttribute = (PrimaryKeyAttribute)Attribute.GetCustomAttribute(pop, typeof(PrimaryKeyAttribute));
                if (primaryKeyAttribute != null && primaryKeyAttribute.IsPKValue)
                    continue;
                baseField += string.Format("[{0}],", pop.Name);
                valueField += "@" + pop.Name + ",";
                sqlParameterList.Add(new SqlParameter("@" + pop.Name, pop.GetValue(model) ?? DBNull.Value));
            }
            string runSql = string.Format(baseSql, tableName, baseField.TrimEnd(','), valueField.TrimEnd(','));
            using (SqlConnection con = new SqlConnection(sqlConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(runSql, con);
                cmd.Parameters.AddRange(sqlParameterList.ToArray());
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                foreach (var pop in type.GetProperties())
                {
                    PrimaryKeyAttribute primaryKeyAttribute = (PrimaryKeyAttribute)Attribute.GetCustomAttribute(pop, typeof(PrimaryKeyAttribute));
                    if (primaryKeyAttribute != null && primaryKeyAttribute.IsPKValue)
                    {
                        pop.SetValue(model, id);
                        break;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <returns>返回集合对象</returns>
        public static List<T> GetListModel<T>() where T : BaseModel
        {
            Type type = typeof(T);
            List<T> returnListEntity = new List<T>();//创建一个实类

            string baseSql = "Select {0} from [{1}];";
            string selectField = string.Join(",", type.GetProperties().Select(p => string.Format("[{0}]", p.Name)));
            TableAttribute tbAttr = (TableAttribute)Attribute.GetCustomAttribute(type, typeof(TableAttribute));
            string tableName = tbAttr == null ? type.Name : tbAttr.TableName;
            string runSql = string.Format(baseSql, selectField, tableName);

            using (SqlConnection con = new SqlConnection(sqlConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(runSql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    T model = (T)Activator.CreateInstance(type);
                    foreach (var pop in type.GetProperties())
                    {
                        object readerValue = reader[pop.Name];
                        if (readerValue is DBNull)
                        {
                            pop.SetValue(model, null);
                        }
                        else
                        {
                            pop.SetValue(model, readerValue);
                        }
                    }
                    returnListEntity.Add(model);
                }
            }

            return returnListEntity;
        }


        public static int GetInt(int id)
        {
            return 2;
        }

        public static string GetInt(int id,string str)
        {
            return string.Empty;
        }
    }
}
