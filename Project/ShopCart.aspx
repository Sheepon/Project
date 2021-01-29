<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ShopCart.aspx.cs" Inherits="Project.ShopCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblEmptyShopCart" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="dgShopCart" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="500px">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Item code" ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>' Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" ReadOnly="True" />
            <asp:BoundField DataField="Total" DataFormatString="{0:c}" HeaderText="Total" ReadOnly="True" />
            <asp:HyperLinkField DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="DeleteItem.aspx?ProductId={0}" Text="Remove" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    <br />
    <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btnUpdateCart" runat="server" OnClick="btnUpdateCart_Click" Text="Update Cart" />
    <asp:Button ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" Text="Check Out" />
</asp:Content>
