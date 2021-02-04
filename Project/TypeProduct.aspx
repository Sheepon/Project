<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="TypeProduct.aspx.cs" Inherits="Project.TypeProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:datagrid id="dgDeptProduct" runat="server" Font-Size="10pt" PageSize="3" GridLines="Horizontal"
						AutoGenerateColumns="False" ShowHeader="False" Font-Names="Verdana" CellPadding="4" Width="287px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" AllowPaging="True" AllowSorting="True" OnPageIndexChanged="dgDeptProduct_PageIndexChanged">
        <Columns>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <asp:HyperLink id="imgLnkProduct" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"ProductId", "product.aspx?ProductId={0}")%>'>
<asp:Image id="imgDept" runat="server" Height="120px" width="120px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ProductImage", "images/products/{0}")%>'>
				</asp:Image></asp:HyperLink>
                </ItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <p>
                        <asp:Label ID="lblProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductId") %>'
                        Visible="False"></asp:Label>
                        <asp:HyperLink id="lnkProductName" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"ProductId", "product.aspx?ProductId={0}") %>' Text='<%# DataBinder.Eval(Container.DataItem, "ProductTitle") %>'></asp:HyperLink>
                    </p>
                    <p>
                        <asp:Label id="lblProductPrice" runat="server" Font-Bold="True" ForeColor="Red" Text='<%# DataBinder.Eval(Container.DataItem, "Price","{0:c}") %>'></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="lblOutOfStock" runat="server" Font-Bold="True" ForeColor="Red" text='<%# DataBinder.Eval(Container.DataItem, "Quantity") + " left" %>'></asp:Label>
                        &nbsp;<asp:Image ID="imgNew" runat="server" Height="45px" ImageUrl="~/images/NewLogo.jpg" Visible="False" />
                    </p>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle NextPageText="Next Page" Font-Size="Smaller" PrevPageText="Previous Page" HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>
        <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    </asp:datagrid>
</asp:Content>
