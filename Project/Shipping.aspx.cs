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
    public partial class Shipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            SqlDataReader dR;
            objdbMgmt.Connect();

            string strSqlCmd;
            strSqlCmd = $"select address,email,phone from Shopper where ShopperID='{Session["ShopperId"]}'";
            dR = objdbMgmt.ExecuteSelect(strSqlCmd);

            nameTextBox.Text = (string)Session["Name"];
            if (dR.Read()) {
                addressTextbox.Text = dR["address"].ToString();
                emailTextbox.Text = dR["email"].ToString();
                phoneTextbox.Text = dR["phone"].ToString();
            }

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            DatabaseMgmt objdbMgmtProduct = new DatabaseMgmt();
            DatabaseMgmt objdbMgmtUpdate = new DatabaseMgmt();


            SqlDataReader dR,dRProduct;
            string strSqlCmd = $"Select productId,quantity from shopcartitem where shopcartid = '{Session["ShopCartId"]}'";
            dR = objdbMgmt.ExecuteSelect(strSqlCmd);
            if (dR.Read()) {
                strSqlCmd = $"Select productid,quantity from product where productid = '{dR["productId"]}'";
                dRProduct = objdbMgmtProduct.ExecuteSelect(strSqlCmd);
                if (dRProduct.Read()) {
                    int intTmp = int.Parse(dRProduct["quantity"].ToString()) - int.Parse(dR["quantity"].ToString());
                    strSqlCmd = $"update Product set quantity = {intTmp} where productId = '{dRProduct["productid"]}'";
                    objdbMgmtUpdate.ExecuteNonQuery(strSqlCmd);
                }
                //strSqlCmd = $"update product set quantity ={dR[]};
                //strSqlCmd = "UPDATE ShopCartItem SET Quantity=" + intQuantity + " WHERE ShopCartID=" + Session["ShopCartID"] + " AND ProductId=" + intProductID;
            }
            Session["ShopCartId"] = null;
            msgLabel.Text = "Your order will be delivered soon";
        }
    }
}