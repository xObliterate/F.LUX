<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ApproveProducts.aspx.cs" Inherits="Product_ApproveProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Approve</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3>
                    <asp:Label ID="lbl_empty" runat="server" CssClass="teal-text" Text="No Products to Approve" Visible="false"></asp:Label></h3>
                <asp:GridView ID="gv_approveproducts" runat="server" AutoGenerateColumns="False" DataKeyNames="gsProdID" OnRowCommand="gv_approveproducts_RowCommand">
                    <Columns>

                        <asp:ImageField AlternateText="Image not found" ControlStyle-Width="178" ControlStyle-Height="100" DataImageUrlField="gsImage">
                        </asp:ImageField>


                        <asp:TemplateField HeaderText="Product">
                            <ItemTemplate>
                                <strong>
                                    <asp:Label ID="lbl_prodname" runat="server" Text='<%# Eval("gsProdName") %>'></asp:Label></strong>
                                <br>
                                <asp:Label ID="lbl_proddesc" runat="server" Text='<%# Eval("gsShortDesc") %>' CssClass="grey-text"></asp:Label>
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="gsPrice" DataFormatString="{0:C}" HtmlEncode="false" HeaderText="Price">
                            <ItemStyle CssClass="" ForeColor="#EF6C00" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkbtn_approved" runat="server" CommandName="Check"><i class="fas fa-check"></i></asp:LinkButton>
                                <asp:LinkButton ID="linkbtn_reject" runat="server" ForeColor="Red" CommandName="Cross"><i class="fas fa-times"></i></asp:LinkButton>   
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>

