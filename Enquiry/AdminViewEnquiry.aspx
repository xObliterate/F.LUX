<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="AdminViewEnquiry.aspx.cs" Inherits="Enquiry_AdminViewEnquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Enquiry</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3>
                    <asp:Label ID="lbl_empty" runat="server" CssClass="teal-text" Visible="false">No enquiry</asp:Label></h3>
                <asp:GridView ID="gv_enquiry" CssClass="striped" runat="server" AutoGenerateColumns="False" DataKeyNames="gsid" OnSelectedIndexChanged="gv_enquiry_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="gsname" HeaderText="Name" />
                        <asp:BoundField DataField="gsemail" HeaderText="Email" />
                        <asp:BoundField DataField="gsmessage" HeaderText="Message" />
                        <asp:CommandField HeaderText="Actions" ShowSelectButton="True" SelectText=" &lt;i class=&quot;material-icons&quot;&gt;reply&lt;/i&gt;" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>

