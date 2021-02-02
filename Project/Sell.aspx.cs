﻿using System;
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
            float fltPrice = float.Parse(priceButton.Text);
            int intStock = int.Parse(stockTextbox.Text);
            int productType = int.Parse(typeDropdown.SelectedValue);
            int productId = 0;
            string strSqlCmd;
            string strFileName;
            string strFilePath;
            string strFolder;
            strFolder = Server.MapPath("~/Images/Products/");

            strFileName = oFile.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);

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
            }

            strSqlCmd = $"Insert into Product(productTitle,ProductDesc,ProductImage,Price,Quantity)" +
                $"Values('{strProductName}','{strProductDescription}','{strFileName}','{fltPrice}','{intStock}')";
            dbObj.ExecuteNonQuery(strSqlCmd);

            strSqlCmd = $"select productId from Product where productTitle = '{strProductName}'";
            dR = dbObj.ExecuteSelect(strSqlCmd);
            while (dR.Read()) {
                productId = int.Parse(dR["productId"].ToString());
            }
            dR.Close();

            strSqlCmd = $"Insert into DepartmentProduct(DepartmentId,ProductID) Values({productType},{productId})";
            dbObj.ExecuteNonQuery(strSqlCmd);
        }
    }
}