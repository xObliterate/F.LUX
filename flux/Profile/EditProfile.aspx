<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Edit Profile</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <asp:Panel ID="editProfilePanel" runat="server" DefaultButton="btn_update">
                    <div class="row">
                        <div class="input-field col s6">
                            <i class="far fa-user prefix"></i>
                            <asp:TextBox ID="tb_fname" CssClass="validate" runat="Server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_fname" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_fname" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                        </div>
                        <div class="input-field col s6">
                            <asp:TextBox ID="tb_lname" CssClass="validate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_lname" EnableClientScript="false" ControlToValidate="tb_lname" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">mail_outline</i>
                            <asp:TextBox ID="tb_email" CssClass="validate" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:CustomValidator ID="emailValidator" CssClass="cv" runat="server" ControlToValidate="tb_email" ErrorMessage="Email is not valid." Display="Dynamic" ForeColor="Red" OnServerValidate="emailValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_email" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_email" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">smartphone</i>
                            <asp:TextBox ID="tb_phone" CssClass="validate" runat="server" MaxLength="8"></asp:TextBox>
                            <asp:CustomValidator ID="phoneValidator" CssClass="cv" runat="server" ControlToValidate="tb_phone" ErrorMessage="Mobile number is not valid" Display="Dynamic" ForeColor="Red" OnServerValidate="phoneValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_phone" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_phone" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="center">
                        <asp:Button ID="btn_update" CssClass="btn" runat="server" Text="Update" OnClick="btn_update_Click"></asp:Button>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

