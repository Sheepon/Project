<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="CardDetails.aspx.cs" Inherits="Project.CardDetails" %>
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
          .auto-style12 {
              width: 562px;
              text-align: right;
              vertical-align: top;
              height: 49px;
          }
          .auto-style13 {
              width: 408px;
              text-align: left;
              height: 49px;
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
                <td style="text-align:center;text-shadow:3px;"colspan="2" class="auto-style5">Credit Card Details</td>
            </tr>
            <tr>
                <td class="leftcolumn">Name on Card</td>
                <td class="rightcolumn">
                    <asp:TextBox ID="nameTextBox2" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="cardNameValidator" runat="server" ControlToValidate="nameTextBox2" ErrorMessage="Please enter your Name" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="leftcolumn">Card Number</td>
                <td class="rightcolumn">
                    <asp:TextBox ID="cardTextBox" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="cardNumberCheckValidator" runat="server" ControlToValidate="cardTextBox" ErrorMessage="Please enter correct Card Number" ForeColor="#FF5050" ValidationExpression="^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$"></asp:RegularExpressionValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="cardNumberValidator" runat="server" ControlToValidate="cardTextBox" ErrorMessage="Please enter Card Number" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    Expiry Date</td>
                <td class="auto-style7">
                    <asp:TextBox ID="expiryDateTextbox" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="expiryDateValidator" runat="server" ControlToValidate="expiryDateTextbox" ErrorMessage="Please enter Expiry Date" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                    <br />
                    </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    CVC</td>
                <td class="auto-style13">
                    <asp:TextBox ID="cvcTextbox" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="addressValidator" runat="server" ControlToValidate="cvcTextbox" ErrorMessage="Please enter CVC" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align:center" class="auto-style10" colspan="2">
                    <asp:Label ID="msgLabel3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                        <asp:LinkButton CSSClass="button" ID="cardSaveButton" runat="server" OnClick="cardSaveButton_Click">Save</asp:LinkButton>
                        <asp:LinkButton CSSClass="button" ID="cardUpdateButton" runat="server" OnClick="cardUpdateButton_Click">Update</asp:LinkButton>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
