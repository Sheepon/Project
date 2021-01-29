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
    public partial class AddItem : System.Web.UI.Page
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
            intProductID = Convert.ToInt32(Session["ProductID"]);
            dblProductPrice = Convert.ToDouble(Double.Parse((string)Session["ProductPrice"], System.Globalization.NumberStyles.Currency));
            intQuantity = Convert.ToInt32(Session["Quantity"]);
            // Replace any single-quote with two single-quote
            strProductName = Convert.ToString(Session["ProductName"]);

            // Connect to the database
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            //objdbMgmt.Connect();

            // Check whether a shopping cart has been created.
            if (Session["ShopCartID"] == null) {
                // Create a new shopping cart
                //---------------------------
                intShopperID = Convert.ToInt32(Session["ShopperID"]);
                strSqlCmd = "INSERT INTO ShopCart(ShopperID) VALUES(" + intShopperID + ")";
                objdbMgmt.ExecuteNonQuery(strSqlCmd);

                // Get the new Shopping Cart ID
                strSqlCmd = "SELECT MAX(ShopCartID) AS maxShopCartID " + "FROM ShopCart WHERE ShopperID=" + intShopperID;

                // Save the Shopping Cart ID in a session variable 
                Session["ShopCartID"] = objdbMgmt.ExecuteScalar(strSqlCmd);

                // Set AddItem flag to true - to add item to shopping cart.
                flgAddItem = true;
            } else {
                // Shopping cart already created
                //-------------------------------

                intShopCartID = Convert.ToInt32(Session["ShopCartID"]);

                // Retrieve selected product from shopping cart.
                System.Data.SqlClient.SqlDataReader objDataReader;

                strSqlCmd = "SELECT Quantity FROM ShopCartItem WHERE ProductID=" + intProductID + " AND ShopCartID=" + intShopCartID;
                objDataReader = objdbMgmt.ExecuteSelect(strSqlCmd);

                // Check whether selected item is already in shopping cart.
                // If yes, update order quantity instead of adding new item.
                if (objDataReader.HasRows) {

                    // Close the data reader
                    objDataReader.Close();

                    // update quantity of Shop Cart Item 
                    strSqlCmd = "UPDATE ShopCartItem SET Quantity = Quantity + " + intQuantity + " WHERE ProductID =" + intProductID + " AND ShopCartID =" + intShopCartID;
                    objdbMgmt.ExecuteNonQuery(strSqlCmd);

                    // Set AddItem flag to false - do not add item to cart
                    flgAddItem = false;
                } else {
                    // Close the data reader
                    objDataReader.Close();
                    // Set AddItem flag to true - to add item to cart
                    flgAddItem = true;
                }

            }

            // If it is a new item, add item into shopping cart.
            if (flgAddItem) {
                // Add Shop Cart Item to the database
                strSqlCmd = "INSERT INTO ShopCartitem (ShopCartID, Quantity, Price, Name, ProductID)" + " VALUES (" + Session["ShopCartId"] + "," + intQuantity + "," + dblProductPrice + ",'" + strProductName + "'," + intProductID + ")";
                objdbMgmt.ExecuteNonQuery(strSqlCmd);
            }

            objdbMgmt.Close();

            // Re-direct to ShopCart page for display of shopping cart
            Response.Redirect("ShopCart.aspx");
        }
    }
}