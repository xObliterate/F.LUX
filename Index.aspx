<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Search -->
    <section id="search" class="section section-search teal darken-1 white-text center">
        <div class="container">
            <div class="row">
                <div class="col s12">
                    <div class="input-field">
                        <asp:TextBox ID="tb_search" runat="server" CssClass="white grey-text autocomplete left" placeholder="Search"></asp:TextBox>
                        <asp:LinkButton ID="LinkButton4" CssClass="white-text left" BackColor="#EF6C00" runat="server"><i class="material-icons right fa-3x">search</i></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Slider -->
    <section class="slider">
        <ul class="slides">
            <li>
                <asp:Image ID="Image3" runat="server" ImageUrl="~/img/img1.jpg" />
                <div class="caption center-align">
                    <h2>Take Your Dream Vacation</h2>
                    <h5 class="light grey-text text-lighten-3 hide-on-small-only">Lorem ipsum dolor sit amet consectetur adipisicing elit. Quidem, provident eos dicta unde debitis</h5>
                </div>
            </li>
            <li>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/img/img2.jpg" />
                <!-- random image -->
                <div class="caption left-align">
                    <h2>We Work With All Budgets</h2>
                    <h5 class="light grey-text text-lighten-3 hide-on-small-only">Lorem ipsum dolor sit amet consectetur adipisicing elit. Possimus delectus inventore neque impedit</h5>
                </div>
            </li>
            <li>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/img3.jpg" />
                <!-- random image -->
                <div class="caption right-align">
                    <h2>Group & Individual Getaways</h2>
                    <h5 class="light grey-text text-lighten-3 hide-on-small-only">Lorem ipsum dolor sit amet consectetur adipisicing elit. Sunt ipsum molestias excepturi doloremque</h5>
                </div>
            </li>
        </ul>
    </section>

    <!-- Popular -->
    <section id="popular" class="section section-popular scrollspy">
        <div class="container">
            <div class="row">
                <h4 class="center">
                    <span class="teal-text">Popular</span> Products</h4>
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

