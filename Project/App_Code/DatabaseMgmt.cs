using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Configuration;

namespace Project.App_Code
{
    public class DatabaseMgmt
    {
        SqlConnection connObj = new SqlConnection();
        SqlCommand comdObj = new SqlCommand();
        SqlDataReader drObj;
        string connStr = null;

        public DatabaseMgmt()
        {
            connObj = new SqlConnection();
            connStr = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            //connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheepe\Desktop\OOPG\Project\Project\App_Data\eceBkShop.mdf;Integrated Security=True";
            if (connObj.State != ConnectionState.Open) {
                connObj = new SqlConnection(connStr);
                connObj.Open();
            }

        }

        // Method for connecting to the specified database 
        // before query can take place
        //================================================
        public bool Connect()
        {
            if (connObj.State != ConnectionState.Open) {
                connObj = new SqlConnection(connStr);
                connObj.Open();
            }
            return true;
        }

        public void Close()
        {
            if (connObj.State == ConnectionState.Open)
                connObj.Close();
        }

        public int ExecuteNonQuery(string sqlString)
        {
            comdObj = new SqlCommand(sqlString, connObj);
            int intValue = comdObj.ExecuteNonQuery();
            return intValue;

        }

        public SqlDataReader ExecuteSelect(string sqlString)
        {
            comdObj = new SqlCommand(sqlString, connObj);
            drObj = comdObj.ExecuteReader();

            return drObj;
        }

        // Method for executing a SELECT command that returns a SINGLE value only
        //========================================================================
        public object ExecuteScalar(string cmd)
        {
            object value;
            comdObj.Connection = connObj;
            comdObj.CommandText = cmd;
            value = comdObj.ExecuteScalar();

            return value;
        }
    }
}