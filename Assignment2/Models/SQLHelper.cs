using System;    
using System.Configuration; 
using System.Data;    
using System.Data.SqlClient;    
    
namespace Assignment2.Models
{    
    public class SQLHelper    
    {    
        private readonly string connectionString;    
    
        public SQLHelper() 
        {    
            this.connectionString = ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString; 
        }    
    
        public IDataReader ExecuteReader(string sqlQuery)    
        {    
            using (SqlConnection connection = new SqlConnection(connectionString))    
            {    
                connection.Open();    
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))    
                {    
                    return command.ExecuteReader();    
                }    
            }   
        }   
    
        public int ExecuteNonQuery(string sqlQuery)    
        {    
            using (SqlConnection connection = new SqlConnection(connectionString))    
            {    
                connection.Open();    
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))    
                {    
                    return command.ExecuteNonQuery();    
                }    
            }    
        }    
    
        public object ExecuteScalar(string sqlQuery)    
        {    
            using (SqlConnection connection = new SqlConnection(connectionString))    
            {    
                connection.Open();    
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))    
                {    
                    return command.ExecuteScalar();    
                }    
            }    
        }

public DataTable ExecuteQuery(string sqlQuery)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }


}

