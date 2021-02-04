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
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connect to the database
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            objdbMgmt.Connect();

            string strSqlCmd;
            // System.Data.OleDb.OleDbDataReader objDataReader;
            System.Data.SqlClient.SqlDataReader objDataReader;

            double curOringalPrice;

            // Retrieve the details of product of a given product ID
            // from the database
            int intProductId;
            intProductId = Convert.ToInt32(Request.QueryString["ProductId"]);
            strSqlCmd = "SELECT * FROM Product WHERE ProductId=" + intProductId;
            objDataReader = objdbMgmt.ExecuteSelect(strSqlCmd);

            // Read the only record retrieved
            if (objDataReader.Read()) {
                // Display the product title
                lblProductTitle.Text = (string)objDataReader["ProductTitle"];

                // Display the product description
                if (objDataReader["ProductDesc"] != DBNull.Value)
                    lblProductDesc.Text = (string)objDataReader["ProductDesc"];

                // Display the product image
                imgProduct.ImageUrl = "images/products/" + (string)objDataReader["ProductImage"];

                // Display the product price
                // Format to display two decimals
                curOringalPrice = Convert.ToDouble(objDataReader["Price"]);
                lblProductPrice.Text = "$" + string.Format(Convert.ToString(curOringalPrice), "0.00");
                objDataReader.Close();
            }
            // Retrieve the dynamic attributes of a given product
            strSqlCmd = "SELECT an.AttributeName, pa.AttributeVal FROM AttributeName an INNER JOIN ProductAttribute pa ON an.AttributeNameID=pa.AttributeNameID WHERE pa.ProductID=" + intProductId;

            objDataReader = objdbMgmt.ExecuteSelect(strSqlCmd);

            // Bind the records to the data grid control
            dgAttribute.DataSource = objDataReader;
            dgAttribute.DataBind();

            objDataReader.Close();
            objdbMgmt.Close();
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            // Set the Session Variables:
            // ProductID, ProductName, ProductPrice and Quantity
            //===================================================
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            SqlDataReader dR;

            string strSqlCmd = $"select quantity from Product where productId = {int.Parse(Request["ProductId"])}";
            dR = objdbMgmt.ExecuteSelect(strSqlCmd);

            if (dR.Read()) {
                if (int.Parse(txtQty.Text) > int.Parse(dR["quantity"].ToString())) {
                    Response.Write("<script>alert('Invalid quantity');</script>");
                    return;
                }
            }
            Session["Quantity"] = txtQty.Text;
            Session["ProductName"] = lblProductTitle.Text;
            Session["ProductPrice"] = lblProductPrice.Text;
            Session["ProductID"] = Request["ProductId"];

            // Re-direct to AddItem page to add the
            // selected item to the shopping cart
            Response.Redirect("AddItem.aspx");
        }
    }
}