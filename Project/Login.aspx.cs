using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using Project.App_Code;
using System.Security.Cryptography;

namespace Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            SqlDataReader dR;
            string strPassword;

            DatabaseMgmt dbObj = new DatabaseMgmt();

            string selStr = $"select passwd, name, ShopperId from SHopper Where email ='{emailTextBox.Text}'";

            dR = dbObj.ExecuteSelect(selStr);
            if (dR.Read()) {
                strPassword = dR["passwd"].ToString();

                if(strPassword == pswTextBox.Text) {
                    Session["Password"] = strPassword;
                    Session["Name"] = dR["name"].ToString();
                    Session["ShopperId"] = dR["ShopperID"].ToString();
                    Response.Redirect("Home.aspx");
                } else {
                    msgLabel.Text = "Email or password incorrect";
                }

            } else {
                msgLabel.Text = "Email or password incorrect";
            }
            dR.Close();
        }
    }
}