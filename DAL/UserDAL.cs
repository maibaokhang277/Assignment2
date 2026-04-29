using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAL
    {
        private string connString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        public bool CheckLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT COUNT(*) FROM [Users] WHERE UserName = @user AND password = @pass AND [lock] = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                conn.Open();
                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }
    }
}