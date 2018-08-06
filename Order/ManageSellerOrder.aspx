<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ManageSellerOrder.aspx.cs" Inherits="Order_ManageSellerOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Orders</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <asp:GridView ID="gv_sellerorder" runat="server" AutoGenerateColumns="False" OnRowDataBound="gv_sellerorder_RowDataBound" OnRowCommand="gv_sellerorder_RowCommand">
                    <Columns>

                        <asp:BoundField DataField="gsorderId" HeaderText="Order #"></asp:BoundField>
                        <asp:BoundField DataField="gsdate" HeaderText="Order Date" />

                        <asp:TemplateField HeaderText="Pending Since">
                            <ItemTemplate>
                                <asp:Label ID="lbl_pending" runat="server" Text='<%# Eval("gsdate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="gsorderPrice" DataFormatString="{0:c}" HeaderText="Retail Price" />
                        <asp:BoundField DataField="gsquantity" HeaderText="Quantity" />

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lbl_orderstatus" runat="server" Text='<%# Eval("gsorderstatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkbtn_received" runat="server" CommandArgument='<%# Eval("gsorderstatus") %>' CommandName="Received">Order Received</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="linkbtn_ship" runat="server" CommandArgument='<%# Eval("gsorderstatus") %>' CommandName="Shipped">Ready to Ship </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

