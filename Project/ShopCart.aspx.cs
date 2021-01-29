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
    public partial class ShopCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false) {
                //Dont allow non-member to purchase a product
                if (Session["ShopperID"] == null)
                    Response.Redirect("Login.aspx");
                //Check whether there is a shopping cart
                if (Session["ShopCartId"] == null)
                    displayEmptyShopCart();
                else
                    displayShopCart();
            }
        }

        private void displayEmptyShopCart()
        {
            lblEmptyShopCart.Visible = true;
            dgShopCart.Visible = false;
            lblSubTotal.Visible = false;
            btnUpdateCart.Visible = false;

        }

        private void displayShopCart()
        {
            lblEmptyShopCart.Visible = false;
            dgShopCart.Visible = true;
            lblSubTotal.Visible = true;
            btnUpdateCart.Visible = true;
            btnCheckOut.Visible = true;

            // Establish a database connection
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            // Get items in the designated shopping cart.
            string strSqlCmd;

            SqlDataReader objDataReader;

            strSqlCmd = "SELECT ShopCartID, ProductID, Name, Price, Quantity, DateAdded, Price * Quantity as Total FROM ShopCartItem WHERE ShopCartID=" + Session["ShopCartId"];
            objDataReader = objdbMgmt.ExecuteSelect(strSqlCmd);

            // Bind the records to the data list control
            dgShopCart.DataSource = objDataReader;
            dgShopCart.DataBind();
            objDataReader.Close();

            // Check for empty shopping cart
            if (dgShopCart.Rows.Count == 0) {
                // Call a subroutine to display empty Shopping Cart message
                displayEmptyShopCart();
            } else {
                // Calculate the subtotal.
                double dblSubTotal;

                strSqlCmd = "SELECT SUM(Price * Quantity) as SubTotal FROM ShopCartItem WHERE ShopCartID=" + Session["ShopCartId"];
                dblSubTotal = Convert.ToDouble(objdbMgmt.ExecuteScalar(strSqlCmd));

                // Display the subtotal.
                string strSubTotal = string.Format("{0:c}", dblSubTotal, 2);

                lblSubTotal.Text = "Subtotal (before tax and shipping charge): " + strSubTotal;
            }
            objdbMgmt.Close();
        }
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shipping.aspx");
        }
        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            // Connect to the database
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();

            // Iterate through all rows within shopping cart list 
            // (i.e. the dgShopCart data grid)
            int i;
            for (i = 0; i <= dgShopCart.Rows.Count - 1; i++) {

                // Obtain references to row's controls
                TextBox txtQuantity;
                txtQuantity = (TextBox)dgShopCart.Rows[i].FindControl("txtQty");

                // Get the quantity value from textbox 
                // and convert to integer
                int intQuantity;
                intQuantity = Convert.ToInt16(txtQuantity.Text);

                // Get the ProductId from the first cell 
                // and convert to integer
                int intProductID;

                intProductID = Convert.ToInt16(dgShopCart.Rows[i].Cells[0].Text);

                // Update quantity order of shopping cart in database
                string strSqlCmd;
                strSqlCmd = "UPDATE ShopCartItem SET Quantity=" + intQuantity + " WHERE ShopCartID=" + Session["ShopCartID"] + " AND ProductId=" + intProductID;

                objdbMgmt.ExecuteNonQuery(strSqlCmd);
            }
            displayShopCart();
            objdbMgmt.Close();
        }
    }
}