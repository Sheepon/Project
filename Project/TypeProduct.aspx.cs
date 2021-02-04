using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Project.App_Code;
using System.Data;
using System.Configuration;

namespace Project
{
    public partial class TypeProduct : System.Web.UI.Page
    {
        DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            string strSqlCmd;
            SqlDataReader objDataReader;

            if (IsPostBack == false) {
                     if (Request.QueryString["search"] == null) {
                        Session["LastDeptID"] = Request["DeptID"];

                        strSqlCmd = "SELECT DeptName, DeptDesc FROM Department WHERE DepartmentID=" + Request.QueryString["DeptID"];

                        objDataReader = objdbMgmt.ExecuteSelect(strSqlCmd);

                        // Close the data reader
                        objDataReader.Close();


                        strSqlCmd = "SELECT count(p.ProductId) FROM DepartmentProduct dp  INNER JOIN Product p ON dp.ProductID = p.ProductID" + " WHERE dp.DepartmentID = " +
                        Request.QueryString["DeptID"];
                        dgDeptProduct.VirtualItemCount = int.Parse(objdbMgmt.ExecuteScalar(strSqlCmd).ToString());

                        BindData("SELECT p.ProductID, p.ProductTitle, p.ProductImage, p.Price, p.Quantity FROM DepartmentProduct dp  INNER JOIN Product p ON dp.ProductID = p.ProductID" + " WHERE dp.DepartmentID = " +
                            Request.QueryString["DeptID"]);


                } else {
                    strSqlCmd = "SELECT count(p.ProductId) FROM DepartmentProduct dp  INNER JOIN Product p ON dp.ProductID = p.ProductID" + " WHERE p.ProductTitle like '%" +
                        Request.QueryString["search"] + "%'";
                    dgDeptProduct.VirtualItemCount = int.Parse(objdbMgmt.ExecuteScalar(strSqlCmd).ToString());

                    BindData("SELECT p.ProductID, p.ProductTitle,p.ProductImage, p.Price, p.Quantity FROM DepartmentProduct dp  INNER JOIN Product p ON dp.ProductID=p.ProductID" + " WHERE p.ProductTitle like '%" +
                        Request.QueryString["search"] + "%'");
                }

            }

        }

        protected void dgDeptProduct_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgDeptProduct.CurrentPageIndex = e.NewPageIndex;
            BindData("SELECT p.ProductID, p.ProductTitle, p.ProductImage, p.Price, p.Quantity FROM DepartmentProduct dp  INNER JOIN Product p ON dp.ProductID = p.ProductID" + " WHERE dp.DepartmentID = " +
            Request.QueryString["DeptID"]);
        }

        //Doesnt work for pagination. Can't read if using sqldatareader.
/*        public void BindData(string tmpQuery)
        {
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            string strSqlCmd;
            SqlDataReader objDataReader;

            strSqlCmd = tmpQuery;
            objDataReader = objdbMgmt.ExecuteSelect(strSqlCmd);
            dgDeptProduct.DataSource = objDataReader;
            dgDeptProduct.DataBind();
        }*/


        //works for pagination
        public void BindData(string tmpQuery)
        {
            string strSqlCmd = tmpQuery;
            SqlDataAdapter da = new SqlDataAdapter(strSqlCmd, ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            da.Fill(table);
            dgDeptProduct.DataSource = table;
            dgDeptProduct.DataBind();
        }

    }
}