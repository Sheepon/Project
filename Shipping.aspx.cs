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
            int intQty=0;
            double dblBalance=0, dblTotalValue = 0, dblPrice = 0;

            DatabaseMgmt objdbMgmt = new DatabaseMgmt();
            DatabaseMgmt objdbMgmtProduct = new DatabaseMgmt();
            DatabaseMgmt objdbMgmtUpdate = new DatabaseMgmt();
            DatabaseMgmt objdbAccCredit = new DatabaseMgmt();

            SqlDataReader dR,dRProduct, dRBalance;

            string strSqlCmd = $"Select productId,price,quantity from shopcartitem where shopcartid = '{Session["ShopCartId"]}'";
            dR = objdbMgmt.ExecuteSelect(strSqlCmd);
            while (dR.Read()) {
                intQty = int.Parse(dR["quantity"].ToString());
                dblPrice = double.Parse(dR["price"].ToString());
                strSqlCmd = $"Select productid,quantity from product where productid = '{dR["productId"]}'";
                dRProduct = objdbMgmtProduct.ExecuteSelect(strSqlCmd);
                while(dRProduct.Read()) {

                    dblTotalValue = dblPrice * intQty;


                    strSqlCmd = $"Select Balance FROM AccountCredit Where AccBalanceID = " + Session["ShopperID"];
                    dRBalance = objdbAccCredit.ExecuteSelect(strSqlCmd);

                    if (dRBalance.Read())
                    {
                        dblBalance = double.Parse(dRBalance["Balance"].ToString());
                    }
                    dRBalance.Close();

                    dblBalance = dblBalance - dblTotalValue;

                    if (dblBalance >= 0)
                    {
                        strSqlCmd = $"Update AccountCredit Set Balance = {dblBalance} Where AccBalanceID = " + Session["ShopperID"];
                        objdbAccCredit.ExecuteNonQuery(strSqlCmd);

                        int intTmp = int.Parse(dRProduct["quantity"].ToString()) - int.Parse(dR["quantity"].ToString());
                        strSqlCmd = $"update Product set quantity = {intTmp} where productId = '{dRProduct["productid"]}'";
                        objdbMgmtUpdate.ExecuteNonQuery(strSqlCmd);

                        msgLabel.Text = "Your order will be delivered soon";
                    }
                    else
                        msgLabel.Text = "Insufficient Funds, please top up your account";
                }
                dRProduct.Close();

                Session["ShopCartId"] = null;
                Response.AddHeader("REFRESH", "3;URL=Home.aspx");
            }
        }
    }
}