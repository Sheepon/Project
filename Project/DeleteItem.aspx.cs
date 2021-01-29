using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using Project.App_Code;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class DeleteItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Don't allow non-member to purchase a product 
            if (Session["ShopperID"] == null) {
                Response.Redirect("Login.aspx");
            }

            int intProductID;
            string strProductName;
            double dblProductPrice;
            int intQuantity;
            int intShopCartID;
            int intShopperID;

            bool flgAddItem;
            string strSqlCmd;

            // Read product's details from session variables
            //intProductID = Convert.ToInt32(Session["ProductID"]);
            intProductID = Convert.ToInt32(Request.QueryString["ProductId"]);
            dblProductPrice = Convert.ToDouble(Double.Parse((string)Session["ProductPrice"], System.Globalization.NumberStyles.Currency));
            intQuantity = Convert.ToInt32(Session["Quantity"]);
            // Replace any single-quote with two single-quote
            strProductName = Convert.ToString(Session["ProductName"]);

            // Connect to the database
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            //objdbMgmt.Connect();

           

            // If it is a new item, add item into shopping cart.
            strSqlCmd = $"Delete from ShopCartItem where productId ='{intProductID}'";
            objdbMgmt.ExecuteNonQuery(strSqlCmd);

            objdbMgmt.Close();

            // Re-direct to ShopCart page for display of shopping cart
            Response.Redirect("ShopCart.aspx");
        }
    }
}