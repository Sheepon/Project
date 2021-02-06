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
    public partial class AccountCredit : System.Web.UI.Page
    {
        string strSqlCmd;
        double dblValue, dblBalance;
        int intAccBalanceID, intShopperID;

        DatabaseMgmt dbObj = new DatabaseMgmt();

        SqlDataReader objDataReader;
        protected void Page_Load(object sender, EventArgs e)
        {
            //loads balance
            strSqlCmd = $"Select Balance FROM AccountCredit Where AccBalanceID = " + Session["ShopperID"];
            objDataReader = dbObj.ExecuteSelect(strSqlCmd);

            if (objDataReader.Read())
            {
                dblBalance = Convert.ToDouble(objDataReader["Balance"]);
            }
            objDataReader.Close();

            balanceTextBox.Text = "$" + string.Format(Convert.ToString(dblBalance), "0.00");
        }

        protected void depositButton_Click(object sender, EventArgs e)
        {
            //add in money to db
            dblValue = double.Parse(valueTextBox.Text);
            intShopperID = int.Parse(Session["ShopperID"].ToString());

            strSqlCmd = $"Select AccBalanceID,Balance FROM AccountCredit Where AccBalanceID = " + Session["ShopperID"];
            objDataReader = dbObj.ExecuteSelect(strSqlCmd);

            if (objDataReader.Read())
            {
                intAccBalanceID = int.Parse(objDataReader["AccBalanceID"].ToString());
                dblBalance = double.Parse(objDataReader["Balance"].ToString());
            }
            objDataReader.Close();

            dblBalance = dblBalance + dblValue;

            if (intShopperID == intAccBalanceID)
            {
                strSqlCmd = $"Update AccountCredit Set Balance = {dblBalance} Where AccBalanceID = {intShopperID}";
                dbObj.ExecuteNonQuery(strSqlCmd);
                msgLabel4.Text = "Deposit Successfully";

                //loads balance
                strSqlCmd = $"Select Balance FROM AccountCredit Where AccBalanceID = " + Session["ShopperID"];
                objDataReader = dbObj.ExecuteSelect(strSqlCmd);

                if (objDataReader.Read())
                {
                    dblBalance = Convert.ToDouble(objDataReader["Balance"]);
                }
                objDataReader.Close();

                balanceTextBox.Text = "$" + string.Format(Convert.ToString(dblBalance), "0.00");
            }
            else
            {
                strSqlCmd = $"Insert into AccountCredit(Balance, AccBalanceID) VALUES({dblBalance}, {intShopperID})";
                dbObj.ExecuteNonQuery(strSqlCmd);
                msgLabel4.Text = "Deposit Successfully";

                //loads balance
                strSqlCmd = $"Select Balance FROM AccountCredit Where AccBalanceID = " + Session["ShopperID"];
                objDataReader = dbObj.ExecuteSelect(strSqlCmd);

                if (objDataReader.Read())
                {
                    dblBalance = Convert.ToDouble(objDataReader["Balance"]);
                }
                objDataReader.Close();

                balanceTextBox.Text = "$" + string.Format(Convert.ToString(dblBalance), "0.00");
            }
        }

        protected void withdrawButton_Click(object sender, EventArgs e)
        {            
            //take out money from db
            dblValue = double.Parse(valueTextBox.Text);
            intShopperID = int.Parse(Session["ShopperID"].ToString());

            strSqlCmd = $"Select AccBalanceID,Balance FROM AccountCredit Where AccBalanceID = " + Session["ShopperID"];
            objDataReader = dbObj.ExecuteSelect(strSqlCmd);

            if (objDataReader.Read())
            {
                intAccBalanceID = int.Parse(objDataReader["AccBalanceID"].ToString());
                dblBalance = double.Parse(objDataReader["Balance"].ToString());
            }
            objDataReader.Close();

            dblBalance = dblBalance - dblValue;

            if ((intShopperID == intAccBalanceID) && (dblBalance >= 0))
            {
                strSqlCmd = $"Update AccountCredit Set Balance = {dblBalance} Where AccBalanceID = {intShopperID}";
                dbObj.ExecuteNonQuery(strSqlCmd);
                msgLabel4.Text = "Withdraw Successfully";

                //loads balance
                strSqlCmd = $"Select Balance FROM AccountCredit Where AccBalanceID = " + Session["ShopperID"];
                objDataReader = dbObj.ExecuteSelect(strSqlCmd);

                if (objDataReader.Read())
                {
                    dblBalance = Convert.ToDouble(objDataReader["Balance"]);
                }
                objDataReader.Close();

                balanceTextBox.Text = "$" + string.Format(Convert.ToString(dblBalance), "0.00");
            }
            else
            {
                msgLabel4.Text = "Insufficient Fund";
            }
        }
    }
}