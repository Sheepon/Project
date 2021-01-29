using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Project.App_Code;

namespace Project
{
    public partial class Catalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseMgmt dbObj = new DatabaseMgmt();
            string strSqlCmd;
            SqlDataReader sqlDataReader;

            strSqlCmd = "Select * From Department";
            sqlDataReader = dbObj.ExecuteSelect(strSqlCmd);

            dgDept.DataSource = sqlDataReader;
            dgDept.DataBind();

            dbObj.Close();
        }
    }
}