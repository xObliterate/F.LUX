<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ManageProduct.aspx.cs" Inherits="ManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Product Overview</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <asp:Panel ID="searchPanel" runat="server" DefaultButton="btn_search">
                    <div class="row">
                        <div class="input-field col s6">
                            <asp:TextBox ID="tb_search" runat="server" placeholder="Search Product Name"></asp:TextBox>
                        </div>
                        <div class="input-field col s6">
                            <asp:Button ID="btn_search" runat="server" CssClass="btn" Text="Search" OnClick="btn_search_Click" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:GridView ID="gv_product" CssClass="striped responsive-table" runat="server" DataKeyNames="gsProdID" AutoGenerateColumns="False" OnRowCancelingEdit="gv_product_RowCancelingEdit" OnRowEditing="gv_product_RowEditing" OnRowUpdating="gv_product_RowUpdating" OnRowDataBound="gv_product_RowDataBound" OnRowDeleting="gv_product_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="gsProdName" HeaderText="Name">
                            <ItemStyle ForeColor="#0277bd" />
                        </asp:BoundField>
                        <asp:BoundField DataField="gsDatetime" HeaderText="Created" ReadOnly="True" />
                        <asp:BoundField DataField="gsPrice" DataFormatString="{0:C}" HeaderText="Price" />
                        <asp:BoundField DataField="gsQuantity" HeaderText="Quantity" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lbl_status" runat="server" Text='<%# Eval("gsStatus")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" EditText="&lt;i class=&quot;material-icons&quot;&gt;edit&lt;/i&gt;" DeleteText="&lt;i class=&quot;material-icons&quot;&gt;delete_forever&lt;/i&gt;" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btn_addProducts" runat="server" CssClass="btn" Text="Add New" OnClick="btn_addProducts_Click" />
                <asp:Label ID="lbl_msg" runat="server" Visible="false" ForeColor="#ef6c00"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

