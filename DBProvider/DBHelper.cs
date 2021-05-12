using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace DBProvider
{
    public class DBHelper
    {
        private SqlConnection conn { get; set; }
        private static DBHelper _Instance;
        //private string conStr = "Server = XUANTRONG\\SQLEXPRESS2019; database = PBL3; user id = sa; pwd = 06112000";
        private string conStr = @"Data Source = ADMIN;Initial Catalog = PBL3; Integrated Security = True";
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBHelper();
                }
                return _Instance;
            }
        }
        private DBHelper()
        {
        }

        public DataTable GetDataTable(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                conn = new SqlConnection(conStr);
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                //conn.Open();
                da.Fill(dt);
                //conn.Close();
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
        }


        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

    }
}
