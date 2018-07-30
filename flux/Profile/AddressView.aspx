<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="AddressView.aspx.cs" Inherits="AddressView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Address Book</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <asp:GridView ID="gv_address" runat="server" AutoGenerateColumns="False" DataKeyNames="gsAbID" OnRowCancelingEdit="gv_address_RowCancelingEdit" OnRowDeleting="gv_address_RowDeleting" OnRowEditing="gv_address_RowEditing" OnRowUpdating="gv_address_RowUpdating" OnSelectedIndexChanged="gv_address_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="gsAddName" HeaderText="Name" />
                        <asp:BoundField DataField="gsAddInfo" HeaderText="Address" />
                        <asp:BoundField DataField="gsAddPostal" HeaderText="Postal Code" />
                        <asp:BoundField DataField="gsAddPhone" HeaderText="Phone Number" />
                        <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btn_add" runat="server" CssClass="btn" Text="Add new address" OnClick="btn_add_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

