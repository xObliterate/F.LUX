<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ViewAllProducts.aspx.cs" Inherits="Product_ViewAllProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="popular" class="section section-popular scrollspy">
        <div class="container">
            <div class="row">
                <h4 class="center">
                    <span class="teal-text">All</span> Products</h4>
                <asp:Repeater ID="rpt_popProd" runat="server">
                    <ItemTemplate>
                        <div class="col s12 m4 l3">
                            <div class="card">
                                <div class="card-image">
                                    <asp:Image ID="img_popProdimg" CssClass="materialboxed responsive-img" ImageUrl='<%# Eval("gsImage")%>' runat="server" />
                                    <asp:LinkButton ID="linkbtn_info" runat="server" CssClass="btn-floating pulse halfway-fab waves-effect waves-light blue" OnClick="linkbtn_info_Click"><i class="fas fa-info"></i></asp:LinkButton>
                                </div>
                                <div class="card-content">
                                    <asp:HiddenField ID="lbl_popID" Value='<%# Eval("gsProdID") %>' runat="server"></asp:HiddenField>
                                    <asp:Label ID="lbl_popProdName" CssClass="teal-text" Text='<%# Eval("gsProdName") %>' runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lbl_shortdesc" Text='<%# Eval("gsShortDesc") %>' runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lbl_price" Text='<%# Eval("gsPrice", "{0:C}") %>' runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Button ID="btn_cart" runat="server" CssClass="btn orange darken-2 center" OnClick="btn_cart_Click" Text="Add to Cart"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>

