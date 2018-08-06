<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Product Details</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">

                <table border="0">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="img_product" runat="server" Height="400px" />

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_prodid" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:Label ID="lbl_prodname" runat="server"></asp:Label>

                            <br />
                            <asp:Label ID="lbl_prodprice" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:Button ID="btn_addtocart" CssClass="btn orange darken-2 center" runat="server" Text="Add to Cart " OnClick="btn_addtocart_Click" />
                            <asp:LinkButton ID="linkbtn_favourite" runat="server" OnClick="linkbtn_favourite_Click"><i class="material-icons pink-text">favorite_border</i></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lbl_description" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

