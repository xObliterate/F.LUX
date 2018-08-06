<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="AdminShowroom.aspx.cs" Inherits="Showroom_AdminShowroom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Showroom Booking</a></li>
        </ul>

        <div class="col s12">
            <div class="form-container">
                <h3>
                    <asp:Label ID="lbl_empty" runat="server" Text="No booking" Visible="false"></asp:Label></h3>
                <asp:GridView ID="gv_showroom" CssClass="striped" runat="server" AutoGenerateColumns="false" DataKeyNames="gsshowid" OnRowDataBound="gv_showroom_RowDataBound">
                    <Columns>

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lbl_paxname" runat="server" Text='<%# string.Format("{0} {1}",Eval("gsfname") , Eval("gslname")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Time">
                            <ItemTemplate>
                                <asp:Label ID="lbl_slot" runat="server" Text='<%# Eval("gsslot") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Pax" DataField="gspax" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

