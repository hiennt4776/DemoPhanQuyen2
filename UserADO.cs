using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPhanQuyen2
{
    class UserADO
    {



        //private string ConnectionString = @"Data Source=DESKTOP-H8M37V7\SQLEXPRESS;Initial Catalog=DemoUserPermission;User ID=sa;Password=123";

        private string ConnectionString = ConnectDBString.connectionString();
        private SqlConnection conn;
        public DataTable selectAllUser()
        {

            // create Connect
            conn = new SqlConnection(ConnectionString);

            //new SQL string
            string queryString = "select * from Users";

            //create Command
            SqlCommand command = new SqlCommand();
            //connect Command with Connection
            command.Connection = conn;
            //add queryString to Command
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;

            //Create DataProvider and DataSet use Binding Data
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable ds = new DataTable();

            //Open Connection
            conn.Open();
            //Execute SQL
            command.ExecuteNonQuery();
            dataAdapter.SelectCommand = command;
            //binding dataset
            dataAdapter.Fill(ds);
            conn.Close();
            return ds;

        }

        public void insertUser(string Username, string Password, string FullName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            conn = new SqlConnection(ConnectionString);
            string queryString = "insert into Users values (@Username,@Password,@FullName)";
            SqlCommand command = new SqlCommand(queryString, connection);
            
         
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Encryptor.getHashSha256(Password));
            command.Parameters.AddWithValue("@FullName", FullName);

            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            conn.Open();
            var rowsAffected = command.ExecuteNonQuery();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public User CheckLoginUser(string Username, string Password)
        {
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            string queryString = "select * from Users where UserName = @username and PassWord = @password";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@password", Encryptor.getHashSha256(Password));
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            User user = new User();
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                user.Id = int.Parse(row["Id"].ToString());
                user.Username = row["username"].ToString();
                user.Password = row["password"].ToString();
                user.Fullname = row["fullname"].ToString();
                return user;

            }
            else return null;
        }


       
    }
}
