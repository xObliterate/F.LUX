<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="EditAddress.aspx.cs" Inherits="EditAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Edit Address</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <asp:Panel ID="editAddPanel" runat="server" DefaultButton="btn_save">
                    <div class="row">
                        <div class="input-field col s12">
                            <i class="far fa-user prefix"></i>
                            <asp:TextBox ID="tb_name" CssClass="validate" runat="server" MaxLength="70"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rfv_name" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_name" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>                   
                             <label for="tb_name">Name</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <i class="far fa-address-card prefix"></i>
                            <asp:TextBox ID="tb_add" CssClass="validate" runat="server" MaxLength="50"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="rfv_address" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_add" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>                         
                            <label for="tb_add">Addresses</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12 l6">
                            <i class="far fa-address-book prefix"></i>
                            <asp:TextBox ID="tb_postal" CssClass="validate" runat="server" MaxLength="6"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="rfv_postal" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_postal" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>                     
                            <label for="tb_postal">Postal Code</label>
                        </div>
                        <div class="input-field col s12 l6">
                            <i class="fas fa-mobile-alt prefix"></i>
                            <asp:TextBox ID="tb_phone" CssClass="validate" runat="server" MaxLength="8"></asp:TextBox>
                                  <asp:CustomValidator ID="phoneValidator" CssClass="cv" runat="server" ControlToValidate="tb_phone" ErrorMessage="Mobile number is not valid" Display="Dynamic" ForeColor="Red" OnServerValidate="phoneValidator_ServerValidate"></asp:CustomValidator>
                        
                             <asp:RequiredFieldValidator ID="rfv_phone" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_phone" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>                         
                            <label for="tb_phone">Phone Number</label>
                        </div>
                    </div>

                    <div class="center">
                        <asp:Button ID="btn_save" CssClass="btn" runat="server" Text="Save" OnClick="btn_save_Click"></asp:Button>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

