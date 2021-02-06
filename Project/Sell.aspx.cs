using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Project.App_Code;
using System.Data.SqlClient;

namespace Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ShopperID = Convert.ToInt32(Session["ShopperID"]);

        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            DatabaseMgmt dbObj = new DatabaseMgmt();
            SqlDataReader dR;
            string strProductName = productNameTextBox.Text;
            string strProductDescription = productDescriptionTextBox.Text;
            float fltPrice;
            int intStock;
            int productType = int.Parse(typeDropdown.SelectedValue);
            int productId = 0;
            string strSqlCmd;
            string strFileName;
            string strFilePath;
            string strFolder;
            strFolder = Server.MapPath("~/Images/Products/");

            strFileName = oFile.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);

            if(strProductName == "") {
                Response.Write("<script>alert('Product name Needed');</script>");
                return;
            }

            if(strProductDescription == "") {
                Response.Write("<script>alert('Description Needed');</script>");
                return;
            }

            if(priceButton.Text == "") {
                Response.Write("<script>alert('Price Needed');</script>");
                return;
            } else {
                fltPrice = float.Parse(priceButton.Text);
            }

            if(stockTextbox.Text == "") {
                Response.Write("<script>alert('Stock needed');</script>");
                return;
            } else {
                intStock = int.Parse(stockTextbox.Text);
            }


            if (oFile.Value != "") {
                // Create the folder if it does not exist.
                if (!Directory.Exists(strFolder)) {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;
                oFile.PostedFile.SaveAs(strFilePath);
                msgLabel.Text = strFileName + " has been successfully uploaded.";
            } else {
                msgLabel.Text = "Click 'Browse' to select the file to upload.";
                return;
            }

            strSqlCmd = $"Insert into Product(productTitle,ProductDesc,ProductImage,Price,Quantity)" +
                $"Values('{strProductName}','{strProductDescription}','{strFileName}','{fltPrice}','{intStock}')";
            dbObj.ExecuteNonQuery(strSqlCmd);

            string strSel = "Select Max(ProductID) from Product";
            productId = int.Parse(dbObj.ExecuteScalar(strSel).ToString());

            strSqlCmd = $"Insert into DepartmentProduct(DepartmentId,ProductID) Values({productType},{productId})";
            dbObj.ExecuteNonQuery(strSqlCmd);
        }
    }
}