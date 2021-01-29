using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ShopperID"] != null) {
                LogoutButton.Visible = true;
                RegisterButton.Visible = false;
                loginsButton.Visible = false;
                SellButton.Visible = true;
                ProfileButton.Visible = true;
            } else {
                RegisterButton.Visible = true;
                LogoutButton.Visible = false;
                loginsButton.Visible = true;
                SellButton.Visible = false;
                ProfileButton.Visible = false;
            }

        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void CatalogButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalog.aspx");
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        //Faster redirect to catalog page
        protected void CatalogStationary_Click(object sender, EventArgs e)
        {
            Response.Redirect("TypeProduct.aspx?DeptID=1");
        }



        protected void SellButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sell.aspx");
        }

        protected void CatalogSnacks_Click(object sender, EventArgs e)
        {
            Response.Redirect("TypeProduct.aspx?DeptID=2");
        }

        protected void ProfileButton_Click(object sender, EventArgs e)
        {

        }
    }
}