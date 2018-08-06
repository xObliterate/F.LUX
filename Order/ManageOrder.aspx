<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ManageOrder.aspx.cs" Inherits="Profile_ManageOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Order</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <asp:GridView ID="gv_order" runat="server" AutoGenerateColumns="false" DataKeyNames="gsoprodid" OnRowDataBound="gv_order_RowDataBound" OnRowCommand="gv_order_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="img_prod" runat="server" AlternateText="Image not found" Width="178px" Height="100px" ImageUrl='<%# Eval("gsimage","~/img/{0}") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="gsorderId" HeaderText="Order #" />
                        <asp:BoundField DataField="gsdate" HeaderText="Order Date" />

                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lbl_quantity" runat="server" Text='<%# Eval("gsorderId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lbl_status" runat="server" ForeColor="Blue" Text='<%# Eval("gsorderstatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Deliver By">
                            <ItemTemplate>
                                <asp:Label ID="lbl_shipdate" runat="server" Text='<%# Eval("gsshipdate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkbtn_delivered" runat="server" CommandArgument='<%# Eval("gsorderstatus") %>' CommandName="Delivered">Delivered </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

