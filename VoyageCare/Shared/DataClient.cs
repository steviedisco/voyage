using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Reflection;

namespace VoyageCare.Shared
{
    public class DataClient
    {
        public static async Task<T> Get<T>(int id) where T : class
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Open();

                return await connection.GetAsync<T>(id);
            }
        }

        public static async Task<List<T>> GetAllAsync<T>() where T : class
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Open();

                return (await connection.GetAllAsync<T>()).ToList();
            }
        }

        public static async Task<int> UpdateAsync<T>(T obj) where T : class
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Open();

                var props = obj.GetType().GetProperties();

                foreach (var property in props)
                {
                    var attr = Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) as KeyAttribute;

                    if (attr != null)
                    {
                        var id = (int)(property.GetValue(obj) ?? 0);

                        if (id > 0)
                        {
                            await connection.UpdateAsync(obj);
                            return id;
                        }
                    }
                }

                return await connection.InsertAsync(obj);
            }
        }

        public static async Task<bool> DeleteAsync<T>(T obj) where T : class
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Open();

                return await connection.DeleteAsync(obj);
            }
        }

        public static async Task<bool> DeleteAll<T>() where T : class
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Open();

                return await connection.DeleteAllAsync<T>();
            }
        }
    }
}