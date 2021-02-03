<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Project.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgDept" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="imgLnkDpt" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "DeptImage", "images/{0}") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"DepartmentID","TypeProduct.aspx?DeptID={0}") %>' ImageHeight="150px" ImageWidth="250px">imgLnkDept </asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:HyperLinkField DataNavigateUrlFields="DepartmentID" DataNavigateUrlFormatString="TypeProduct.aspx?DeptID={0}" DataTextField="DeptName" />
    </Columns>
</asp:GridView>

</asp:Content>
