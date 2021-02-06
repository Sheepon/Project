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
    public partial class CardDetails : System.Web.UI.Page
    {
        string strCardName, strCardNumber, strExpiryDate, strCVC, strSqlCmd;
        int intShopperID, intManualID;

        DatabaseMgmt dbObj = new DatabaseMgmt();

        SqlDataReader objDataReader;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cardSaveButton_Click(object sender, EventArgs e)
        {
            strCardName = nameTextBox2.Text;
            strCardNumber = cardTextBox.Text;
            strExpiryDate = expiryDateTextbox.Text;
            strCVC = cvcTextbox.Text;

            //getting sessioin ID
            strSqlCmd = $"Select ShopperID FROM Shopper Where ShopperID = " + Session["ShopperID"];
            objDataReader = dbObj.ExecuteSelect(strSqlCmd);

            if (objDataReader.Read())
            {
                intShopperID = int.Parse(objDataReader["ShopperID"].ToString());
            }
            objDataReader.Close();

            //checking if card is already saved
            strSqlCmd = $"Select ManualID FROM CreditCard Where ManualID = " + Session["ShopperID"];
            objDataReader = dbObj.ExecuteSelect(strSqlCmd);

            if (objDataReader.Read())
            {
                intManualID = int.Parse(objDataReader["ManualID"].ToString());
            }
            objDataReader.Close();

            if (intShopperID != intManualID)
            {
                strSqlCmd = $"Insert into CreditCard(NameOnCard, CardNumber, ExpiryDate, CVC, ManualId) VALUES ('{strCardName}','{strCardNumber}'," +
                           $"'{strExpiryDate}','{strCVC}', {intShopperID})";
                dbObj.ExecuteNonQuery(strSqlCmd);

                msgLabel3.Text = "Card Successfully Saved";
            }
            else
                msgLabel3.Text = "Card Previously Saved";
        }

        protected void cardUpdateButton_Click(object sender, EventArgs e)
        {
            strCardName = nameTextBox2.Text;
            strCardNumber = cardTextBox.Text;
            strExpiryDate = expiryDateTextbox.Text;
            strCVC = cvcTextbox.Text;

            //getting session ID
            strSqlCmd = $"Select ShopperID FROM Shopper Where ShopperID = " + Session["ShopperID"];
            objDataReader = dbObj.ExecuteSelect(strSqlCmd);

            if (objDataReader.Read())
            {
                intShopperID = int.Parse(objDataReader["ShopperID"].ToString());
            }
            objDataReader.Close();

            //checking if card is already saved
            strSqlCmd = $"Select ManualID FROM CreditCard Where ManualID = " + Session["ShopperID"];
            objDataReader = dbObj.ExecuteSelect(strSqlCmd);

            if (objDataReader.Read())
            {
                intManualID = int.Parse(objDataReader["ManualID"].ToString());
            }
            objDataReader.Close();

            if (intShopperID == intManualID)
            {
                strSqlCmd = $"Update CreditCard Set NameOnCard = '{strCardName}', CardNumber = '{strCardNumber}', ExpiryDate = '{strExpiryDate}'," +
                            $"CVC = '{strCVC}' Where ManualID = " + Session["ShopperID"];
                dbObj.ExecuteNonQuery(strSqlCmd);

                msgLabel3.Text = "Card Successfully Updated";
            }
        }
    }
}