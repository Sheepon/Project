<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="Project.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <style>
            .overall{
                background-color: snow;
                width: 480px;
                height: 188px;
                border:1px solid #dadce0;
                border-radius:10px;
                margin:0 auto;
                box-shadow:5px;
           
                justify-content: center;
                align-items: center;
                height: auto;
            }

            .button{
                background-color: white;
                border:1px solid #dadce0;
                padding: 10px;
                display: inline-block;
                margin: 4px 2px;
                border-radius:10px;
                color:black;
                text-align: center;
                text-decoration: none;

            }

            .button a{
                color:black;
                text-align: center;
                text-decoration: none;
            }

            .rightcolumn {
                width: 408px;
                text-align:left;
            }
            .auto-style2 {
                text-align:center;
            }
            .auto-style3 {
                width: 480px;
                height: 197px;
            }
            .leftcolumn {
                width: 562px;
                text-align: right;
                vertical-align:top;
        }
            .auto-style5 {
                font-size: 20px;
                height: 55px;
            }
            .auto-style6 {
                width: 562px;
                text-align: right;
                vertical-align: top;
                height: 43px;
            }
            .auto-style7 {
                width: 408px;
                text-align: left;
                height: 43px;
            }
            .auto-style8 {
                width: 562px;
                text-align: right;
                vertical-align: top;
                height: 24px;
            }
            .auto-style9 {
                width: 408px;
                text-align: left;
                height: 24px;
            }
            .auto-style10 {
                text-align: right;
                vertical-align: top;
                height: 24px;
            }
                .auto-style11 {
                    width: 562px;
                    text-align: right;
                    vertical-align: top;
                    height: 23px;
                }
                .auto-style12 {
                    width: 408px;
                    text-align: left;
                    height: 23px;
                }
                .auto-style13 {
                    width: 562px;
                    text-align: right;
                    vertical-align: top;
                    height: 80px;
                }
                .auto-style14 {
                    width: 408px;
                    text-align: left;
                    height: 80px;
                }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
        <div class="overall">

        <table class="auto-style3">
            <tr>
                <td style="text-align:center;text-shadow:3px;"colspan="2" class="auto-style5">Product</td>
            </tr>
            <tr>
                <td class="auto-style6">Product Name</td>
                <td class="auto-style7">
                    <asp:TextBox ID="productNameTextBox" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="116px"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style13">Product Description</td>
                <td class="auto-style14">
                    <asp:TextBox ID="productDescriptionTextBox" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine" Height="102px" Width="119px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    Product Image</td>
                <td class="auto-style12">
                    <INPUT id="oFile" type="file" runat="server" NAME="oFile">
                    <br />
                    </td>
            </tr>
            <tr>
                <td class="leftcolumn">
                    Price</td>
                <td class="rightcolumn">
                    <asp:TextBox ID="priceButton" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    Stocks</td>
                <td class="auto-style9">
                    <asp:TextBox ID="stockTextbox" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" TextMode="Number"></asp:TextBox>
                    <br />
                    </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    Type</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="typeDropdown" runat="server">
                        <asp:ListItem Value="1">Stationary</asp:ListItem>
                        <asp:ListItem Value="2">Food</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style="text-align:center" class="auto-style10" colspan="2">
                    <asp:Label ID="msgLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                        <asp:LinkButton CSSClass="button" ID="sellButton" runat="server" OnClick="sellButton_Click">Sell!</asp:LinkButton>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
