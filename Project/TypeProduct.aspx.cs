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
    public partial class TypeProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            string strSqlCmd;
            SqlDataReader objDataReader;


            if (Request.QueryString["search"] == null) {
                Session["LastDeptID"] = Request["DeptID"];

                strSqlCmd = "SELECT DeptName, DeptDesc FROM Department WHERE DepartmentID=" + Request.QueryString["DeptID"];

                objDataReader = objdbMgmt.ExecuteSelect(strSqlCmd);

                // Close the data reader
                objDataReader.Close();

                // Retrieve products that belonged to the selected 
                // department from the database. 
                strSqlCmd = "SELECT p.ProductID, p.ProductTitle,p.ProductImage, p.Price, p.Quantity FROM DepartmentProduct dp  INNER JOIN Product p ON dp.ProductID=p.ProductID" + " WHERE dp.DepartmentID=" +

                        Request.QueryString["DeptID"];
                objDataReader = objdbMgmt.ExecuteSelect(strSqlCmd);
                dgDeptProduct.DataSource = objDataReader;

                // Bind the data to the data list control for display
                dgDeptProduct.DataBind();

                // Close the connection object
                objDataReader.Close();
                objdbMgmt.Close();
            } else {
                strSqlCmd = "SELECT p.ProductID, p.ProductTitle,p.ProductImage, p.Price, p.Quantity FROM DepartmentProduct dp  INNER JOIN Product p ON dp.ProductID=p.ProductID" + " WHERE p.ProductTitle like '%" +
                    Request.QueryString["search"] + "%'";
                objDataReader = objdbMgmt.ExecuteSelect(strSqlCmd);

                dgDeptProduct.DataSource = objDataReader;
                dgDeptProduct.DataBind();
                objDataReader.Close();
                objdbMgmt.Close(); 
            }


        }


    }
}