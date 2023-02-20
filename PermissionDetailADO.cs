using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPhanQuyen2
{
    class PermissionDetailADO
    {

        private static string connectionString = ConnectDBString.connectionString();
        private SqlConnection conn;
        public DataTable LoadMenuItem()
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT * FROM Permissions where ParentKey is null;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return dt;
        }

        public DataTable LoadSubItem(string parentKey)
        {
            DataTable dt = new DataTable();

            string SQL = "SELECT* FROM Permissions where ParentKey = @parentKey";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@parentKey", parentKey);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            return dt;
        }

        public DataTable LoadUserPermission(int IdUsername)
        {
            DataTable dt = new DataTable();

            string SQL = "SELECT * FROM UserPermissions where IdUsername = @IdUsername";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsername", @IdUsername);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public void DeleteUserPermission(int IdUsername)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string sql = "DELETE FROM UserPermissions WHERE IdUsername = @IdUsername ";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdUsername", @IdUsername);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void InsertUserPermission(int IdUsername, List<string> nameKeyPermissionList)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            foreach (string nameKeyPermission in nameKeyPermissionList)
            {
                string sql = "insert into UserPermissions(IdUsername,nameKeyPermission) values (@IdUsername,@nameKeyPermission)";
              
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@IdUsername", @IdUsername);
                command.Parameters.AddWithValue("@nameKeyPermission", @nameKeyPermission);
                command.ExecuteNonQuery();
            }
         

            connection.Close();
        }
    }
}
