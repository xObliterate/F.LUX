<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s3"><a class="white-text active" href="Login.aspx">Login</a></li>
            <li class="tab col s3"><a class="white-text" href="Register.aspx">Register</a></li>
        </ul>
        <div id="login" class="col s12">
            <div class="form-container">
                <h3 class="teal-text">Hello</h3>

                <asp:Panel ID="loginPanel" runat="server" DefaultButton="btn_login">
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">mail_outline</i>
                            <asp:TextBox ID="tb_email" CssClass="validate" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:CustomValidator ID="emailValidator" CssClass="cv" runat="server" ControlToValidate="tb_email" ErrorMessage="Email is not valid." Display="Dynamic" ForeColor="Red" OnServerValidate="emailValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_Email" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_email" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_email">Email</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">lock_outline</i>
                            <asp:TextBox ID="tb_password" CssClass="validate" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_Password" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_password" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_password">Password</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <label>
                                &nbsp<asp:CheckBox ID="cb_remember" runat="server" />
                                <span>Remember Me</span>
                            </label>
                        </div>
                    </div>

                    <div class="center">
                        <asp:Button ID="btn_login" CssClass="btn" runat="server" Text="Login" OnClick="btn_login_Click"></asp:Button>
                        <p>
                            <asp:LinkButton ID="linkbtn_forgot" runat="server" PostBackUrl="~/ForgetPassword.aspx">Forgotten password?</asp:LinkButton>
                        </p>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

