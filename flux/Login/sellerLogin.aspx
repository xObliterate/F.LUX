<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="sellerLogin.aspx.cs" Inherits="sellerLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Login</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3 class="orange-text">Hello</h3>

                <asp:Panel ID="loginPanel" runat="server" DefaultButton="btn_login">
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">email</i>
                            <asp:TextBox ID="tb_email" CssClass="validate" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:CustomValidator ID="emailValidator" CssClass="cv" runat="server" ControlToValidate="tb_email" ErrorMessage="Email is not valid." Display="Dynamic" ForeColor="Red" OnServerValidate="emailValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_Email" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_email" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_email">Email</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">lock</i>
                            <asp:TextBox ID="tb_password" CssClass="validate" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_Password" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_password" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_password">Password</label>
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

