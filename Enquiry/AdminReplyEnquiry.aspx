<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="AdminReplyEnquiry.aspx.cs" Inherits="Enquiry_AdminReplyEnquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Reply</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <asp:Panel ID="replyPanel" runat="server" DefaultButton="btn_submit">
                     <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="tb_name" runat="Server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="tb_email" runat="Server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="tb_message" runat="Server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="tb_replymessage" runat="Server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_replymessage" EnableClientScript="false" ControlToValidate="tb_replymessage" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_replymessage">Message</label>
                        </div>
                    </div>
                    <div class="center">
                        <asp:Button ID="btn_submit" CssClass="btn" runat="server" Text="Submit" OnClick="btn_submit_Click"></asp:Button>
                    </div>
                    <asp:Label ID="lbl_msg" CssClass="right" ForeColor="#ef6c30" runat="server" Text="Enquiry sent!" Visible="false"></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

