<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AccountCredit.aspx.cs" Inherits="Project.AccountCredit" %>
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
            .auto-style10 {
                text-align: right;
                vertical-align: top;
                height: 24px;
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
                <td style="text-align:center;text-shadow:3px;"colspan="2" class="auto-style5">Account Credit</td>
            </tr>
            <tr>
                <td class="leftcolumn">Balance</td>
                <td class="rightcolumn">
                    <asp:TextBox ID="balanceTextBox" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="leftcolumn">Deposit/Withdraw</td>
                <td class="rightcolumn">
                    <asp:TextBox ID="valueTextBox" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="depositValidatior" runat="server" ControlToValidate="valueTextBox" ErrorMessage="Please enter a value" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align:center" class="auto-style10" colspan="2">
                    <asp:Label ID="msgLabel4" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                        <asp:LinkButton CSSClass="button" ID="depositButton" runat="server" OnClick="depositButton_Click">Deposit</asp:LinkButton>
                        <asp:LinkButton CSSClass="button" ID="withdrawButton" runat="server" OnClick="withdrawButton_Click">Withdraw</asp:LinkButton>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
