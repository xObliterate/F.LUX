<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-container">
        <div class="row">
            <div class="input-field col s12 m4 l4">
                <div class="card white darken-1">
                    <div class="card-content black-text">
                        <span class="card-title blue-text">Personal Profile</span>
                        <asp:Button ID="btn_editProfile" runat="server" CssClass="btn-floating halfway-fab blue center" Text="EDIT" OnClick="btn_editProfile_Click"></asp:Button>
                        <h5>
                            <asp:Label ID="lbl_email" runat="server"></asp:Label>
                        </h5>
                        <asp:Label ID="lbl_name" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_phone" runat="server"></asp:Label>
                    </div>
                    <asp:Button ID="btn_changePw" runat="server" CssClass="btn white-text blue lighten-1 left" Text="Change password" OnClick="btn_changePw_Click"></asp:Button>
                </div>

            </div>

            <div class="input-field col s12 m4 l4">
                <div class="card white darken-1">
                    <div class="card-content black-text">
                        <span class="card-title blue-text">Address</span>
                        <asp:Button ID="btn_editAddress" runat="server" CssClass="btn-floating halfway-fab blue" Text="EDIT" OnClick="btn_editAddress_Click"></asp:Button>
                        <strong>
                            <asp:Label ID="lbl_addName" runat="server" Text="Address Name"></asp:Label>
                        </strong>
                        <br />
                        <asp:Label ID="lbl_address" runat="server" Text="Address"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_postal" runat="server" Text="Postal Code"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_addPhone" runat="server" Text="Address phone"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="input-field col s12 m4 l4">
                <div class="card white darken-1">
                    <div class="card-content black-text">
                        <span class="card-title blue-text">Billing Address</span>
                        <strong>
                            <asp:Label ID="lbl_billName" runat="server" Text="Billing Name"></asp:Label>
                        </strong>
                        <br />
                        <asp:Label ID="lbl_billAddress" runat="server" Text="Billing Address"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_billPostal" runat="server" Text="Billing Postal Code"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_billPhone" runat="server" Text="Billing Phone"></asp:Label>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

