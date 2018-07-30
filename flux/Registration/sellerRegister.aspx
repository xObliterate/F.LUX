<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="sellerRegister.aspx.cs" Inherits="sellerRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Register</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3 class="teal-text">Join as Seller</h3>
                <asp:Panel ID="sellerRegPanel" runat="server" DefaultButton="btn_submit">
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">email</i>
                            <asp:TextBox ID="tb_email" CssClass="validate" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:CustomValidator ID="emailValidator" CssClass="cv" runat="server" ControlToValidate="tb_email" ErrorMessage="Email is not valid." Display="Dynamic" ForeColor="Red" OnServerValidate="emailValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_email" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_email" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_email">Email</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">store_outline</i>
                            <asp:TextBox ID="tb_storeName" CssClass="validate" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_storeName" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_storeName" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_storeName">Store Name</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s6">
                            <i class="material-icons prefix">smartphone</i>
                            <asp:TextBox ID="tb_phone" CssClass="validate" runat="server" MaxLength="8"></asp:TextBox>
                            <asp:CustomValidator ID="phoneValidator" CssClass="cv" runat="server" ControlToValidate="tb_phone" ErrorMessage="Mobile number is not valid" Display="Dynamic" ForeColor="Red" OnServerValidate="phoneValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_phone" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_phone" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_phone">Phone</label>
                        </div>
                        <div class="input-field col s6">
                            <i class="material-icons prefix">local_phone</i>
                            <asp:TextBox ID="tb_fax" runat="server" MaxLength="8"></asp:TextBox>
                            <asp:CustomValidator ID="faxValidator" CssClass="cv" runat="server" ControlToValidate="tb_fax" ErrorMessage="Fax number is not valid" Display="Dynamic" ForeColor="Red" OnServerValidate="faxValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_fax" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_fax" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_fax  ">Fax</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">lock</i>
                            <asp:TextBox ID="tb_password" CssClass="validate" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_password" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_password" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_password">Password</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">lock</i>
                            <asp:TextBox ID="tb_passwordConfirm" CssClass="validate" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            <asp:CustomValidator ID="passValidator" CssClass="cv" runat="server" ControlToValidate="tb_passwordConfirm" ErrorMessage="Password does not match" Display="Dynamic" ForeColor="Red" OnServerValidate="passValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_passwordConfirm" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_passwordConfirm" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_passwordConfirm">Password Confirmation</label>
                        </div>
                    </div>                    
                    <div class="center">
                        <asp:Button ID="btn_submit" CssClass="btn" runat="server" Text="Submit" O OnClick="btn_submit_Click"></asp:Button>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

