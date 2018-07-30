<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab"><a class="white-text">Change Password</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3 class="teal-text">Change Password</h3>
                <asp:Panel ID="changePwPanel" runat="server" DefaultButton="btn_changePw">
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
                        <asp:Button ID="btn_changePw" CssClass="btn" runat="server" Text="Submit" OnClick="btn_change_Click"></asp:Button>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

