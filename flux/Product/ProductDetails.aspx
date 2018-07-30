<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <div class="col s12">
            <div class="form-container">
                <asp:Image ID="img_product" runat="server" Width="200px" />
                <asp:Label ID="lbl_prodname" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

