<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Cart</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3>
                    <asp:Label ID="lbl_msg" runat="server" CssClass="teal-text" Text="Cart is empty" Visible="false"></asp:Label></h3>
                <asp:GridView ID="gv_cart" CssClass="highlight" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" OnRowCommand="gv_cart_RowCommand">
                    <Columns>

                        <asp:ImageField AlternateText="Image not found" ControlStyle-Width="178" ControlStyle-Height="100" DataImageUrlField="Product_Image">
                        </asp:ImageField>

                        <asp:TemplateField HeaderText="My Bag">
                            <ItemTemplate>
                                <strong>
                                    <asp:Label ID="lbl_prodname" runat="server" Text='<%# Eval("Product_Name") %>'></asp:Label></strong>
                                <br>
                                <asp:Label ID="lbl_proddesc" runat="server" Text='<%# Eval("Product_Desc") %>' CssClass="grey-text"></asp:Label>
                                <br />
                                <br />
                                <asp:LinkButton ID="btn_remove" runat="server" Text="Remove" CommandArgument='<%# Eval("ItemID") %>' CommandName="Remove"><i class="material-icons">delete</i></asp:LinkButton>
                                <asp:LinkButton ID="btn_favourite" runat="server" Text="Favourite" CommandArgument='<%# Eval("ItemID") %>' CommandName="Favourite"><i class="material-icons pink-text">favorite</i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Product_Price" DataFormatString="{0:C}" HtmlEncode="false" HeaderText="Price">
                            <ItemStyle CssClass="" ForeColor="#EF6C00" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_minus" runat="server" CommandName="Minus"><i class="fas fa-minus"></i></asp:LinkButton>
                                <%if (Session["Id"] != null)
                                    { %>
                                <asp:TextBox ID="tb_cartQuantity" CssClass="center" Width="10%" runat="server" Text='<%# Eval("Product_Quantity") %>'></asp:TextBox>
                                <%}
                                    else
                                    {%>
                                <asp:TextBox ID="tb_quantity" CssClass="center" Width="10%" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                <%}
                                %>
                                <asp:LinkButton ID="btn_plus" runat="server" CommandName="Add" Text="+"><i class="fas fa-plus"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="input-field col s12">
                    <br />
                    <asp:Label ID="lbl_subtotal" CssClass="right" runat="server" Visible="false"></asp:Label>
                    <br />
                    <asp:Label ID="lbl_deliveryfee" CssClass="right" runat="server" Visible="false"></asp:Label>
                    <br />
                    <asp:Label ID="lbl_totalprice" CssClass="right" runat="server" Visible="false"></asp:Label>
                    <br />
                    <asp:Button ID="btn_checkout" CssClass="btn right" BackColor="#EF6C00" runat="server" Visible="false" Text="Proceed to checkout" OnClick="btn_checkout_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

