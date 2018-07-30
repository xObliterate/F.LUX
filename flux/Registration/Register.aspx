<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s3"><a class="white-text" href="Login.aspx">Login</a></li>
            <li class="tab col s3"><a class="white-text" href="Register.aspx">Register</a></li>
        </ul>
        <div id="register" class="col s12">
            <div class="form-container">
                <h3 class="teal-text">Welcome</h3>
                <asp:Panel ID="regPanel" runat="server" DefaultButton="btn_submit">
                    <div class="row">
                        <div class="input-field col s6">
                            <i class="far fa-user prefix"></i>
                            <asp:TextBox ID="tb_fname" CssClass="validate" runat="Server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_fname" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_fname" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_fname">First Name</label>
                        </div>
                        <div class="input-field col s6">
                            <asp:TextBox ID="tb_lname" CssClass="validate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_lname" EnableClientScript="false" ControlToValidate="tb_lname" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_lname">Last Name</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">mail_outline</i>
                            <asp:TextBox ID="tb_email" CssClass="validate" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:CustomValidator ID="emailValidator" CssClass="cv" runat="server" ControlToValidate="tb_email" ErrorMessage="Email is not valid." Display="Dynamic" ForeColor="Red" OnServerValidate="emailValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_email" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_email" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_email">Email</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">smartphone</i>
                            <asp:TextBox ID="tb_phone" CssClass="validate" runat="server" MaxLength="8"></asp:TextBox>
                            <asp:CustomValidator ID="phoneValidator" CssClass="cv" runat="server" ControlToValidate="tb_phone" ErrorMessage="Mobile number is not valid" Display="Dynamic" ForeColor="Red" OnServerValidate="phoneValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_phone" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_phone" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_phone">Phone</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">lock_outline</i>
                            <asp:TextBox ID="tb_password" CssClass="validate" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_password" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_password" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_password">Password</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">lock_outline</i>
                            <asp:TextBox ID="tb_passwordConfirm" CssClass="validate" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            <asp:CustomValidator ID="passValidator" CssClass="cv" runat="server" ControlToValidate="tb_passwordConfirm" ErrorMessage="Password does not match" Display="Dynamic" ForeColor="Red" OnServerValidate="passValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_passwordConfirm" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_passwordConfirm" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_passwordConfirm">Password Confirmation</label>
                        </div>
                    </div>
                    <div class="center">
                        <asp:Button ID="btn_submit" CssClass="btn" runat="server" Text="Submit" OnClick="btn_submit_Click"></asp:Button>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

