using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
namespace DatabaseConPoc
{
    public class ResultFromDB
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class DBConnect
    {
        private SqlConnectionStringBuilder builder { get; set; }
        private SqlConnection connection { get; set; }
        internal string SQLQuery { get; set; }
        public DBConnect()
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = ConfigurationManager.AppSettings["ServerName"];
            builder.UserID = ConfigurationManager.AppSettings["Username"];
            builder.Password = ConfigurationManager.AppSettings["Password"];
            builder.InitialCatalog = ConfigurationManager.AppSettings["DatabaseName"];
            builder.MultipleActiveResultSets = true;
            connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
        }
        public List<ResultFromDB> ReadData()
        {
            try
            {
                List<ResultFromDB> results = new List<ResultFromDB>();
                using (SqlCommand command = new SqlCommand(SQLQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ResultFromDB result = new ResultFromDB();
                                result.Name = reader["Name"].ToString();
                                result.Age = UInt16.Parse(reader["Age"].ToString());
                                results.Add(result);
                            }
                        }
                    }
                }
                return results;
            }
            catch
            {
                return null;
            }
        }
    }
}