<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab"><a class="white-text">Forgot Password</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3 class="teal-text">Forgot your password?</h3>
                <asp:Panel ID="forgotPanel" runat="server" DefaultButton="btn_submit">
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="material-icons prefix">mail_outline</i>
                            <asp:TextBox ID="tb_email" CssClass="validate" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:CustomValidator ID="emailValidator" CssClass="cv" runat="server" ControlToValidate="tb_email" ErrorMessage="Email is not valid." Display="Dynamic" ForeColor="Red" OnServerValidate="emailValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_Email" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_email" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_email">Email</label>
                        </div>
                    </div>

                    <div class="center">
                        <asp:Button ID="btn_submit" CssClass="btn" runat="server" Text="Reset Password" OnClick="btn_submit_Click"></asp:Button>
                        <p>
                            <asp:LinkButton ID="linkbtn_back" runat="server" PostBackUrl="~/Login.aspx">Go back</asp:LinkButton>
                        </p>
                    </div>

                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

