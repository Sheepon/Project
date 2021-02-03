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
            if(Page.IsPostBack == false) {
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
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            DatabaseMgmt objdbMgmtProduct = new DatabaseMgmt();
            DatabaseMgmt objdbMgmtUpdate = new DatabaseMgmt();


            SqlDataReader dR,dRProduct;
            string strSqlCmd = $"Select productId,quantity from shopcartitem where shopcartid = '{Session["ShopCartId"]}'";
            dR = objdbMgmt.ExecuteSelect(strSqlCmd);
            while (dR.Read()) {
                strSqlCmd = $"Select productid,quantity from product where productid = '{dR["productId"]}'";
                dRProduct = objdbMgmtProduct.ExecuteSelect(strSqlCmd);
                while(dRProduct.Read()) {
                    int intTmp = int.Parse(dRProduct["quantity"].ToString()) - int.Parse(dR["quantity"].ToString());
                    strSqlCmd = $"update Product set quantity = {intTmp} where productId = '{dRProduct["productid"]}'";
                    objdbMgmtUpdate.ExecuteNonQuery(strSqlCmd);
                }
                dRProduct.Close();
                //strSqlCmd = $"update product set quantity ={dR[]};
                //strSqlCmd = "UPDATE ShopCartItem SET Quantity=" + intQuantity + " WHERE ShopCartID=" + Session["ShopCartID"] + " AND ProductId=" + intProductID;
            }
            Session["ShopCartId"] = null;
            msgLabel.Text = "Your order will be delivered soon";
            Response.AddHeader("REFRESH", "3;URL=Home.aspx");
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            int tmpDebug;
            string sqlcmd = $"update shopper set name = '{nameTextBox.Text}', address = '{addressTextbox.Text}', email = '{emailTextbox.Text}', phone = '{phoneTextbox.Text}' where shopperid = '{Session["ShopperId"]}'";
            //string strSqlCmd = $"update shopper set name = '{nameTextBox.Text}' where ShopperID='{Session["ShopperId"]}'";
            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            tmpDebug = objdbMgmt.ExecuteNonQuery(sqlcmd);
            msgLabel.Text = "Updated. Settings Take effect after logout";
            
        }
    }
}