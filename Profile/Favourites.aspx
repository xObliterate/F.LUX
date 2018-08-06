<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Favourites.aspx.cs" Inherits="Profile_Favourites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">My Wishlist</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <asp:GridView ID="gv_favourites" CssClass="highlight" runat="server" AutoGenerateColumns="False" DataKeyNames="gsprodID" OnRowDataBound="gv_favourites_RowDataBound" OnRowCommand="gv_favourites_RowCommand">
                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="img_prod" runat="server" AlternateText="Image not found" Width="178px" Height="100px" ImageUrl='<%Eval("gsprodID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lbl_proddesc" runat="server" Text='<%# Eval("gsprodID") %>'></asp:Label>
                                <br />
                                <asp:LinkButton ID="btn_remove" runat="server" Text="Remove" CommandArgument='<%# Eval("gsfavID") %>' CommandName="Remove"><i class="material-icons">delete</i></asp:LinkButton>
                           
                                 </ItemTemplate>
                        </asp:TemplateField>


                          <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="lbl_prodprice" runat="server" Text='<%# Eval("gsprodID") %>'></asp:Label>
                                 </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

