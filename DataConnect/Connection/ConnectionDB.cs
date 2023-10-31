using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataConnect.Connection
{
    public class ConnectionDB
    {
        private readonly SqlConnection sqlConnection;


        public enum SqlType
        {
            StoredProcedure = 1,
            Sentence = 2
        }

        public ConnectionDB(string dBConnection)
        {
            sqlConnection = InitializeConnection(dBConnection);
        }

        private SqlConnection InitializeConnection(string connectionString)
        {
            SqlConnection _sqlConnection = new SqlConnection(connectionString);
            return _sqlConnection;
        }

        private IEnumerable<T> GetEnumerableList<T>(IDataReader reader) where T : new()
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                T obj = new T();
                PropertyInfo[] props = obj.GetType().GetProperties();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string name = reader.GetName(i).ToLower();
                    PropertyInfo prop = props.Where(w => w.Name.ToLower() == name).DefaultIfEmpty(null).FirstOrDefault();
                    if (prop == null)
                        continue;
                    Type dataType = prop.PropertyType;
                    Type fieldType = reader.GetFieldType(i);
                    object value = reader.GetValue(i);
                    if (fieldType == typeof(Int16))
                        prop.SetValue(obj, Convert.ToInt16(value), null);
                    else if (fieldType == typeof(int))
                    {
                        if (dataType.DeclaringType == null && Convert.IsDBNull(value))
                            value = 0;
                        prop.SetValue(obj, Convert.ToInt32(value), null);
                    }
                    else if (fieldType == typeof(Int64))
                        prop.SetValue(obj, Convert.ToInt64(value), null);
                    else if (fieldType == typeof(string))
                        prop.SetValue(obj, Convert.ToString(value), null);
                    else if (fieldType == typeof(Guid))
                    {
                        if (dataType.DeclaringType == null && Convert.IsDBNull(value))
                            prop.SetValue(obj, null, null);
                        else
                            prop.SetValue(obj, Guid.Parse(Convert.ToString(value)), null);
                    }
                    else if (fieldType == typeof(DateTime))
                        //prop.SetValue(obj, Convert.ToDateTime(value), null); 
                        prop.SetValue(obj, value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(value), null);
                    else if (fieldType == typeof(decimal))
                        prop.SetValue(obj, Convert.ToDecimal(value), null);
                    else if (fieldType == typeof(float))
                        prop.SetValue(obj, float.Parse(Convert.ToString(value)), null);
                    else if (fieldType == typeof(double))
                        prop.SetValue(obj, Convert.ToDouble(value), null);
                    else if (fieldType == typeof(bool))
                    {
                        if (dataType.DeclaringType == null && Convert.IsDBNull(value))
                            prop.SetValue(obj, null, null);
                        else
                            prop.SetValue(obj, Convert.ToBoolean(value), null);
                    }
                }
                list.Add(obj);
            }
            reader.Close();
            return list;
        }

        private T GetSingle<T>(IDataReader reader) where T : class, new()
        {
            IEnumerable<T> list = GetEnumerableList<T>(reader);
            return list.DefaultIfEmpty(new T()).FirstOrDefault();
        }
        public T ExecuteReaderSingle<T>(string procedure, Dictionary<string, object> parameters, SqlType type = SqlType.StoredProcedure) where T : class, new()
        {
            DbCommand command = MakingProcedureParameters(procedure, parameters, type);
            IDataReader reader = command.ExecuteReader();
            T item = GetSingle<T>(reader);
            command.Connection.Close();
            return item;
        }
        public IEnumerable<T> ExecuteReaderList<T>(string procedure, Dictionary<string, object> parameters, SqlType type = SqlType.StoredProcedure) where T : new()
        {
            DbCommand command = MakingProcedureParameters(procedure, parameters, type);
            IDataReader reader = command.ExecuteReader();
            IEnumerable<T> list = GetEnumerableList<T>(reader);
            command.Connection.Close();
            return list;
        }
        public T ExecuteScalar<T>(string procedure, Dictionary<string, object> parameters, SqlType type = SqlType.StoredProcedure) where T : new()
        {
            DbCommand command = MakingProcedureParameters(procedure, parameters, type);
            T result = (T)command.ExecuteScalar();
            command.Connection.Close();
            return result;
        }
        private DbCommand MakingProcedureParameters(string procedure, Dictionary<string, object> parameters, SqlType type = SqlType.StoredProcedure)
        {
            DbCommand command = sqlConnection.CreateCommand();
            command.CommandText = $"{((type == SqlType.StoredProcedure) ? "exec" : "")} {procedure}";
            command.Connection = sqlConnection;
            command.Connection.Open();
            foreach (KeyValuePair<string, object> item in parameters)
            {
                DbParameter param = command.CreateParameter();
                param.Value = (item.Value == null) ? DBNull.Value : item.Value;
                param.ParameterName = item.Key;
                command.Parameters.Add(param);
            }
            return command;
        }
        public int ExecuteNonQuery(string procedure, SqlType type = SqlType.StoredProcedure)
        {
            int result = ExecuteNonQuery(procedure, new Dictionary<string, object>(), type);
            return result;
        }
        public int ExecuteNonQuery(string procedure, Dictionary<string, object> parameters, SqlType type = SqlType.StoredProcedure)
        {
            DbCommand command = MakingProcedureParameters(procedure, parameters, type);
            int result = command.ExecuteNonQuery();
            command.Connection.Close();
            return result;
        }
        public bool CheckConnection()
        {
            bool connect = false;
            try
            {
                sqlConnection.Open();
                connect = true;
                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                int noAccessDataBase = 4060;
                if (ex.Number == noAccessDataBase && sqlConnection.Database == "")
                {
                    SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(sqlConnection.ConnectionString);
                    try
                    {
                        connectionStringBuilder.InitialCatalog = "";
                        SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
                        connection.Open();
                        connect = true;
                        connection.Close();
                    }
                    catch (Exception execptionSql)
                    {
                        connect = execptionSql.Message == "";
                    }
                }
            }
            catch (Exception ex)
            {
                connect = ex.Message == "";
            }
            return connect;
        }
    }
}
