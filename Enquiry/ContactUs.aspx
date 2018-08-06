<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Enquiry_ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Contact Us</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3 class="teal-text">Send In Your Enquiry</h3>
                <asp:Panel ID="contactPanel" runat="server" DefaultButton="btn_submit">

                    <div class="row">
                        <div class="input-field col s12">
                            <i class="far fa-user prefix"></i>
                            <asp:TextBox ID="tb_name" CssClass="validate" runat="Server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_name" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_name" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_name">Name</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <i class="far fa-envelope prefix"></i>
                            <asp:TextBox ID="tb_email" CssClass="validate" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:CustomValidator ID="emailValidator" CssClass="cv" runat="server" ControlToValidate="tb_email" ErrorMessage="Email is not valid." Display="Dynamic" ForeColor="Red" OnServerValidate="emailValidator_ServerValidate"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="rfv_email" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_email" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_email">Email</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <i class="far fa-comment-alt prefix"></i>
                            <asp:TextBox ID="tb_message" CssClass="validate" runat="Server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_message" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_message" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_message">Message</label>
                        </div>
                    </div>

                    <div class="center">
                        <asp:Button ID="btn_submit" CssClass="btn" runat="server" Text="Submit" OnClick="btn_submit_Click"></asp:Button>
                    </div>
                    <asp:Label ID="lbl_msg" CssClass="right" ForeColor="#ef6c30"  runat="server" Text="Enquiry sent!" Visible="false"></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

